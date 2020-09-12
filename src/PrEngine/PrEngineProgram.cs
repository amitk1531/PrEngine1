using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

            int len = sku.unitPrice.Count;
            IDictionary<string, int> numberOfItems = new Dictionary<string, int>();

            // Fetching the number of items for each SKU.
            for (int i=0; i < len; i++)
            {
                Console.WriteLine("\nEnter the number of items of {0} ", sku.unitPrice.ElementAt(i).Key);
                numberOfItems.Add(sku.unitPrice.ElementAt(i).Key, Convert.ToInt32(Console.ReadLine()));                
            }

            Console.ReadKey();
        }
    }
}
