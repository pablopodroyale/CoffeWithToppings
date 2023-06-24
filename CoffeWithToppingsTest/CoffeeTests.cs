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
        [TestCase(new Object[] { "Cofee", "Milk", "AlmondMilk", "Vanilla" }, new int[] { 5, 2, 1, 3 }, 11)]
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
    }
}