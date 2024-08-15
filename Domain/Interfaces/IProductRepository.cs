using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken, Expression<Func<Product, bool>>? filter = null);
    }
}
