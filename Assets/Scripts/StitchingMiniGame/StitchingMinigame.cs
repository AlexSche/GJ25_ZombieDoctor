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
    private readonly List<Vector3> generatedPositions = new List<Vector3>();
    private readonly List<GameObject> gameObjects = new List<GameObject>();
    private readonly List<int> numbers = new List<int>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.StitchingMiniGameEvent.OnMiniGameStarted += GenerateThreadPoints;
        GameEvents.StitchingMiniGameEvent.OnMiniGameFinished += RemoveThreads;
    }

    void GenerateThreadPoints()
    {
        GeneratePoints(leftBottom.position, leftTop.position);
        GeneratePoints(rightBottom.position, rightTop.position);
    }

    private void GeneratePoints(Vector3 bottomPos, Vector3 topPos)
    {
        populateNumbersInList(amountPoints);
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
            float randomVerticalDistance = Random.Range(0.75f, incrementalDistance);
            generatePos = generatePos + randomVerticalDistance * verticalDir;
            GameObject newPoint = Instantiate(threadPrefab);
            newPoint.transform.position = generatePos;
            generatedPositions.Add(generatePos);
            gameObjects.Add(newPoint);
            int randomValue = TakeRandomNumberFromList();
            newPoint.GetComponent<Thread>().name = randomValue.ToString();
            newPoint.GetComponent<Thread>().SetNumber(randomValue);
            // set generate position to next part
            generatePos = bottomPosOff + i * verticalDir;
        }
    }

    private void RemoveThreads()
    {
        generatedPositions.Clear();
        gameObjects.ForEach(gameObject =>
        {
            Destroy(gameObject);
        });
        gameObjects.Clear();
    }

    private void populateNumbersInList(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            numbers.Add(i);
        }
    }

    private int TakeRandomNumberFromList()
    {
        int value = Random.Range(0, numbers.Count);
        int returnValue = numbers[value];
        numbers.Remove(returnValue);
        Debug.Log(numbers.Count);
        Debug.Log(returnValue);
        return returnValue;
    }
}
