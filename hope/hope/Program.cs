using InventoryManagement;
using System;

namespace InventoryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            while (true)
            {
                Initialize.initializer();

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Initialize newProduct = new Initialize();
                        newProduct.instantiatingProduct();

                        inventory.AddProduct(newProduct.newName, newProduct.newPrice, newProduct.quantity);
                        break;
                    case 2:
                        inventory.ViewAllProducts();
                        break;
                    case 3:
                        inventory.EditProduct();
                        break;
                    case 4:
                        inventory.DeleteProduct();
                        break;
                    case 5:
                        inventory.SearchProduct();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                        break;
                }
            }
        }
    }
}
