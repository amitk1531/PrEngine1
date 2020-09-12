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
            Console.WriteLine("Hello!! - Press any key to continue adding items to your cart...");
            Console.ReadKey(true);

            // Creating Object.
            Cart sku = new Cart();

            int len = sku.unitPrice.Count;
            IDictionary<string, int> numberOfItems = new Dictionary<string, int>();

            // User to enter the number of items added to the cart for each SKU.
            for (int i=0; i < len; i++)
            {
                Console.WriteLine("\nEnter the number of items of {0} ", sku.unitPrice.ElementAt(i).Key);
                try
                {
                    int numOfItems = Convert.ToInt32(Console.ReadLine());

                    // Number of Items should be Non-Negative.
                    if (numOfItems >= 0)
                    {
                        numberOfItems.Add(sku.unitPrice.ElementAt(i).Key, numOfItems);
                    }
                    else
                    {
                        Console.WriteLine("\nPlease Enter Non- Negative Numeric Values\n");
                        Thread.Sleep(1000);
                        i--;
                    }

                    
                }
                catch (Exception)
                {
                    // Error handeling with Retry mechanism - if non-numeric value is entered for the Number of items.
                    Console.WriteLine("\nError!! Please Enter Numeric Values Only\n");
                    Thread.Sleep(1000);
                    i--;
                }                              
            }

            // To apply Promotions and calculate Total Order Value.
            int totalOrderValue = sku.calculateTotalOrderValue(numberOfItems);

            Console.WriteLine("Total Order value : " + totalOrderValue);
            Console.ReadKey();
        }

        public int calculateTotalOrderValue(IDictionary<string, int> numberOfItems)
        {
            int valueOfA = promoAValue(numberOfItems["A"], unitPrice["A"]);
            int valueOfB = promoBValue(numberOfItems["B"], unitPrice["B"]);
            int valueOfCD = promoCDValue(numberOfItems["C"], numberOfItems["D"], unitPrice["C"], unitPrice["D"]);

            return (valueOfA + valueOfB + valueOfCD);
        }

        public int promoAValue(int numA, int price)
        {
            int promoA = numA / 3;
            int remA = numA % 3;

            //Promotion - 3 of A's for 130
            int promotion3A = 130;

            // Applying promotion and calculating total value.
            int value = (promoA * promotion3A) + (remA * price);

            return value;
        }

        public int promoBValue(int numB, int price)
        {
            int promoB = numB / 2;
            int remB = numB % 2;

            //Promotion - 2 of B's for 45
            int promotion2B = 45;

            // Applying promotion and calculating total value.
            int value = (promoB * promotion2B) + (remB * price);

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
