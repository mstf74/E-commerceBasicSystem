using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_commerceBasicSystem.Classes
{
    public class ShoppingCart
    {
        private List<Product> productsList;

        public ShoppingCart()
        {
            productsList = new List<Product>();
        }

        /*
         handling the business rules of the add operation here while adding, instead of handling it
         on the checkOut function, assuring no coupling and better performance.
        */

        public string AddToCart(Product product, int quantity)
        {
            string error = ValidateBysinessRules(product, quantity);
            if (error is not null)
                return error;
            Product cartProduct = new Product(product.getName(), product.getprice(), quantity)
            {
                expirationInfo = product.expirationInfo,
                shippingInfo = product.shippingInfo,
            };
            productsList.Add(cartProduct);
            product.setQuantity(product.getQuantity() - quantity);
            return $"{quantity}X of {product.getName()} added sucesfully to the cart";
        }

        public int GetProductCount()
        {
            return productsList.Count;
        }

        public double GetCartBalance()
        {
            double totalBalance = 0.0;
            foreach (var product in productsList)
            {
                totalBalance += product.getprice() * product.getQuantity();
            }
            return totalBalance;
        }

        /*
         handling the ShipAble products using the interface IShippabel instead of ShippingService.
         making the cart class indpendent.
        */
        public string GetShipmentNotice()
        {
            List<Product> shipableProducts = new List<Product>();
            foreach (var product in productsList)
            {
                if (product.shippingInfo is not null)
                    shipableProducts.Add(product);
            }
            if (shipableProducts.Count == 0)
                return null;
            string shipNotice = "\n** Shipment notice **\n";
            double totalWeight = 0.0;
            foreach (var product in shipableProducts)
            {
                int quantity = product.getQuantity();
                double weight = product.shippingInfo.getWeight();
                shipNotice += $"{quantity}X {product.getName()} \t {weight * quantity}g\n";
                totalWeight += weight * quantity;
            }
            shipNotice += $"Total package weight {totalWeight}g\n";
            return shipNotice;
        }

        public string GetCheckoutReceipt()
        {
            string receipt = "\n** Checkout receipt **\n";
            foreach (var product in productsList)
            {
                receipt += $"{product} \t\n";
            }
            return receipt;
        }

        public string GetTotalPrices(ref double currenntBalance)
        {
            double totalPrice = 0.0;
            string total = "------------------------\n";
            foreach (var product in productsList)
            {
                totalPrice += product.getprice() * product.getQuantity();
            }
            currenntBalance -= totalPrice;
            total += $"Subtotal \t{totalPrice}\n";
            total += $"Shipping \t30\n";
            total += $"Amount   \t{totalPrice + 30}\n";
            total += $"Remaining Balance {currenntBalance}\n";
            return total;
        }

        private string ValidateBysinessRules(Product product, int quantity)
        {
            if (product is null || product.getQuantity() == 0)
                return "product is out of stock";
            if (product.getQuantity() < quantity)
                return $"can't add {quantity}X of {product.getName()}, available quantity: {product.getQuantity()}X\n";
            if (product.expirationInfo is not null && product.expirationInfo.isExpired())
                return $"can't add the {product.getName()}, it is expired\n";
            return null;
        }
    }
}
