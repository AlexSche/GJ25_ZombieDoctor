using UnityEngine;

public class SawingMinigameManager : MonoBehaviour
{
    private Vector3 defaultPosition = new Vector3(0, 3, -9.85f);
    private Vector3 sawingMinigamePosition = new Vector3(15, 3.5f, -12);
    private bool miniGameOpened = false;
    void Awake()
    {
        defaultPosition = Camera.main.transform.position;
        miniGameOpened = false;
    }

    void Start()
    {
        GameEvents.SawingMiniGameEvent.OnMiniGameFinished += CloseMiniGame;
    }

    void OnMouseDown()
    {
        OpenMiniGame();
    }

    public void OpenMiniGame()
    {
        if (!miniGameOpened)
        {
            miniGameOpened = true;
            GameEvents.SawingMiniGameEvent.OnMiniGameStarted?.Invoke();
            Camera.main.transform.position = sawingMinigamePosition;
        }
    }

    public void CloseMiniGame()
    {
        if (miniGameOpened)
        {
            Camera.main.transform.position = defaultPosition;
            miniGameOpened = false;
        }
    }
}
