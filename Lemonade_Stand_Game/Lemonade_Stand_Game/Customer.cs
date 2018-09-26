using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Customer
    {
        //member variables
        double buyingChance;
        double maxPrice;
        bool boughtLemonade;
        Random randomNumber;

        //constructor
        public Customer(Random randomNumber)
        {
            this.randomNumber = randomNumber; 
        }

        //methods

        public bool BoughtLemonade
        {
            get => boughtLemonade;
        }

        private void SetBuyingChances(Weather currentWeather, int currentPrice)
        {
            //if (currentWeather.)
        }

        private void Buy(Day currentDay)
        {
            // roll to see if they buy            
        }
    }
}
