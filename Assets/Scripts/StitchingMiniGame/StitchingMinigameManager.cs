using UnityEngine;
public class StitchingMinigameManager : MonoBehaviour
{
    private Vector3 defaultPosition = new Vector3(0, 3, -9.85f);
    private Vector3 stitchingMinigamePosition = new Vector3(30, 3.5f, -12);
    private bool miniGameOpened = false;
    void Awake()
    {
        defaultPosition = Camera.main.transform.position;
        miniGameOpened = false;
    }

    void Start()
    {
        GameEvents.StitchingMiniGameEvent.OnMiniGameFinished += CloseMiniGame;
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
            Camera.main.transform.position = stitchingMinigamePosition;
            GameEvents.StitchingMiniGameEvent.OnMiniGameStarted?.Invoke();
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
