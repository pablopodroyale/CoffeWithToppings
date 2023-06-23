namespace CoffeWithToppings.Model
{
    public class ProductComposite: ProductComponent, IProduct
    {
        protected List<ProductComponent> _children = new List<ProductComponent>();

        public ProductComposite(string description, int price) : base(description, price)
        {
        }

        public void Add(ProductComponent product)
        {
            this._children.Add(product);
        }
        
        public void Remove(ProductComponent product)
        {
            this._children.Remove(product);
        }

        public override double GetPrice()
        {
            double price = 0;

            foreach (ProductComponent component in this._children)
            {
                price += component.GetPrice();
            }

            return price + base.Price;
        }
    }
}
