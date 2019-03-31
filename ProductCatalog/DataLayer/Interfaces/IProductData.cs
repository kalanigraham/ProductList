using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataLayer.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(string name);
        Product GetProduct(int id);
        Product GetProduct(string name);
        bool AddProduct(Product product);

        bool CheckDuplicate(string name);
    }
}
