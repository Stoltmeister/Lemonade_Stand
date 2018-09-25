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
        int lemons;
        int cupsOfSugar;
        int iceCubes;

        //constructor
        public Inventory()
        {
            lemons = 0;
            cupsOfSugar = 0;
            iceCubes = 0;
        }

        //methods

        private void DisplayInventory()
        {
            Console.WriteLine("You currently have: " +
                lemons + " lemons \n" +
                cupsOfSugar + " cups of sugar \n" +
                iceCubes + " ice cubes \n");
        }
        
        private void AddSupplies(int amount, int itemNumber)
        {
            if (itemNumber == 1)
            {
                lemons += amount;
            }
            else if (itemNumber == 2)
            {
                cupsOfSugar += amount;
            }
            else if (itemNumber == 3)
            {
                iceCubes += amount;
            }
            else
            {
                Console.WriteLine("error error");
            }
        }
    }
}
