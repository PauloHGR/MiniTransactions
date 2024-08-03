namespace Application.UseCases.CustomerCase.Create
{
    public sealed record CreateCustomerResponse
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}
