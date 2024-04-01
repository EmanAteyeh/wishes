using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryManagement
{
    public class Product
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private Price Price { get; set; }
        private int Quantity { get; set; }


        public Price price { get; set; }

        public int id
        {
            get { return Id; }
            set
            {
                Id = value;
            }
        }
        public string name
        {
            get { return Name; }
            set
            {
                Name = value.Length > 50 ? value[..50] : value; //truncate the string if its length execeeds 50 characters.  
            }
        }

        public Price productPrice
        {
            get
            {
                return Price;
            }
            set { Price = value; }
        }

        public int quantity
        {
            get { return Quantity; }
            set
            {
                Quantity = value;
            }
        }


        public Product(int id, string name, Price price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public void toString()
        {
            {
                Console.WriteLine($"ID: {Id}, Name: {Name}, Price: {price}, Quantity: {Quantity}");
            }
        }

    }
}
