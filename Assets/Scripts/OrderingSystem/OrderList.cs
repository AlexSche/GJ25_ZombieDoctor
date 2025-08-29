using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    private static string sawingOrder = "- Chainsaw!";
    private static string stitchingOrder = "- Stitching Limbs!";
    [SerializeField] private TMP_Text orderText;
    private List<Order> orders = new List<Order>();

    void Start()
    {
        GameEvents.StitchingMiniGameEvent.OnMiniGameFinished += RemoveFirstStitching;
        GameEvents.SawingMiniGameEvent.OnMiniGameFinished += RemoveFirstSawing;
    }

    public void AddNewSawingOrder()
    {
        orders.Add(new Order(false, sawingOrder, OrderType.Sawing));
        UpdatesOrders();
    }

    public void AddNewStitchingOrder()
    {
        orders.Add(new Order(false, stitchingOrder, OrderType.Stitching));
        UpdatesOrders();
    }

    public void RemoveFirstStitching()
    {
        Order order = orders.First(order => order.orderType == OrderType.Stitching);
        orders.Remove(order);
        UpdatesOrders();
    }

    public void RemoveFirstSawing()
    {
        Order order = orders.First(order => order.orderType == OrderType.Sawing);
        orders.Remove(order);
        UpdatesOrders();
    }

    private void UpdatesOrders()
    {
        DisplayOrders();
    }

    private void DisplayOrders()
    {
        string displayText = "";
        foreach (var order in orders)
        {
            displayText += order.text;
            displayText += "\n";
        }
        orderText.text = displayText;
    }
}
