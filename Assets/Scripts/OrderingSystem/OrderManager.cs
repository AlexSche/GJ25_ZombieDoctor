using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvents.OrderingEvent.OnCreateOrder += CreateOrder;
    }

    public void CreateOrder()
    {
        Debug.Log("Create order");
    }
}
