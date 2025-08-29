using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    public static readonly SawingMiniGameEvent sawingMiniGameEvent = new SawingMiniGameEvent();
    public static readonly StitchingMiniGameEvent stitchingMiniGameEvent = new StitchingMiniGameEvent();
    public static readonly OrderingEvent orderingEvent= new OrderingEvent();


    public class SawingMiniGameEvent
    {
        public static UnityAction OnMiniGameStarted;
        public static UnityAction OnLineComplete;
        public static UnityAction OnMiniGameFinished;
    }

    public class StitchingMiniGameEvent
    {
        public static UnityAction OnMiniGameStarted;
        public static UnityAction OnThreadComplete;
        public static UnityAction OnMiniGameFinished;
    }

    public class OrderingEvent
    {
        public static UnityAction OnCreateOrder;
        public static UnityAction OnSawingOrderComplete;
        public static UnityAction OnStitchingOrderComplete;
    }

}
