using System;
using System.Collections.Generic;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
//Teraz możemy zaktualizować metodę List w klasie ProductController, aby korzystała z 
//klasy ProductsListViewModel do przekazania danych wyświetlanych produktów oraz informacji o stronicowaniu
