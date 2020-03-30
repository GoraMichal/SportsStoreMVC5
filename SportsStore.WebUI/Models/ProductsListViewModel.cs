using System;
using System.Collections.Generic;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
//Teraz można zaktualizować metodę List w klasie ProductController, aby korzystała z 
//klasy ProductsListViewModel do przekazania danych wyświetlanych produktów oraz informacji o stronicowaniu
