using System.Collections.Generic;
using UnityEngine;

public class StitchingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject threadPrefab;
    [SerializeField] private Transform leftBottom;
    [SerializeField] private Transform leftTop;
    [SerializeField] private Transform rightBottom;
    [SerializeField] private Transform rightTop;
    [SerializeField] private int amountPoints = 5;
    [SerializeField] private float offset = 0.5f;
    private List<Vector3> generatedPositions = new List<Vector3>();
    private List<GameObject> gameObjects = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.StitchingMiniGameEvent.OnMiniGameStarted += GenerateThreadPoints;
    }

    void GenerateThreadPoints()
    {
        Debug.Log("Generate Thread points");
        GeneratePoints(leftBottom.position, leftTop.position);
        GeneratePoints(rightBottom.position, rightTop.position);
    }

    private void GeneratePoints(Vector3 bottomPos, Vector3 topPos)
    {
        Vector3 topPosOff = topPos;
        topPosOff.y -= offset;
        Vector3 bottomPosOff = bottomPos;
        bottomPosOff.y += offset;

        Vector3 generatePos = bottomPosOff;
        float maxDistance = Vector3.Distance(bottomPosOff, topPosOff);
        Vector3 verticalDir = topPosOff - bottomPosOff;
        verticalDir = verticalDir.normalized;
        float incrementalDistance = maxDistance / amountPoints;
        for (int i = 1; i <= amountPoints; i++)
        {
            float randomVerticalDistance = Random.Range(0.1f, incrementalDistance);
            generatePos = generatePos + randomVerticalDistance * verticalDir;
            GameObject newPoint = Instantiate(threadPrefab);
            newPoint.transform.position = generatePos;
            generatedPositions.Add(generatePos);
            gameObjects.Add(newPoint);
            // set generate position to next part
            generatePos = bottomPosOff + i * verticalDir;
        }
    }
}
