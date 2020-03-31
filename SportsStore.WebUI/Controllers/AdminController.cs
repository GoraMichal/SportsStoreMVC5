using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]

    //Konstruktor deklaruje zaleznosc od interfejsu, ktory jest powiazny z Ninject.
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            //kontrola poprawnosci danych
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                //komunikat, podobny do ViewBag, ale usuwany na koncu rzadania HTTP
                TempData["message"] = string.Format("Zapisano {0} ", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // błąd w wartościach danych i generowanie widoku
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deleteProduct = repository.DeleteProduct(productId);
            
            if(deleteProduct != null)
            {
                TempData["message"] = string.Format("Usunieto {0}", deleteProduct.Name);
            }

            return RedirectToAction("Index");
        }

    }
}