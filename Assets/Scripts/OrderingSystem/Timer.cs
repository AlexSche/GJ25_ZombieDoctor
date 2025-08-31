using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float countdown = 8f;
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

            //fix bug if the values are too low
            if (timeRemaining < 0f)
            {
                timeRemaining = 0f;
                RestartTimer();
                // Start an order!
                GameEvents.OrderingEvent.OnCreateOrder?.Invoke();
            }

            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            int milliseconds = Mathf.FloorToInt((timeRemaining * 100f) % 100f);

            string timeStr = string.Format("{0:00}:{1:00}", seconds, milliseconds);

            if (timerText != null)
                timerText.text = timeStr;
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
