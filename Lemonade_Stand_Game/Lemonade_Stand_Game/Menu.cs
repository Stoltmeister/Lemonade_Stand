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
            Console.WriteLine("What would you like to do? " +
                "'1' = Show tomorrows forecast, '2' = Show full week forecast, '3' = Change Recipe \n" +
                "'4' = Buy Supplies, '5' = Open for the Day");
            try
            {
                int inputCheck = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Incorrect input please try again! \n");
                DisplayMainMenu();
            }
            int input = Int32.Parse(Console.ReadLine());

            if (input > 5 || input < 1)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number between 1-5 \n");
                DisplayMainMenu();
            }
            return input;
        }
    }
}
