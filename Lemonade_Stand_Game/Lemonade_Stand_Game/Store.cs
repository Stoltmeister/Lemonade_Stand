﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Store
    {
        double currentPrice;
        Recipe recipe;
        Inventory inventory;

        public Store()
        {
            recipe = new Recipe();
            inventory = new Inventory();
            currentPrice = .25;
        }

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

        public double ChangePrice(Player player)
        {
            string input = "";
            do
            {
                Console.WriteLine("Current Price Per Cup: $" + player.Store.CurrentPrice + "\n");
                Console.WriteLine("Would you like to change the price? ('y'/'n')");
                input = Console.ReadLine();
            } while (input.ToLower() != "y" && input.ToLower() != "n");

            if (input.ToLower() == "y")
            {
                double numberInput = 0;
                do
                {
                    Console.WriteLine("Enter a new price between $.01 - $1 : ");
                    input = Console.ReadLine();
                    try
                    {
                        numberInput = double.Parse(input);
                        if (numberInput < 0 || numberInput > 1)
                        {
                            Console.WriteLine("Make sure the price is between .01 - 1 \n");
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input, please try again.");
                    }
                } while (numberInput < .01 || numberInput > 1);

                numberInput = double.Parse(input);
                return numberInput;
            }
            else
            {
                return 0;
            }
        }

        // not used
        public void DisplayStore(Player currentPlayer)
        {
            Console.WriteLine("Your current recipe ratio is " + recipe + " (lemons, cups of sugar, and ice cubes) \n"); 
            Console.WriteLine("Current price per cup is set to $" + currentPrice + "\n");
            Console.WriteLine("Total cash available is $" + currentPlayer.Wallet.currentCash + "\n");
        }

    }
}
