using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ProductCase.GetAll
{
    public sealed record GetAllProductsResponse
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } 
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
