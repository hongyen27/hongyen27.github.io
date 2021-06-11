using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class ProductService : BaseService
    {
        public List<Product> GetProducts()
        {
            return Gets<Product>("Product");
        }
        public Product GetProductById(int id)
        {
            return Get<Product>($"product/{id}");
        }
        public int Add(Product obj)
        {
            return Post<Product>("product", obj);
        }
        public int Delete(int id)
        {
            return Delete($"product/{id}");
        }
        public int Edit(Product obj)
        {
            return Put<Product>($"product/{obj.Id}", obj);
        }
        public Product GetProductsDetail(int id)
        {
            return Get<Product>($"home/detail/{id}");
        }
        public List<Product> GetProductsPagination(int id, int size)
        {
            return Gets<Product>($"home/{id}&{size}");
        }
        public List<Product> SearchProductsPagination(string q, int id, int size)
        {
            return Gets<Product>($"home/search/{q}&{id}&{size}");
        }
    }
}
