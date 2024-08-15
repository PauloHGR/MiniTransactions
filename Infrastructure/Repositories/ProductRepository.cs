using Domain.Customers;
using Domain.Interfaces;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Product product)
        {
            _appDbContext.Products.Add(product);
        }

        public void Delete(Product product)
        {
            _appDbContext.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken, Expression<Func<Product, bool>>? filter = null)
        {
            var products = _appDbContext.Products;
            return filter == null ? await products.ToListAsync(cancellationToken) : await products.Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Product? product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id, cancellationToken);
            return product;
        }

        public void Update(Product product)
        {
            _appDbContext.Products.Update(product);
        }
    }
}
