using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzykladNinject.Models
{
    public class Calculator:ICalculator
    {
        public decimal totalValue { get; set; }


        public decimal Oblicz(IProductRepository repository) 
        {
            totalValue = repository.Products.Sum(p => p.Price);
            return totalValue;
                        
        }


    }
}