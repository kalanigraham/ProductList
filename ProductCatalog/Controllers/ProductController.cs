using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLayer.Interfaces;
using ProductCatalog.Exceptions;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Controllers
{
    [Route("api/[controller]/")]
    public class ProductController : Controller
    {
        private IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [Route("GetProducts")]
        [HttpGet("[action]")]
        public IEnumerable<Product> GetProducts()
        {
            return _productBusiness.GetProducts();
        }

        [Route("GetProducts/{name}")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(string name)
        {
            return _productBusiness.GetProducts(name);
        }

        [Route("GetProduct/{id}")]
        [HttpGet]
        public ActionResult<Product> GetProduct(int id)
        {
            return _productBusiness.GetProduct(id);
        }

        [Route("GetProduct/{name}")]
        [HttpGet]
        public ActionResult<Product> GetProduct(string name)
        {
            return _productBusiness.GetProduct(name);
        }

        [Route("AddProduct")]
        [HttpPost]
        public ActionResult<bool> AddProduct(Product product)
        {
            try
            {
                return _productBusiness.AddProduct(product);
            }
            catch (DuplicateProductException)
            {
                return new BadRequestResult();
            }
        }

        [Route("AddProduct/{name}/{quantity}")]
        [HttpGet]
        public ActionResult<bool> AddProduct(string name, int quantity)
        {
            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                Description = ""
            };
            try
            {
                return _productBusiness.AddProduct(product);
            }
            catch (DuplicateProductException)
            {
                return new BadRequestResult();
            }
        }

        [Route("AddProduct/{name}/{quantity}/{desc}")]
        [HttpGet]
        public ActionResult<bool> AddProduct(string name, int quantity, string desc)
        {
            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                Description = desc
            };
            try
            {
                return _productBusiness.AddProduct(product);
            }
            catch (DuplicateProductException)
            {
                return new BadRequestResult();
            }
        }

        [Route("IsDuplicate/{name}")]
        [HttpGet]
        public ActionResult<bool> IsDuplicate(string name)
        {
            try
            {
                return _productBusiness.CheckDuplicate(name);
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }
    }
}
