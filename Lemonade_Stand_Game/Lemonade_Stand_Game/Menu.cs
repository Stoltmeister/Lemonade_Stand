using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    static class Menu
    {
        public static int DisplayMainMenu()
        {
            bool badInput = true;
            int numberInput = 1;

            while (badInput)
            {
                Console.WriteLine("What would you like to do? " +
                "'1' = Show tomorrows forecast, '2' = Show full week forecast, '3' = Change Recipe \n" +
                "'4' = Buy Supplies, '5' = Change Price, '6' = Open for the Day");
                string input = Console.ReadLine();
                try
                {
                    int inputCheck = Int32.Parse(input);
                    if (inputCheck <= 6 && inputCheck >= 1)
                    {
                        badInput = false;
                        return inputCheck;
                    }
                    else 
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect input please try again! \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input please try again! \n");
                }                
            }
            return numberInput;
        }
    }
}
