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
        int buyingChance;
        double maxPrice;
        bool boughtLemonade;
        Random randomNumber;

        //constructor
        public Customer(Random randomNumber)
        {
            this.randomNumber = randomNumber;
            maxPrice = randomNumber.Next(10, 101)/100;
            buyingChance = randomNumber.Next(1, 81);
        }

        //methods

        public bool BoughtLemonade
        {
            get => boughtLemonade;
        }

        private void SetBuyingChances(Weather currentWeather, int currentPrice)
        {
            if (currentWeather.IsDry)
            {
                buyingChance += 10;
            }
            if (currentWeather.IsSunny)
            {
                buyingChance += 25;
            }
            if (currentWeather.IsRaining)
            {
                buyingChance -= 30;
            }
            if (currentPrice > maxPrice || buyingChance < 0)
            {
                buyingChance = 0;
            }
        }

        private void Buy(Day currentDay)
        {
            // need to call this method following the SetBuyingObject on all customer objects
            // roll to see if they buy
            // generate randomm number and if it is equal or lower than buying chance then bought = true
            boughtLemonade = false;
            boughtLemonade = true;
        }
    }
}
