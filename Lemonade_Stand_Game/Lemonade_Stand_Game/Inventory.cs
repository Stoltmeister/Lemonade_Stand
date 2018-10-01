using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Inventory
    {
        //member variables
        List<Item> allProducts;
        List<int> amounts;
        List<Item> itemTypes;
        int totalPitchers;
        //constructor
        public Inventory()
        {
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
            Cup cup = new Cup();
            itemTypes = new List<Item>() { lemon, sugar, ice, cup };
            allProducts = new List<Item>();
            amounts = new List<int>() { 0, 0, 0, 0 };
        }

        //methods
        public int TotalPitchers
        {
            get => totalPitchers;
        }

        public void SetAmounts()
        {
            int count = 0;
            for (int i = 0; i < itemTypes.Count; i++)
            {
                for (int j = 0; j < allProducts.Count; j++)
                {
                    if (itemTypes[i].GetType() == allProducts[j].GetType())
                    {
                        count++;
                    }
                }
                amounts[i] = count;
                count = 0;
            }
        }

        public void CalculateTotalPitchers(Recipe recipe)
        {
            SetAmounts();
            double lemonsAvailable = amounts[0] / recipe.Amounts[0];
            double sugarAvailable = amounts[1] / recipe.Amounts[1];
            double iceAvailable = amounts[2] / recipe.Amounts[2];
            double cupsAvailable = amounts[3] / 5;
            double[] itemsAvailable = { lemonsAvailable, sugarAvailable, iceAvailable, cupsAvailable };

            totalPitchers = Convert.ToInt32(Math.Floor(itemsAvailable.Min()));
        }

        public int UpdateInventory(int totalCustomers, Recipe recipe)
        {
            int neededPitchers = totalCustomers / 5;

            if (neededPitchers > totalPitchers)
            {
                totalCustomers = totalPitchers / 5;
                for (int i = 0; i < amounts.Count - 1; i++)
                {
                    RemoveProducts(itemTypes[i], recipe.Amounts[i] * totalCustomers);
                }
                return totalCustomers;
            }
            else
            {
                for (int i = 0; i < amounts.Count - 1; i++)
                {
                    RemoveProducts(itemTypes[i], recipe.Amounts[i] * TotalPitchers);
                }
                return totalCustomers;
            }
        }

        public void RemoveProducts(Item product, int amount)
        {
            for (int i = 0; i < allProducts.Count(); i++)
            {
                if (allProducts[i].GetType() == product.GetType() && amount > 0)
                {
                    allProducts.RemoveAt(i);
                    amount--;
                }
            }
            SetAmounts();
        }

        public void DisplayInventory()
        {
            SetAmounts();
            string inventory = "You currently have: \n \n";

            for (int i = 0; i < itemTypes.Count; i++)
            {
                inventory += "- " + amounts[i] + " " + itemTypes[i] + "\n";
            }            
            Console.WriteLine(inventory);
        }

        public void AddProducts(Item product, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                allProducts.Add(product);
            }
            SetAmounts();
        }
    }
}
