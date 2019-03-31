using ProductCatalog.DataLayer.Interfaces;
using ProductCatalog.DataStorage.Interfaces;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataLayer
{
    public class ProductData : IProductData
    {
        //private List<Product> _products = new List<Product>();
        private IDataStore _store;

        public ProductData(IDataStore store)
        {
            //_products.Add(new Product { Name = "Test", Description = "Test Desc", Quantity = 1 });
            _store = store;
        }

        public Product GetProduct(int id)
        {
            return _store.Get().FirstOrDefault(x => x.Id == id);
        }

        public Product GetProduct(string name)
        {
            return _store.Get().FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _store.Get();
            return products;
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _store.Get().Where(x => x.Name.Contains(name));
        }

        public bool AddProduct(Product product)
        {
            _store.Add(product);
            return true;
        }

        public bool CheckDuplicate(string name)
        {
            return _store.Get().Any(x => x.Name == name);
        }
    }
}
