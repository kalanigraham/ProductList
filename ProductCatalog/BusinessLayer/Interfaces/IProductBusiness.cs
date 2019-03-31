using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessLayer.Interfaces
{
    public interface IProductBusiness
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(string name);
        Product GetProduct(int id);
        Product GetProduct(string name);
        bool AddProduct(Product product);

        bool CheckDuplicate(string name);
    }
}
