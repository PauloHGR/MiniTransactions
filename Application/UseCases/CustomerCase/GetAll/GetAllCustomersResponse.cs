
namespace Application.UseCases.CustomerCase.GetAll
{
    public sealed record GetAllCustomersResponse(Guid CustomerId,
        string Name,
        string CPF,
        string Email);
}
