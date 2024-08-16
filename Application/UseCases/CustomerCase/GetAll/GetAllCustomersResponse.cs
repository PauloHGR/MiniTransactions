
namespace Application.UseCases.CustomerCase.GetAll
{
    public sealed record GetAllCustomersResponse(
        string Name,
        string CPF,
        string Email);
}
