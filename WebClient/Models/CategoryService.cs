using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class CategoryService : BaseService
    {
        public List<Category> GetCategories()
        {
            return Gets<Category>("category");
        }
        public Category GetCategoryById(int id)
        {
            return Get<Category>($"category/{id}");
        }
        public int Add(Category obj)
        {
            return Post<Category>("category", obj);
        }
        public int Delete(int id)
        {
            return Delete($"category/{id}");
        }
        public int Edit(Category obj)
        {
            return Put<Category>($"category/{obj.Id}", obj);
        }
        public Category GetCategoryDetail(int id)
        {
            return Get<Category>($"home/browser/{id}");
        }
    }
}
