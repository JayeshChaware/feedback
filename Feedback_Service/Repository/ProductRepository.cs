using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feedback_Service.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly UsersDbContext _usersDbContext;
        public ProductRepository(UsersDbContext context)
        {
            _usersDbContext = context;
        }
        public void AddProduct(Product product)
        {
            _usersDbContext.Products.Add(product);
            _usersDbContext.SaveChanges();
        }

        public bool Any(int? Id)
        {
            if (_usersDbContext.Products.Any(x => x.Id == Id))
            {
                return true;
            }
            return false;
        }

        public void DeleteProductById(int? id)
        {
            Product temp = _usersDbContext.Products.Find(id);
            _usersDbContext.Products.Remove(temp);
            _usersDbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _usersDbContext.Products.ToList();
        }

        public Product GetProductById(int? id)
        {
            return _usersDbContext.Products.FirstOrDefault(p => p.Id == id);

        }

        public void UpdateProduct(Product product)
        {
            _usersDbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _usersDbContext.SaveChanges();
        }
    }
}
