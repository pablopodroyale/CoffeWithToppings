using System;
namespace CoffeWithToppings.Model
{
    public class ProductLeaf : ProductComponent
    {
        public ProductLeaf(string description, int price) : base(description, price)
        {
        }

        public override double GetPrice()
        {
            return base.Price;
        }
    }
}
