using InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryManagementSystem
{
    public class Initialize
    {
        public string newName;
        public Price newPrice;
        public Currency newCurrency;
        public int quantity;
        public static void initializer()
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
        }

        public void instantiatingProduct()
        {

            this.newName = enterProductName();
            this.newCurrency = enterCurrency();
            this.newPrice = enterPrice(newCurrency);
            this.quantity = enterQuantity();

        }

        public static String enterProductName()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static Price enterPrice(Currency currency)
        {
            Console.Write("Enter product price: ");
            double priceValue = double.Parse(Console.ReadLine());
            Price price = new Price(priceValue, currency);
            return price;
        }
        public static Currency enterCurrency()
        {
            Console.WriteLine("Select currency:");
            foreach (Currency currency in Enum.GetValues(typeof(Currency)))
            {
                Console.WriteLine($"{(int)currency}. {currency}");
            }

            Currency selectedCurrency = Currency.USD_Dollar;
            bool isValidCurrency = false;
            do
            {
                Console.Write("Enter currency  ");
                if (int.TryParse(Console.ReadLine(), out int currencyChoice))
                {
                    if (Enum.IsDefined(typeof(Currency), currencyChoice))
                    {
                        selectedCurrency = (Currency)currencyChoice;
                        isValidCurrency = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid currency");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid currency");
                }
            } while (!isValidCurrency);

            return selectedCurrency;
        }
        public static int enterQuantity()
        {
            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            return quantity;
        }
    }
}
