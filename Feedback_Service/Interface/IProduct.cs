using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void DeleteProductById(int id);
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProduct();
        void UpdateProduct(Product product);
        
    }
}
