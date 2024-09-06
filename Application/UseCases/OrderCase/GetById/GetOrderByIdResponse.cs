namespace Application.UseCases.OrderCase.GetById
{
    public sealed record GetOrderByIdResponse(Guid Id,
        string CPF,
        Guid ProductId,
        double TotalValue,
        int Quantity,
        bool IsPayed);
}
