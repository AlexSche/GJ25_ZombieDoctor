using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] GameObject StitchingOrder;
    [SerializeField] GameObject SawingOrder;
    [SerializeField] Transform spawnTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.OrderingEvent.OnCreateOrder += CreateOrder;
    }

    public void CreateOrder()
    {
        if (Random.Range(0, 1) == 0)
        {
            Debug.Log("Create Stitching Order");
        }
        else
        {
            Debug.Log("Create Sawing Order");
        }
    }
}
