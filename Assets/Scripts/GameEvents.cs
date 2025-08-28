using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static readonly SawingMiniGameEvent sawingMiniGameEvent = new SawingMiniGameEvent();
    public static readonly StitchingMiniGameEvent stitchingMiniGameEvent = new StitchingMiniGameEvent();


    public class SawingMiniGameEvent
    {
        public static UnityAction OnMiniGameStarted;
        public static UnityAction OnLineComplete;
        public static UnityAction OnMiniGameFinished;
    }

    public class StitchingMiniGameEvent
    {
        public static UnityAction OnMiniGameStarted;
        public static UnityAction OnMiniGameFinished;
    }

}
