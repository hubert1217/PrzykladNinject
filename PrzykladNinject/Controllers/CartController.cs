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


        public ViewResult Index(Cart cart,string returnUrl) 
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl});
        }




        public RedirectToRouteResult AddToCart(Cart cart, int productid, string returnurl) 
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);

            if (product != null) 
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnurl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productid, string returnurl) 
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productid);
            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnurl });
        }



        /*private Cart GetCart() 
        {
            
            Cart cart = (Cart)Session["Cart"];
            if (cart == null) 
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }


            return cart;
        }
        */

        public ViewResult Checkout() 
        {
            return View(new ShippingDetails());
        }


        public PartialViewResult Summary(Cart cart) 
        {

            return PartialView(cart);
        }

    }


        

}