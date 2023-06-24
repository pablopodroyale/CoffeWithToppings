using CoffeWithToppings.Model;

namespace CoffeWithToppingsTest
{
    public class Tests
    {
        [Test]
        [TestCase(new Object[] { "Cofee", "Mocca", "Milk", "Vanilla" }, new int[] { 5, 2, 1, 3 }, 11 )]
        [TestCase(new Object[] { "Cofee"}, new int[] { 5 }, 5)]
        [TestCase(new Object[] { "Cofee", "Mocca" }, new int[] { 5, 2}, 7)]
        [TestCase(new Object[] { "Cofee", "Mocca", "Milk" }, new int[] { 5, 2, 1 }, 8)]
        public void CoffeeTestsOneComposite(Object[] names, int[] prices , double priceExpected)
        {
            ProductComposite? product = null;
            ProductLeaf? leaf = null;

            for (int i = 0; i < names.Length; i++) 
            {
                if (i == 0)
                {
                    product = new ProductComposite(names[i].ToString(), prices[i]);
                }
                else
                {
                    leaf = new ProductLeaf(names[i].ToString(), prices[i]);
                    product.Add(leaf);
                }
            }
            
            double priceResult = product.GetPrice();
            Assert.That(priceResult, Is.EqualTo(priceExpected));
        }

        [Test]
        //Customer: I'd like a coffee with almond milk and vanilla, please
        [TestCase(new Object[] { "Coffee", "Milk", "AlmondMilk", "Vanilla" }, new int[] { 5, 2, 1, 3 }, 11)]
        public void CoffeeTestsTwoComposites(Object[] names, int[] prices, double priceExpected)
        {
            ProductComposite? firstComposite = null;
            ProductComposite? secondComposite = null;
            ProductLeaf? leaf = null;

            for (int i = 0; i < names.Length; i++)
            {
                if (i == 0)
                {
                    firstComposite = new ProductComposite(names[i].ToString(), prices[i]);
                }
                else if (i == 1)
                {
                    secondComposite = new ProductComposite(names[i].ToString(), prices[i]);
                }
                else if (i == 2) 
                {
                    leaf = new ProductLeaf(names[i].ToString(), prices[i]);
                    secondComposite.Add(leaf);
                    firstComposite.Add(secondComposite);
                }
                else
                {
                    leaf = new ProductLeaf(names[i].ToString(), prices[i]);
                    firstComposite.Add(leaf);
                }
            }

            double priceResult = firstComposite.GetPrice();
            Assert.That(priceResult, Is.EqualTo(priceExpected));
        }

        [Test]
        //Customer: I'd like a double hamburguer with cheddar, blue cheese, bacon, tomato and caramel onion with french fries
        //Another strategy is to set $0 to composites and only set the priceto the leafs
        public void FrenchHamburguerComboTest ()
        {
            ProductComposite frenchCombo = new ProductComposite("French Combo", 0);
            ProductComposite doubleHambuerguer = new ProductComposite("Double Hamburguer", 5);
            ProductComposite cheese = new ProductComposite("Cheese", 0);
            ProductLeaf blueCheese = new ProductLeaf("Blue cheese", 5);
            ProductLeaf bacon = new ProductLeaf("Bacon", 1);
            ProductLeaf tomato = new ProductLeaf("Tomato", 1);
            ProductComposite onion = new ProductComposite("Onion", 0);
            ProductLeaf caramelOnion = new ProductLeaf("Caranel Onion", 2);
            ProductComposite fries = new ProductComposite("Fries", 0);
            ProductLeaf frenchFries = new ProductLeaf("French Fries", 2);


            cheese.Add(blueCheese);
            onion.Add(caramelOnion);
            fries.Add(frenchFries);
            doubleHambuerguer.Add(cheese);
            doubleHambuerguer.Add(onion);
            doubleHambuerguer.Add(bacon);
            doubleHambuerguer.Add(tomato);
            frenchCombo.Add(doubleHambuerguer);
            frenchCombo.Add(frenchFries);
            double priceResult = frenchCombo.GetPrice();
            Assert.That(priceResult, Is.EqualTo(16));
        }
    }
}