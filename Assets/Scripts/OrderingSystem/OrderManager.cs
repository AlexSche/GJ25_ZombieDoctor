using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] GameObject stitchingOrder;
    [SerializeField] GameObject sawingOrder;
    [SerializeField] OrderList orderList;
    [SerializeField] Transform spawnTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.OrderingEvent.OnCreateOrder += CreateOrder;
        GameEvents.StitchingMiniGameEvent.OnMiniGameFinished += SpawnStitchingOrder;
        GameEvents.SawingMiniGameEvent.OnMiniGameFinished += SpawnSawingOrder;
    }

    public void CreateOrder()
    {
        if (Random.Range(0, 2) == 0)
        {

            orderList.AddNewStitchingOrder();
        }
        else
        {

            orderList.AddNewSawingOrder();
        }
    }

    public void SpawnStitchingOrder()
    {
        Instantiate(stitchingOrder, spawnTransform);
    }

    public void SpawnSawingOrder()
    {
        Instantiate(sawingOrder, spawnTransform);
    }
}
