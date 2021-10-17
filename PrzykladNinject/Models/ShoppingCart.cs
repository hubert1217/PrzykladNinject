using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzykladNinject.Models
{
    public class ShoppingCart
    {
        //public IEnumerable<Product> products { get; set; }
        public IProductRepository repository;
        private decimal calculateProductTotal;
        private ICalculator Obliczenia;

        public ShoppingCart(ICalculator calcParam, IProductRepository repoParam) 
        {
            repository = repoParam;
            Obliczenia = calcParam;
        }

        public decimal CalculateProductTotal() 
        {
            calculateProductTotal = Obliczenia.Oblicz(repository);
            return calculateProductTotal;
        }

        
    }
}