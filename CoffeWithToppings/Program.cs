// See https://aka.ms/new-console-template for more information
using CoffeWithToppings.Model;

ProductComposite coffee = new ProductComposite("Coffee", 5);
ProductLeaf mocca = new ProductLeaf("Mocca", 2);
ProductLeaf milk = new ProductLeaf("Milk", 1);
ProductLeaf vanilla = new ProductLeaf("Vanilla", 3);

coffee.Add(mocca);
coffee.Add(milk);
coffee.Add(vanilla);

Console.WriteLine(coffee.GetPrice());
Console.ReadLine();



