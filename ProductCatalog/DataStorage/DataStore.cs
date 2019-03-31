using ProductCatalog.DataStorage.Interfaces;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataStorage
{
    public class DataStore : IDataStore
    {
        private List<Product> _products = new List<Product>();

        public bool Add(Product product)
        {
            _products.Add(product);
            return true;
        }

        public IEnumerable<Product> Get()
        {
            return _products;
        }
    }
}
