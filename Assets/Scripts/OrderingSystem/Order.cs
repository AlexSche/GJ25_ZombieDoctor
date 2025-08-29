public class Order
{
    public bool isComplete;
    public string text;
    public OrderType orderType;

    public Order(bool isComplete, string text, OrderType orderType)
    {
        this.isComplete = false;
        this.text = text;
        this.orderType = orderType;
    }
}

public enum OrderType
{
    Sawing,
    Stitching
}