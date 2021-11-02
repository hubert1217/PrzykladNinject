using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using PrzykladNinject.Models;
using Moq;
using PrzykladNinject.Entities;
using System.Configuration;

namespace PrzykladNinject.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam) 
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            /*
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product> {
                new Product { Name = "Playstation 4", Category = "Konsola stacjonarna", Description ="Konsola stacjonarna od SONY", Price=1099M },
                new Product { Name="Xbox One S", Category = "Konsola stacjonarna", Description ="Konsola stacjonarna od Microsoft", Price = 999M },
                new Product { Name = "Nintendo Switch", Category = "Konsola hybrydowa", Description = "Konsola hybrydowa od Nintendo", Price = 1499M},
                new Product { Name = "Nintendo 3DS", Category = "Konsola przenośna", Description = "Konsola prznośna od Nintendo z funkcja 3D", Price = 499M},
                new Product { Name = "Playstation Vita", Category = "Konsola przenośna", Description = "Konsola przenosna od Sony z ekranem OLED", Price = 899M}
            });
            kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            */

            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<ICalculator>().To<Calculator>();


            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };


            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);


        }

        public object GetService(Type serviceType) 
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) 
        {
            return kernel.GetAll(serviceType);
        }

    }
}