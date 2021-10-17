using PrzykladNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace PrzykladNinject.Controllers
{
    public class HomeController : Controller
    {
        private ICalculator oblicz;
        public int PageSize = 4; 
        private IProductRepository repository;
        /*private Product[] products = {
                new Product { Name = "Playstation 4", Category = "Konsola stacjonarna", Description ="Konsola stacjonarna od SONY", Price=1099M },
                new Product { Name="Xbox One S", Category = "Konsola stacjonarna", Description ="Konsola stacjonarna od Microsoft", Price = 999M },
                new Product { Name = "Nintendo Switch", Category = "Konsola hybrydowa", Description = "Konsola hybrydowa od Nintendo", Price = 1499M},
                new Product { Name = "Nintendo 3DS", Category = "Konsola przenośna", Description = "Konsola prznośna od Nintendo z funkcja 3D", Price = 499M},
                new Product { Name = "Playstation Vita", Category = "Konsola przenośna", Description = "Konsola przenosna od Sony z ekranem OLED", Price = 899M}
        };
        */

        
        public HomeController(ICalculator obliczParam, IProductRepository repoParam) 
        {
            oblicz = obliczParam;
            repository = repoParam;
        }
        public ActionResult Index()
        {
            
            ShoppingCart cart = new ShoppingCart(oblicz, repository);



            return View(cart.CalculateProductTotal());
        }


        public ActionResult List(string category, int page =1) 
        {
            ProductListViewModel viewModel = new ProductListViewModel()
            {
                Products = repository.Products.Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
                
            };
            return View(viewModel);
        }
        
        
        
        
        
        public ActionResult About()
        {
            Customer cust = new Customer() { NameCustomer = "Hubert", SurnameCustomer = "Rojek" };
            Faktura nowaFaktura = new Faktura(cust, repository);



            return View(nowaFaktura);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}