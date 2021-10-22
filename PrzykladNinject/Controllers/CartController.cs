using PrzykladNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PrzykladNinject.Controllers
{
    public class CartController : Controller
    {
        
        private IProductRepository repository;


        public CartController(IProductRepository repoParam) 
        {
            repository = repoParam;
        }


        public ViewResult Index(string returnUrl) 
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl});
        }




        public RedirectToRouteResult AddToCart(int productid, string returnurl) 
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);

            if (product != null) 
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnurl });
        }

        public RedirectToRouteResult RemoveFromCart(int productid, string returnurl) 
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnurl });
        }



        private Cart GetCart() 
        {
            
            Cart cart = (Cart)Session["Cart"];
            if (cart == null) 
            { 
                Session["Cart"] = cart;
            }


            return cart;
        }
    }


        

}