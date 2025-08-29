using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float countdown = 10f;
    private float timeRemaining = 0f;
    [SerializeField] GameObject timerGO;
    private TMP_Text timerText;

    void Awake()
    {
        timerText = timerGO.GetComponent<TMP_Text>();
    }

    void Start()
    {
        timeRemaining = countdown;
    }

    void Update()
    {
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining < 0f)
                timeRemaining = 0f;

            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            int milliseconds = Mathf.FloorToInt((timeRemaining * 100f) % 100f);

            string timeStr = string.Format("{0:00}:{1:00}", seconds, milliseconds);

            if (timerText != null)
                timerText.text = timeStr;

            Debug.Log(timeStr);
        }
    }

    public void IncreaseTimer()
    {
        countdown += 1;
    }

    public void DecreaseTimer()
    {
        countdown -= 1;
    }

    private void RestartTimer()
    {
        timeRemaining = countdown;
    }
}
