using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    //Łącznik modelu do tworzenia obiektow Cart
    //Zalety: 1. Oddzielenie logiki tworzenia obiektow od kontrolera (sposob przechowywania ob.)
    // 2. Obiekty można zadeklarować jako parametry metody akcji
    // 3. Schludniejsze tworzenie testów jednostkowych

    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        //ControllerContext zapewnia dostep do danych z klasy kontrolera
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //pobranie obiektu z sesji
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            //utworzenie obiektu, gdy null
            if (cart == null)
            {
                cart = new Cart();
                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            
            return cart;
        }
    }
}