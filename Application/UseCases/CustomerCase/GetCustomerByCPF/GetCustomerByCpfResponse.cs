namespace Application.UseCases.CustomerCase.GetCustomerByCPF
{
    public sealed record GetCustomerByCpfResponse(string Name, 
        string CPF, 
        string Email);
}
