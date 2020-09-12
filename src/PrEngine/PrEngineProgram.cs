using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrEngine
{
    public class Cart
    {
        IDictionary<string, int> unitPrice = new Dictionary<string, int>();
        public Cart()
        {
            unitPrice.Add("A", 50);
            unitPrice.Add("B", 30);
            unitPrice.Add("C", 20);
            unitPrice.Add("D", 15);
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello!! - Press any key to continue adding to your cart...");
            Console.ReadKey(true);

            // Creating Object.
            Cart sku = new Cart();

            Console.WriteLine(sku.unitPrice.ElementAt(0));
            Console.ReadKey();
        }
    }
}
