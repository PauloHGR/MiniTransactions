namespace Application.UseCases.OrderCase.Create
{
    public sealed record CreateOrderResponse(
        string CPF,
        string CustomerName,
        string ProductName,
        int Quantity,
        double TotalValue);
}
