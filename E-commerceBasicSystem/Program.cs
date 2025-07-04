using E_commerceBasicSystem.Classes;
using E_commerceBasicSystem.Interfaces;

namespace E_commerceBasicSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string addResult;
            string checkOutresult;
            // normal case, no errors or edge cases:

            Product cheese = new Product("Cheese", price: 20, quantity: 10)
            {
                shippingInfo = new ShippingDetails(200),
                expirationInfo = new ExpirationDetails(DateTime.Now.AddDays(20)),
            };

            Product milk = new Product("Milk", price: 15, quantity: 14)
            {
                shippingInfo = new ShippingDetails(500),
                expirationInfo = new ExpirationDetails(DateTime.Now.AddDays(3)),
            };
            Product scratchCard = new Product("scratchCard", price: 10, quantity: 20);

            Customer Mostafa = new Customer("Mostafa", currentBalance: 1000);
            addResult = Mostafa.AddToCart(cheese, quantity: 2);
            Console.WriteLine(addResult);
            addResult = Mostafa.AddToCart(milk, quantity: 4);
            Console.WriteLine(addResult);
            addResult = Mostafa.AddToCart(scratchCard, quantity: 5);
            Console.WriteLine(addResult);

            checkOutresult = Mostafa.CheckOut();
            Console.WriteLine(checkOutresult);
            //-------------------------------------------------------------------//
            // products edge and validation cases:
            Console.WriteLine("------------------------------------------- \nproduts edge cases:");
            Customer mostafa = new Customer("Mostafa", 2000);

            // product is of stock :
            Product Tv = new Product("TV", price: 1000, quantity: 0);
            addResult = mostafa.AddToCart(Tv, 1);
            Console.WriteLine(addResult);

            // product is expired :
            Product water = new Product("water", price: 20, quantity: 10)
            {
                expirationInfo = new ExpirationDetails(DateTime.Now),
            };
            addResult = mostafa.AddToCart(water, 2);
            Console.WriteLine(addResult);
            // more quantity than the product's
            addResult = mostafa.AddToCart(cheese, 12);
            Console.WriteLine(addResult);
            // validation errors but at least one prodct is addded to the cart:
            addResult = mostafa.AddToCart(cheese, 6);
            Console.WriteLine(addResult);
            checkOutresult = mostafa.CheckOut();
            Console.WriteLine(checkOutresult);
            //-------------------------------------------------------------------//
            //checkout edge and validations:
            Console.WriteLine("------------------------------------------- \ncheckout edge cases:");
            // empty cart:
            Customer Ali = new Customer("Ali", currentBalance: 1000);
            checkOutresult = Ali.CheckOut();
            Console.WriteLine(checkOutresult);
            // not enought balance:
            Product computer = new Product("computer", price: 2000, quantity: 1);
            addResult = Ali.AddToCart(computer, 1);
            Console.WriteLine(addResult);
            checkOutresult = Ali.CheckOut();
            Console.WriteLine(checkOutresult);
        }
    }
}
