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


    }
}