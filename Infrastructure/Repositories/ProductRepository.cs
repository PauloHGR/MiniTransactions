using Domain.Interfaces;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _appDbContext.Products.ToListAsync(cancellationToken);
            return products;
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            Product product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return product;
        }

        public void Update(Product product)
        {
            _appDbContext.Products.Update(product);
        }
    }
}
