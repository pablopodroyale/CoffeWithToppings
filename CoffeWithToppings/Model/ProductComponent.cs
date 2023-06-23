namespace CoffeWithToppings.Model
{
    public abstract class ProductComponent
    {
        public double Price { get; set; }
        public string Description { get; set; }
        
        public ProductComponent(string description, int price)
        {
            this.Price = price;
            this.Description = description;
        }

        public abstract double GetPrice();
    }
}
