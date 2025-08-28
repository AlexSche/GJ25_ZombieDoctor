using System.Collections.Generic;
using UnityEngine;

public class CreateSawingLine : MonoBehaviour
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
    private List<Vector3> anchorPoints = new List<Vector3>();
    void Start()
    {
        if (amountPoints == 0) { amountPoints = 4; }
        if (spread == 0) { spread = 2; }
        if (offset == 0) { offset = 0.5f; }
        topPosOff = topPos.position;
        topPosOff.y -= offset;
        bottomPosOff = bottomPos.position;
        bottomPosOff.y += offset;
        GeneratePoints();
        ConnectPoints();
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
            Debug.DrawLine(startPoint, anchorPoints[i], Color.red, 100f);
            CreateLinePrefabBetweenPoints(startPoint, anchorPoints[i]);
            startPoint = anchorPoints[i];
        }
    }

    void CreateLinePrefabBetweenPoints(Vector3 start, Vector3 end)
    {
        // Create object
        GameObject obj = Instantiate(linePrefab);

        // Position: midpoint
        obj.transform.position = (start + end) / 2f;
        Vector3 pos = obj.transform.position;
        pos.z -= 0.01f;
        obj.transform.position = pos;

        // Scale: stretch to distance (assuming prefab height = 1)
        float distance = Vector3.Distance(start, end);
        Vector3 scale = obj.transform.localScale;
        scale.y = distance / 2f; // cylinder default height = 2 units
        obj.transform.localScale = scale;

        Vector3 dir = (end - start).normalized;
        // Rotation: align with direction
        obj.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        obj.GetComponent<LineFollower>().Initialize(start, end, dir, distance);
    }

}
