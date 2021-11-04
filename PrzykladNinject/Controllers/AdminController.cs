using PrzykladNinject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrzykladNinject.Controllers
{
    public class AdminController : Controller
    {

        private IProductRepository productRepository;

        public AdminController(IProductRepository prod) 
        {
            productRepository = prod;
        
        }


        // GET: Admin
        public ViewResult Index()
        {
            return View(productRepository.Products);
        }


        public ViewResult Edit(int productId) 
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }



    }
}