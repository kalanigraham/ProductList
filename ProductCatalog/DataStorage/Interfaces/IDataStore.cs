using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.DataStorage.Interfaces
{
    public interface IDataStore
    {
        bool Add(Product product);
        IEnumerable<Product> Get();
    }
}
