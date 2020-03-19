using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;


namespace SportsStore.UnitTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void CanAddToCart()
        {
            //Tworzenie imitacji
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "P1", Category = "Ubrania"},
                }.AsQueryable());
            //Utworzenie koszyka
            Cart cart = new Cart();

            //Utworzenie kontrolera
            CartController target = new CartController(mock.Object);

            //Dodanie produktu do koszyka
            target.AddToCart(cart, 1, null);

            //Asercje
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }
    }
}
