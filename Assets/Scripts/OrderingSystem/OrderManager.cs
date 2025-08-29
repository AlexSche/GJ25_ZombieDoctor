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
    }

    public void CreateOrder()
    {
        if (Random.Range(0, 2) == 0)
        {
            Debug.Log("Create Stitching Order");
            //Instantiate(stitchingOrder, spawnTransform);
            orderList.AddNewStitchingOrder();
        }
        else
        {
            Debug.Log("Create Sawing Order");
            //Instantiate(sawingOrder, spawnTransform);
            orderList.AddNewSawingOrder();
        }
    }
}
