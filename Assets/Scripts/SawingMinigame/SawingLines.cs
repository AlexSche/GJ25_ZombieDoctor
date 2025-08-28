using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class SawingLines : MonoBehaviour
{
    [SerializeField] private Transform topPos;
    [SerializeField] private Transform bottomPos;
    [SerializeField] private Transform leftPos;
    [SerializeField] private int amountPoints;
    [SerializeField] private float spread = 2;
    [SerializeField] private float offset;
    [SerializeField] private GameObject linePrefab;
    private Vector3 topPosOff;
    private Vector3 bottomPosOff;
    private readonly List<Vector3> anchorPoints = new List<Vector3>();
    private readonly List<LineFollower> lines = new List<LineFollower>();

    // audio
    private EventInstance chainsawLoop;
    void Start()
    {
        if (amountPoints == 0) { amountPoints = 4; }
        if (spread == 0) { spread = 2; }
        if (offset == 0) { offset = 0.5f; }
        topPosOff = topPos.position;
        topPosOff.y -= offset;
        bottomPosOff = bottomPos.position;
        bottomPosOff.y += offset;
        GameEvents.SawingMiniGameEvent.OnMiniGameStarted += CreateSawingLines;
        GameEvents.SawingMiniGameEvent.OnLineComplete += SawingLinesComplete;
        GameEvents.SawingMiniGameEvent.OnMiniGameFinished += DeleteLines;

        chainsawLoop = AudioManager.instance.CreateSoundInstance(FModEvents.instance.sawChain);
    }

    public void CreateSawingLines()
    {
        GeneratePoints();
        ConnectPoints();
        chainsawLoop.start();
    }

    private void GeneratePoints()
    {
        Vector3 generatePos = bottomPosOff;
        float maxDistance = Vector3.Distance(bottomPosOff, topPosOff);
        Vector3 verticalDir = topPosOff - bottomPosOff;
        verticalDir = verticalDir.normalized;
        Vector3 horizDir = leftPos.position - bottomPos.position;
        horizDir = horizDir.normalized;
        float incrementalDistance = maxDistance / amountPoints;
        for (int i = 1; i <= amountPoints; i++)
        {
            float randomVerticalDistance = Random.Range(0.1f, incrementalDistance);
            spread *= -1;
            float randomHorizontalDistance = Random.Range(0, spread);
            generatePos = generatePos + randomVerticalDistance * verticalDir;
            generatePos = generatePos + randomHorizontalDistance * horizDir;
            anchorPoints.Add(generatePos);
            // set generate position to next part
            generatePos = bottomPosOff + i * verticalDir;
        }
    }

    private void ConnectPoints()
    {
        Vector3 startPoint = anchorPoints[0];
        for (int i = 1; i < anchorPoints.Count; i++)
        {
            CreateLinePrefabBetweenPoints(startPoint, anchorPoints[i]);
            startPoint = anchorPoints[i];
        }
    }

    void CreateLinePrefabBetweenPoints(Vector3 start, Vector3 end)
    {
        // Create object
        GameObject line = Instantiate(linePrefab);

        // Position: midpoint
        line.transform.position = (start + end) / 2f;
        Vector3 pos = line.transform.position;
        pos.z -= 0.01f;
        line.transform.position = pos;

        // Scale: stretch to distance (assuming prefab height = 1)
        float distance = Vector3.Distance(start, end);
        Vector3 scale = line.transform.localScale;
        scale.y = distance / 2f; // cylinder default height = 2 units
        line.transform.localScale = scale;

        Vector3 dir = (end - start).normalized;
        // Rotation: align with direction
        line.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        LineFollower lineFollower = line.GetComponent<LineFollower>();
        lineFollower.Initialize(start, end, dir, distance);
        lines.Add(lineFollower);
    }

    public bool AreSawingLinesComplete()
    {
        bool AreComplete = true;
        lines.ForEach(line =>
        {
            if (!line.isComplete)
            {
                AreComplete = false;
                return;
            }
        });
        return AreComplete;
    }

    public void SawingLinesComplete()
    {
        if (AreSawingLinesComplete())
        {
            // drop chainsaw
            GameEvents.SawingMiniGameEvent.OnMiniGameFinished.Invoke();
        }
    }

    private void DeleteLines()
    {
        lines.ForEach(line =>
        {
            Debug.Log(line.name);
            Destroy(line.gameObject);
        });
        lines.Clear();
        anchorPoints.Clear();
        chainsawLoop.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
