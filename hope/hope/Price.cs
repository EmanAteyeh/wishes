using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement

{
    public class Price
    {
        public double ItemPrice { get; set; }
        public Currency Currency { get; set; }

        public Price(double price, Currency currency)
        {
            this.ItemPrice = price;
            this.Currency = currency;
        }
        public override string ToString()
        {
            return $"{ItemPrice} {Currency}";
        }

    }
}
