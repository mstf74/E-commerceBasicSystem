using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace E_commerceBasicSystem.Classes
{
    public class Customer
    {
        public string name { get; set; }
        public double currentBalance;
        private ShoppingCart cart;

        public Customer(string name, double currentBalance)
        {
            this.name = name;
            this.currentBalance = currentBalance;
            cart = new ShoppingCart();
        }

        /*
        using the abstracted add to cart function on the cart class,
        that makes the user only manages their own cart.
       */

        public string AddToCart(Product product, int quantity)
        {
            string result = cart.AddToCart(product, quantity);
            return result;
        }

        public string CheckOut()
        {
            var error = ValidateBusinessRules();
            if (error is not null)
                return error;
            string receipt = "";
            string shipmentDetails = cart.GetShipmentNotice();
            if (shipmentDetails is not null)
                receipt += shipmentDetails;
            receipt += cart.GetCheckoutReceipt();
            receipt += cart.GetTotalPrices(ref currentBalance);
            return receipt;
        }

        private string ValidateBusinessRules()
        {
            if (cart.GetProductCount() <= 0)
                return "can't Check Out, the cart is empty\n";
            if (cart.GetCartBalance() > currentBalance)
                return $"can't Check out, your current balance isn't enough,\n"
                    + $"your balance: {currentBalance}, cart balance: {cart.GetCartBalance()}\n";
            return null;
        }
    }
}
