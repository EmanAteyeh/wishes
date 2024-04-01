using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagement
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();


        public void AddProduct(string name, Price price, int quantity)
        {
            products.Add(new Product(products.Count + 1, name, price, quantity));

            if (quantity > 1)
            {
                checkSuffix(name);
                string updatedName = checkSuffix(name);
                Console.WriteLine($"{quantity} {updatedName} were added successfully.");
            }
            else
            {
                Console.WriteLine($"{quantity} {name} was added successfully.");


            }
        }
        public string checkSuffix(string name) //takes full name
        {
            string newName = "";

            string suffix = name.Substring(name.Length - 2, 2);
            if (name.EndsWith("sh") || name.EndsWith("ch") || name.EndsWith("s") || name.EndsWith("x") || name.EndsWith("z"))
            {
                newName = $"{name}es";
            }
            else
            {
                newName = $"{name}s";
            }
            return newName;
        }

        public void ViewAllProducts()
        {
            Console.WriteLine("\nAll products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.id}, Name: {product.name}, Price: {product.productPrice}, Quantity: {product.quantity}");
            }
        }

        public void EditProduct()
        {
            Product p = findProduct();
            if (p != null)
            {
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Price");
                Console.WriteLine("3. Quantity");
                Console.WriteLine("4. All of the above");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write($"Enter a new name for {p.name}: ");
                        p.name = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new price: ");
                        double price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Select currency:");
                        foreach (Currency currency in Enum.GetValues(typeof(Currency)))
                        {
                            Console.WriteLine($"{(int)currency}. {currency}");
                        }
                        Console.Write("Enter currency: ");
                        int currencyChoice = int.Parse(Console.ReadLine());
                        Currency selectedCurrency = (Currency)currencyChoice;
                        p.price = new Price(price, selectedCurrency);
                        break;
                    case 3:
                        Console.Write("Enter new quantity: ");
                        p.quantity = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Enter new name: ");
                        p.name = Console.ReadLine();
                        Console.Write("Enter new price: ");
                        double newPrice = double.Parse(Console.ReadLine());
                        Console.WriteLine("Select currency:");
                        foreach (Currency currency in Enum.GetValues(typeof(Currency)))
                        {
                            Console.WriteLine($"{(int)currency}. {currency}");
                        }
                        Console.Write("Enter currency: ");
                        int newCurrencyChoice = int.Parse(Console.ReadLine());
                        Currency newSelectedCurrency = (Currency)newCurrencyChoice;
                        p.price = new Price(newPrice, newSelectedCurrency);

                        Console.Write("Enter new quantity: ");
                        p.quantity = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public Product findProduct()
        {
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Product product = products.Find(p => p.name == productName);
            return product;
        }
        public Product findProduct(string productName)
        {

            Product product = products.Find(p => p.name == productName);
            return product;
        }
        public void DeleteProduct()
        {
            Console.WriteLine("\nDeleting a product:");
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Product product = products.Find(p => p.name == productName);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void SearchProduct()
        {
            Console.WriteLine("\nSearching for a product:");
            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();
            Product product = findProduct(productName);
            if (product != null)
            {
                Console.WriteLine($"ID: {product.id}, Name: {product.name}, Price: {product.price}, Quantity: {product.quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }


    }
}