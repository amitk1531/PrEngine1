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

            // To apply Promotions and calcute Total Order Value.
            int totalOrderValue = sku.calculateTotalOrderValue(numberOfItems);

            Console.WriteLine("Total Order value is : " + totalOrderValue);
            Console.ReadKey();
        }

        public int calculateTotalOrderValue(IDictionary<string, int> numberOfItems)
        {
            int numA = numberOfItems["A"];
            int numB = numberOfItems["B"];
            int numC = numberOfItems["C"];
            int numD = numberOfItems["D"];

            int valueOfA = promoAValue(numA, unitPrice["A"]);
            int valueOfB = promoBValue(numB, unitPrice["B"]);
            int valueOfCD = promoCDValue(numC, numD, unitPrice["C"], unitPrice["D"]);

            return (valueOfA + valueOfB + valueOfCD);
        }

        public int promoAValue(int a, int price)
        {
            int promoA = a / 3;
            int remA = a % 3;

            //Promotion - 3 of A's for 130
            int promotion3A = 130;

            // Applying promotion and calculating total value.
            int value = (promoA * promotion3A) + (remA * price);

            return value;
        }

        public int promoBValue(int b, int price)
        {
            int promoB = b / 2;
            int remB = b % 2;

            //Promotion - 2 of B's for 45
            int promotion2b = 45;

            // Applying promotion and calculating total value.
            int value = (promoB * promotion2b) + (remB * price);

            return value;
        }


        public int promoCDValue(int numC, int numD, int priceC, int priceD)
        {
            //Promotion - Pair of C & D for 30
            int promotionCD = 30;

            // Applying promotion and calculating total value.
            int value = 0;
            if (numC == numD)
            {
                value = numC * promotionCD;
            }
            else if (numC == 0 || numD == 0)
            {
                value = (numC * priceC) + (numD * priceD);
            }
            else
            {
                if (numC > numD)
                {
                    value = (numD * promotionCD) + ((numC - numD) * priceC);
                }
                else if (numD > numC)
                {
                    value = (numC * promotionCD) + ((numD - numC) * priceD);
                }
            }


            return value;
        }
    }
}
