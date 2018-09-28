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
        public double currentCash;
        double totalProfit;

        public Wallet(double startingCash)
        {
            this.startingCash = startingCash;
            currentCash = startingCash;
        }

        public double StartingCash
        {
            get => startingCash;
        }

        public double GetTotalProfit
        {
            get => totalProfit;
        }
       
        public void CalculateTotalProfit()
        {
            totalProfit = currentCash - startingCash;
        }
    }
}
