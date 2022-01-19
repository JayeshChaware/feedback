using Feedback_DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feedback_Service.Interface
{
    public interface IProduct
    {
        void AddProduct(Product product);
        void DeleteProductById(int? id);
        Product GetProductById(int? id);
        IEnumerable<Product> GetAllProduct();
        //public IEnumerable<Product> GetAllProductById(int? id);
        void UpdateProduct(Product product);
        bool Any(int? Id);

    }
}
