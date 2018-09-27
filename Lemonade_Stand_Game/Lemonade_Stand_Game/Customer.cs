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
        int dryFactor;
        int rainFactor;
        int sunFactor;
        int forecastFactor;
        int temperatureFactor;

        //constructor
        public Customer(Random randomNumber)
        {
            this.randomNumber = randomNumber;
            maxPrice = randomNumber.Next(10, 101)/100;
            buyingChance = randomNumber.Next(1, 81);
            dryFactor = 10;
            rainFactor = -50;
            sunFactor = 30;
            forecastFactor = 20;
            temperatureFactor = 20;
        }

        //methods

        public bool BoughtLemonade
        {
            get => boughtLemonade;
        }

        private void SetBuyingChances(Player player, Day day, List<Weather> weeklyForecast)
        {
            if (day.TodaysWeather.IsDry)
            {
                buyingChance += dryFactor;
            }
            if (day.TodaysWeather.IsSunny)
            {
                buyingChance += sunFactor;
            }
            if (day.TodaysWeather.IsRaining)
            {
                buyingChance += rainFactor;
            }
            if (weeklyForecast[day.DayNumber].IsRaining && !day.TodaysWeather.IsRaining)
            {
                buyingChance -= forecastFactor;
            }
            else if (weeklyForecast[day.DayNumber].IsSunny && !day.TodaysWeather.IsDry)
            {
                buyingChance += forecastFactor;
            }
            if (day.TodaysWeather.Temperature > 85)
            {
                buyingChance += temperatureFactor;
            }
            if (day.TodaysWeather.Temperature > 70)
            {
                buyingChance += temperatureFactor;
            }
            if (day.TodaysWeather.Temperature < 60)
            {
                buyingChance -= temperatureFactor;
            }
            if (day.TodaysWeather.Temperature < 45)
            {
                buyingChance -= temperatureFactor;
            }
            if (player.Store.CurrentPrice > maxPrice || buyingChance < 0)
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
