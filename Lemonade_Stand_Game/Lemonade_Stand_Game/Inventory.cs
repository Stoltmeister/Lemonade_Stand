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
        List<int> amounts; // all items in products list, get
        List<Type> checkedTypes;
        //constructor
        public Inventory()
        {
            allProducts = new List<Item>();
            amounts = new List<int>();
        }

        //methods

        // REWORK ****
        public void DisplayInventory()
        {
            int count = 1;
            checkedTypes = new List<Type>();
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
            for (int i = 0; i < amount; i++)
            {
                allProducts.Add(product);
            }
            DisplayInventory();
        }
    }
}
