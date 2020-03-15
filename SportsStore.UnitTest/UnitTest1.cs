using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTest
{
    [TestClass]
    class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //przygotowanie
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //działanie
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;

            //asercje
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}

//Zwróć uwagę, jak łatwo dostać się do danych zwróconych z metody kontrolera.Skorzystaliśmy z właściwości
//Model w celu pobrania kolekcji IEnumerable<Product>, wygenerowanej przez metodę List.Po tej operacji możemy
//sprawdzić, czy mamy oczekiwane dane. W tym przypadku za pomocą metody LINQ o nazwie ToArray
//skonwertowaliśmy kolekcję na tablicę i sprawdziliśmy jej wielkość i wartości poszczególnych obiektów.