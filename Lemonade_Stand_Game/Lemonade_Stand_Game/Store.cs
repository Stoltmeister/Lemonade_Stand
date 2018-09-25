using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Store
    {
        //member variables
        double currentPrice;
        int[] recipe;
        double startingCash;
        double currentCash;

        //constructor
        public Store()
        {
            startingCash = 20.00;
            currentCash = startingCash;
            recipe = [5, 5, 5];
        }
        //methods

        private void ChangeRecipe()
        {
            // add later
        }
    }
}
