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
        private IOrderProcessor orderProcessor;

        public CartController(IProductRepository repoParam, IOrderProcessor proc) 
        {
            repository = repoParam;
            orderProcessor = proc;
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

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) 
        {
            if (cart.Lines.Count() == 0) 
            {
                ModelState.AddModelError("", "Koszyk jest pusty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();

                return View("Completed");
            }
            else 
            {
                return View(shippingDetails);
            }
        }


    }


        

}