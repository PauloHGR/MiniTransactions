namespace Application.UseCases.OrderCase.UpdateIsPayed
{
    public sealed record UpdateOrderIsPayedResponse(Guid Id,
        string CPF,
        Guid ProductId,
        double TotalValue,
        int Quantity,
        bool IsPayed);
}
