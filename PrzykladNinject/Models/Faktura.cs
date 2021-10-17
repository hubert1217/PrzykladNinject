using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrzykladNinject.Models
{
    public class Faktura
    {
        public IEnumerable<Product> products { get; set; }
        public IProductRepository repository;
        public Customer customers { get; set; }

        public Faktura nowaFaktura; 

        public Faktura(Customer customerParam ,IProductRepository repoParam) 
        {
            repository = repoParam;
            customers = customerParam;
        }

        public Faktura GenerujFakture() 
        {
            nowaFaktura.repository = repository;
            nowaFaktura.customers = customers;


            return nowaFaktura; 
        }

    }
}