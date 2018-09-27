using System;
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
            DisplayRecipe();
            Console.WriteLine("What ingredient would you like to adjust? ");
            for (int j = 0; j < ingredients.Count; j++)
            {
                Console.WriteLine("'" + (j+1) + "'" + ingredients[j] + ", ");
            }
            try
            {
                int checkInput = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Incorrect input! Try again.");
                ChangeRecipe();
            }
            int input = Int32.Parse(Console.ReadLine());

            if (input < 1 || input > ingredients.Count)
            {
                Console.Clear();
                Console.WriteLine("Input out of range! Try again.");
                ChangeRecipe();
            }

            switch(input)
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
            Console.WriteLine("How many " + ingredients[i] + "should there be per pitcher (serves 5 people) \n");
            try
            {
                int checkInput = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Incorrect input! Try again.");
                GetAmount(i);
            }

            int input = Int32.Parse(Console.ReadLine());
            if (input > 0)
            {
                return input;
            }
            else
            {
                GetAmount(i);
            }
            return 0;
        }

    }
}
