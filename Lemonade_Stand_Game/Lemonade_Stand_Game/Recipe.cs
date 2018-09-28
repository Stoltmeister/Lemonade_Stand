﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Recipe
    {
        List<Item> ingredients;
        List<int> amounts;
        double costPerPitcher;

        public Recipe()
        {
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
            ingredients = new List<Item> { lemon, sugar, ice };
            amounts = new List<int> { 3, 3, 3 };
            costPerPitcher = CalculateCostPerPitcher();
        }

        public List<int> Amounts
        {
            get => amounts;
        }
        public List<Item> Ingredients
        {
            get => ingredients;
        }
        public double CostPerPitcher
        {
            get => costPerPitcher;
        }

        public double CalculateCostPerPitcher()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                costPerPitcher += ingredients[i].Price * amounts[i];
            }

            return costPerPitcher;
        }

        public void DisplayRecipe()
        {
            string recipe = "";
            for (int i = 0; i < ingredients.Count; i++)
            {
                recipe += amounts[i] + " " + ingredients[i] + " \n";
            }
            Console.WriteLine("The current recipe is " + recipe + "/n");
        }
        public void ChangeRecipe()
        {
            bool badInput = true;
            int goodInput = 1;

            while (badInput)
            {
                DisplayRecipe();
                Console.WriteLine("What ingredient would you like to adjust? ");
                for (int j = 0; j < ingredients.Count; j++)
                {
                    Console.WriteLine("'" + (j + 1) + "'" + ingredients[j].ToString() + ", ");
                }
                string input = Console.ReadLine();
                try
                {
                    int numberInput = Int32.Parse(input);
                    if (numberInput > 0 || numberInput < ingredients.Count)
                    {
                        badInput = false;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect input! Try again.");
                }
                if (!badInput)
                {
                    goodInput = Int32.Parse(input);
                }                
            }

            switch (goodInput)
            {
                case 1:
                    amounts[0] = GetAmount(0);
                    break;
                case 2:
                    amounts[1] = GetAmount(1);
                    break;
                case 3:
                    amounts[2] = GetAmount(2);
                    break;
            }

        }

        private int GetAmount(int i)
        {
            
            bool badInput = true;

            while (badInput)
            {
                Console.WriteLine("How many " + ingredients[i] + "should there be per pitcher (serves 5 people) \n");
                string input = Console.ReadLine();
                try
                {
                    int checkInput = Int32.Parse(Console.ReadLine());
                    if (checkInput > 0 && checkInput < 10)
                    {
                        return checkInput;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number between '1' - '10'! Try again. \n");                    
                }
            }
            return 0;
        }

    }
}
