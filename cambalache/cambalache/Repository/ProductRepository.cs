using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cambalache.Entities;
using cambalache.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cambalache.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var productToDelete = await _context.Product.FindAsync(id);
            _context.Product.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Get(string name = null, int? type = null, double? max = double.MaxValue, double? min = 0)
        {
            var queryable = _context.Product.AsQueryable();
            if (name != null || type != null || max != null || min != null)
            {
                queryable = queryable.Where(pr => pr.name.Contains(name) ||
                                                  pr.type.Equals(type) ||
                                                  pr.price >= min || pr.price <= max);
                foreach (var item in queryable)
                {
                    item.image64 = BlobToStringConverter(item.image);
                }
                return queryable;
            }
            else {
                var result = await queryable.ToListAsync();
                foreach (var item in result)
                {
                    item.image64 = BlobToStringConverter(item.image);
                }
                return result;
             }
        }
        public string BlobToStringConverter(byte[] blobObject)
        {
            if (blobObject != null)
            {
                return Encoding.UTF8.GetString(blobObject);
            }
            else
            {
                return string.Empty;
            }
        }
        public async Task<Product> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
