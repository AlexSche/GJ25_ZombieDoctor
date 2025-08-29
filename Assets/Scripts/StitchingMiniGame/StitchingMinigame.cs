using UnityEngine;

public class StitchingMinigame : MonoBehaviour
{
    [SerializeField] private GameObject threadPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.StitchingMiniGameEvent.OnMiniGameStarted += GenerateThreadPoints;
    }

    void GenerateThreadPoints()
    {
        Debug.Log("Generate Thread points");
    }
}
