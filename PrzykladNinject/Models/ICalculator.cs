using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrzykladNinject.Models
{
    public interface ICalculator
    {
        decimal Oblicz(IProductRepository repository);
    }
}
