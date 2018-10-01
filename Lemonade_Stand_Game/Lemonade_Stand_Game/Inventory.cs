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

            if (amounts[0] < amounts[1] && amounts[0] < amounts[2])
            {
                totalPitchers = amounts[0] / recipe.Amounts[0];
            }
            else if (amounts[1] < amounts[0] && amounts[1] < amounts[2])
            {
                totalPitchers = amounts[1] / recipe.Amounts[1];
            }
            else
            {
                totalPitchers = amounts[0] / recipe.Amounts[0];
            }
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
        }

        public void DisplayInventory()
        {
            int count = 1;
            List<Type> checkedTypes = new List<Type>();
            string inventory = "You currently have: ";
            for (int i = 0; i < allProducts.Count; i++)
            {
                for (int j = i + 1; j < allProducts.Count; j++)
                {
                    if (allProducts[i].GetType() == allProducts[j].GetType())
                    {
                        if (!checkedTypes.Contains(allProducts[i].GetType()))
                        {
                            count++;
                        }
                    }
                }
                if (count > 1)
                {
                    checkedTypes.Add(allProducts[i].GetType());
                    inventory += count + " " + allProducts[i] + "s \n";
                    count = 1;
                }
            }
            Console.WriteLine(inventory);
        }

        public void AddProducts(Item product, int amount)
        {
            for (int i = 0; i < itemTypes.Count; i++)
            {
                allProducts.Add(product);
            }
            SetAmounts();
            DisplayInventory();
        }
    }
}
