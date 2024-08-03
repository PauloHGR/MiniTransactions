using Application.Enums;
using MediatR;

namespace Application.UseCases.CustomerCase.GetAll
{
    public sealed record GetAllCustomersRequest(string Name,
        string CPF,
        string Email,
        int Size,
        int Offset,
        CustomerSortField CustomerSortField,
        SortOrder SortOrder) 
        : IRequest<List<GetAllCustomersResponse>>;
}
