using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using cambalache.Entities;

namespace cambalache.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get(string name = null, int? type = null, double? max = null, double? min =null);
        Task<Product> Get(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
