using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Wallet
    {
        double startingCash;
        double currentCash;
        double totalProfit;

        public Wallet(double startingCash)
        {
            this.startingCash = startingCash;
            currentCash = startingCash;
        }

        public void getTotalProfit()
        {
            totalProfit = currentCash - startingCash;
        }
    }
}
