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
        List<Item> products;
        List<int> amounts; // all items in products list, get

        //constructor
        public Inventory()
        {
            products = new List<Item>();
            amounts = new List<int>();
        }

        //methods

        // REWORK ****
        public void DisplayInventory()
        {
            string inventory = "You currently have: ";
            for (int i = 0; i < amounts.Count; i++)
            {
                inventory += amounts[i] + " " + products[i] + " \n";
            }

            Console.WriteLine(inventory);
        }

        public void AddProducts(Item product, int amount)
        {
            string allItems = "";

            for (int i = 0; i < amount; i++)
            {
                products.Add(product);
            }
        }
    }
}
