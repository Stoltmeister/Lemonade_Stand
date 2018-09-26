using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Store
    {
        //member variables
        double currentPrice; 
        int[] recipe;
        double startingCash;
        double currentCash;

        //constructor
        public Store()
        {
            startingCash = 20.00;
            currentCash = startingCash;
            recipe = new int[] { 5, 5, 5 };
        }
        //methods

        private void ChangeRecipe()
        {
            // add after MVP
        }

        private void SetPrice(double newPrice)
        {
            // max 1 dollar, lowest 1 cent 
            if (newPrice > 1.00)
            {
                currentPrice = 1.00;
            }
            else if (newPrice < .01)
            {
                currentPrice = .01;
            }
            else
            {
                currentPrice = newPrice;
            }
        }

        public void DisplayStore()
        {
            Console.WriteLine("Your current recipe ratio is " + recipe + " (lemons, cups of sugar, and ice cubes) \n");
            Console.WriteLine("Current price per cup is set to $" + currentPrice + "\n");
            Console.WriteLine("Total cash available is $" + currentCash + "\n");
        }
    }
}
