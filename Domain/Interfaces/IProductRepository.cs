using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Task<List<Product>> GetAll(CancellationToken cancellationToken);
        void Delete(Product product);
        void Update(Product product);
        Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
