using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeWithToppings.Model
{
    public interface IProduct
    {
        void Add(ProductComponent product);
        void Remove(ProductComponent product);
    }
}
