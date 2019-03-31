using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLayer.Interfaces;
using ProductCatalog.DataLayer.Interfaces;
using ProductCatalog.Exceptions;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessLayer
{
    public class ProductBusiness : IProductBusiness
    {
        private IProductData _productData;

        public ProductBusiness(IProductData productData)
        {
            _productData = productData;
        }

        public Product GetProduct(int id)
        {
            return _productData.GetProduct(id);
        }

        public Product GetProduct(string name)
        {
            return _productData.GetProduct(name);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productData.GetProducts();
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return _productData.GetProducts(name);
        }

        public bool AddProduct(Product product)
        {
            var p = GetProduct(product.Name);
            if (p == null)
            {
                return _productData.AddProduct(product);
            }
            throw new DuplicateProductException("Duplicate product","A product already exists with the same name.");
            
        }

        public bool CheckDuplicate(string name)
        {
            return _productData.CheckDuplicate(name);
        }
    }
}
