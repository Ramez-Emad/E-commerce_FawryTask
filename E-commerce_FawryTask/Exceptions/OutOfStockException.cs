namespace E_commerce_FawryTask.Exceptions;
public class OutOfStockException : Exception
{
    public OutOfStockException(string productName, int requested, int available)
        : base($"Product '{productName}' does not have enough stock. Requested: {requested}, Available: {available}") { }
}
