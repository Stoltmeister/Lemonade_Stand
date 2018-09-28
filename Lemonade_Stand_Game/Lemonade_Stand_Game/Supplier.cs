﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Supplier
    {
        List<Item> products;

        public Supplier(List<Item> products)
        {
            this.products = products;
        }

        public List<Item> Products
        {
            get => products;
        }

        public void SellProduct(Player player)
        {
            bool badInput = true;

            while (badInput)
            {
                Console.WriteLine("You currently have $" + player.Wallet.currentCash + "\n");
                Console.WriteLine("What product would you like? \n");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine((i + 1) + ".) " + products[i] + "\n");
                }
                string input = Console.ReadLine();
                try
                {
                    int inputChecking = Int32.Parse(input);
                    if (inputChecking > 0 && inputChecking < products.Count)
                    {
                        badInput = false;
                        switch (inputChecking)
                        {
                            case 1:
                                SellLemons(player);
                                break;
                            case 2:
                                SellSugar(player);
                                break;
                            case 3:
                                SellIce(player);
                                break;
                            case 4:
                                SellCups(player);
                                break;
                            default:
                                break;
                        }
                    }
                    if (badInput)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect input! Try again. \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again. \n");
                }
            }

        }

        public void SellLemons(Player player)
        {
            int productIndex = 0;
            int quantity;
            bool badInput = true;
            double totalCost;

            while (badInput)
            {
                Console.WriteLine("How many Lemons would you like to buy?");
                string input = Console.ReadLine();
                try
                {
                    quantity = Int32.Parse(input);
                    totalCost = products[productIndex].Price * quantity;

                    if (player.Wallet.currentCash > totalCost)
                    {
                        badInput = false;
                        player.Wallet.currentCash -= totalCost;
                        Console.WriteLine("You just bought " + quantity + " lemons for " + "$" + totalCost + " \n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough cash! Try again. \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again. \n");
                }
            }
        }

        public void SellSugar(Player player)
        {
            int productIndex = 1;
            int quantity;
            bool badInput = true;
            double totalCost;

            while (badInput)
            {
                Console.WriteLine("How many sugar servings would you like to buy?");
                string input = Console.ReadLine();
                try
                {
                    quantity = Int32.Parse(input);
                    totalCost = products[productIndex].Price * quantity;

                    if (player.Wallet.currentCash > totalCost)
                    {
                        badInput = false;
                        player.Wallet.currentCash -= totalCost;
                        Console.WriteLine("You just bought " + quantity + " cups of sugar for " + "$" + totalCost + " \n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough cash! Try again. \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again. \n");
                }
            }
        }

        public void SellIce(Player player)
        {
            int productIndex = 2;
            int quantity;
            bool badInput = true;
            double totalCost;

            while (badInput)
            {
                Console.WriteLine("How many Ice Cubes would you like to buy?");
                string input = Console.ReadLine();
                try
                {
                    quantity = Int32.Parse(input);
                    totalCost = products[productIndex].Price * quantity;

                    if (player.Wallet.currentCash > totalCost)
                    {
                        badInput = false;
                        player.Wallet.currentCash -= totalCost;
                        Console.WriteLine("You just bought " + quantity + " Ice Cubes for " + "$" + totalCost + " \n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough cash! Try again. \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again. \n");
                }
            }
        }

        public void SellCups(Player player)
        {
            int productIndex = 0;
            int quantity;
            bool badInput = true;
            double totalCost;

            while (badInput)
            {
                Console.WriteLine("How many cups would you like to buy?");
                string input = Console.ReadLine();
                try
                {
                    quantity = Int32.Parse(input);
                    totalCost = products[productIndex].Price * quantity;

                    if (player.Wallet.currentCash > totalCost)
                    {
                        badInput = false;
                        player.Wallet.currentCash -= totalCost;
                        Console.WriteLine("You just bought " + quantity + " cups for " + "$" + totalCost + " \n");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough cash! Try again. \n");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again. \n");
                }
            }
        }
    }
}
