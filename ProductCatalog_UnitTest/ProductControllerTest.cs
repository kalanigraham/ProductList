using FluentAssertions;
using Moq;
using ProductCatalog.BusinessLayer.Interfaces;
using ProductCatalog.Controllers;
using ProductCatalog.Exceptions;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductCatalog_UnitTest
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetProductsShouldReturnEmptyProducts()
        {
            var test = new List<Product>();
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.GetProducts()).Returns(test);

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.GetProducts();

            actual.Should().HaveSameCount(test);
            actual.Should().BeEquivalentTo(test);
            productBusiness.Verify(m => m.GetProducts());
        }

        [Fact]
        public void GetProductsShouldReturnNonEmptyProducts()
        {
            var test = new List<Product>();
            test.Add(new Product
            {
                Name = "Test",
                Description = "Desc",
                Quantity = 1,
            });
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.GetProducts()).Returns(test);

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.GetProducts();

            actual.Should().HaveSameCount(test);
            actual.Should().BeEquivalentTo(test);
            productBusiness.Verify(m => m.GetProducts());
        }

        [Fact]
        public void IsDuplicateShouldReturnTrue()
        {
            var test = "Test";
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.CheckDuplicate(test)).Returns(true);

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.IsDuplicate(test);

            actual.Value.Should().BeTrue();
            productBusiness.Verify(m => m.CheckDuplicate(test));
        }

        [Fact]
        public void IsDuplicateShouldReturnFalse()
        {
            var test = "Test";
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.CheckDuplicate(test)).Returns(false);

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.IsDuplicate(test);

            actual.Value.Should().BeFalse();
            productBusiness.Verify(m => m.CheckDuplicate(test));
        }

        [Fact]
        public void AddProductShouldAddProduct()
        {
            var test = new Product
            {
                Name="Test",
                Description="Desc",
                Quantity=1
            };
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.AddProduct(It.IsAny<Product>())).Returns(true);

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.AddProduct(test);

            actual.Value.Should().BeTrue();
            productBusiness.Verify(m => m.AddProduct(It.IsAny<Product>()));
        }

        [Fact]
        public void AddProductShouldThrowExceptionOnDuplicate()
        {
            var test = new Product
            {
                Name = "Test",
                Description = "Desc",
                Quantity = 1
            };
            var productBusiness = new Mock<IProductBusiness>();
            productBusiness.Setup(x => x.AddProduct(test)).Throws(new DuplicateProductException("",""));

            var productController = new ProductController(productBusiness.Object);

            var actual = productController.AddProduct(test);

            productBusiness.Verify(m => m.AddProduct(It.IsAny<Product>()));
        }
    }
}
