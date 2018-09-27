using System;
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
            Console.WriteLine("What product would you like? \n");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(i + ".) " + products[i] + "\n");
            }
            string input = Console.ReadLine();
            // make a function for these try-catch input checking?
            try
            {
                int inputChecking = Int32.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect input! Try again. \n");
                SellProduct(player);
            }
            int productIndex = Int32.Parse(input);
            if (productIndex < 0 || productIndex > products.Count)
            {
                Console.WriteLine("Please enter a number between 0 and " + (products.Count - 1) + "\n");
                SellProduct(player);
            }


            Console.WriteLine("How many units of " + products[productIndex] + " would you like?");
            input = Console.ReadLine();
            try
            {
                int inputChecking = Int32.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect input! Start over. \n");
                SellProduct(player);
            }
            int quantity = Int32.Parse(input);
            player.Wallet.currentCash -= products[productIndex].Price * quantity;
           // player.Store.Inventory.

        }
    }
}
