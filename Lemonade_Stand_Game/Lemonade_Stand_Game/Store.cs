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
        Recipe recipe;
        double costPerPitcher;
        Inventory inventory;

        //constructor
        public Store()
        {
            recipe = new Recipe();
            inventory = new Inventory();
            currentPrice = .25;
        }

        //methods
        public double CurrentPrice
        {
            get => currentPrice;
        }

        public Inventory Inventory
        {
            get => inventory;
        }        
        public Recipe Recipe
        {
            get => recipe;
        }        

        public void SetPrice(double newPrice)
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

        public void DisplayStore(Player currentPlayer)
        {
            Console.WriteLine("Your current recipe ratio is " + recipe + " (lemons, cups of sugar, and ice cubes) \n"); // edit
            Console.WriteLine("Current price per cup is set to $" + currentPrice + "\n");
            Console.WriteLine("Total cash available is $" + currentPlayer.Wallet.currentCash + "\n");
        }

    }
}
