using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string item = "";
            int quantity = 0;
            bool isItemValid = false;
            decimal total = 0;
            decimal additionalCost = 0;
            bool repeat;
            string answer;

            drawMenu();

            total = getTotal(item, isItemValid, quantity, total, additionalCost);

            Console.WriteLine("Your current total is £" + total);
            Console.WriteLine("Would you like to buy anything else? (Y/N)");
            answer = Console.ReadLine();

            answer = answer.ToLower();

            if (answer == "n")
            {
                Console.WriteLine("Thank you for shopping with us!");
            }
            else
            {
                Console.WriteLine("Typo");
            }

            while (answer == "y")
            {
                total = getTotal(item, isItemValid, quantity, total, additionalCost);

                Console.WriteLine("Your current total is £" + total);
                Console.WriteLine("Would you like to buy anything else? (Y/N)");
                answer = Console.ReadLine();

                answer = answer.ToLower();

                if (answer == "n")
                {
                    Console.WriteLine("Thank you for shopping with us!");
                }
                else
                {
                    Console.WriteLine("Typo");
                }
            }

            Console.ReadLine();

        }

        static decimal getTotal(string item, bool isItemValid, int quantity, decimal total, decimal additionalCost)
        {

            Console.WriteLine("");
            Console.WriteLine("What would you like to buy?");
            item = Console.ReadLine();

            item = item.ToLower();

            isItemValid = validateString(item);

            if (isItemValid == true)
            {
                quantity = getQuantity(item);

                additionalCost = calculateDiscount(item, quantity);

                total = calculateTotal(total, additionalCost);

            }
            else
            {
                Console.WriteLine("Item does not exist!");
            }

            return total;

        }

        static decimal calculateTotal(decimal total, decimal additonalCost)
        {

            return total + additonalCost;

        }

        static decimal threeForTwo(int quantity, decimal costOfOne)
        {

            decimal cost;
            decimal remainder;

            cost = decimal.Truncate(Convert.ToDecimal(quantity) / 3);
            remainder = decimal.Remainder(quantity, 3);
            cost = cost * 2;

            cost = cost * Convert.ToDecimal(costOfOne);
            cost = cost + (remainder * Convert.ToDecimal(costOfOne));

            
           
            return cost;

        }

        static decimal noDiscount(int quantity, decimal costOfOne)
        {
            return quantity * Convert.ToDecimal(costOfOne);

        }

        static decimal twoForOne(int quantity, decimal costOfOne)
        {

            decimal cost;
            decimal remainder;

            cost = decimal.Truncate(Convert.ToDecimal(quantity) / 2);
            remainder = decimal.Remainder(quantity, 2);

            cost = cost * Convert.ToDecimal(costOfOne);
            cost = cost + (remainder * Convert.ToDecimal(costOfOne));

            

            return cost;

        }

        static decimal thirdOff(int quantity, decimal costOfOne)
        {

            decimal cost;

            cost = Convert.ToDecimal(quantity) * costOfOne;
            cost = cost / 3;
            cost = cost * 2;

            return cost;

        }

        static decimal calculateDiscount(string item, int quantity)
        {
            decimal cost = 0;
            
            switch (item)
            {
                case "banana":
                    cost = threeForTwo(quantity, Convert.ToDecimal(0.5));
                    break;

                case "apple":
                    cost = noDiscount(quantity, Convert.ToDecimal(0.75));
                    break;

                case "orange":
                    cost = twoForOne(quantity, Convert.ToDecimal(1.00));
                    break;

                case "grapes":
                    cost = thirdOff(quantity, Convert.ToDecimal(1.50));
                    break;

            }

            return cost;
        }

        static int getQuantity(string item)
        {
            int quantity = 0;

            Console.WriteLine("How many " + item + " would you like?");

            quantity = Convert.ToInt32(Console.ReadLine());
           
            return quantity;
            
        }

        static bool validateString(string item)
        {
            if (item == "banana" || item == "apple" || item == "orange" || item == "grapes") {

                return true;

            }
            else
            {
                return false;
            }
            
        }

        static void drawMenu()
        {
            Console.WriteLine("                     -MENU-                    ");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Name of item | Banana | Apple | Orange | Grapes");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("   Price     |  £0.50 | £0.75 |  £1.00 |  £1.50");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("    Deal     |3 for 2 |  N/A  | 2 for 1|1/3 Off");
        }

    }

    

}
