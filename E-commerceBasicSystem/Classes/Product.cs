using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_commerceBasicSystem.Interfaces;

namespace E_commerceBasicSystem.Classes
{
    public class Product
    {
        /*
        adding nullable objects of the interfaces to handle the optional shipping or expiration treats,
        and allowing me to add features (new interfaces) without updating the product class
       */
        private string name;
        private double price;
        private int quantity;

        public IExpirable? expirationInfo { get; set; }
        public IShippable? shippingInfo { get; set; }

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            string info = $"{quantity}X {name}";
            if (shippingInfo is not null)
                info += $" \t {shippingInfo.getWeight()}g";
            return info;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public string getName()
        {
            return name;
        }

        public double getprice()
        {
            return price;
        }

        public int getQuantity()
        {
            return quantity;
        }
    }
}
