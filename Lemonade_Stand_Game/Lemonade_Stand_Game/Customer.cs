using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Customer
    {
        int buyingChance;
        double maxPrice;
        bool boughtLemonade;
        Random randomNumber;
        int dryFactor;
        int rainFactor;
        int sunFactor;
        int forecastFactor;
        int temperatureFactor;
        int sweetnessFactor;

        public Customer(Random randomNumber)
        {
            this.randomNumber = randomNumber;
            boughtLemonade = false;
            maxPrice = randomNumber.Next(10, 101);
            maxPrice = maxPrice / 100;
            buyingChance = randomNumber.Next(1, 71);
            dryFactor = 10;
            rainFactor = -50;
            sunFactor = 30;
            forecastFactor = 20;
            temperatureFactor = 20;
            sweetnessFactor = 10;
        }

        public bool BoughtLemonade
        {
            get => boughtLemonade;
        }
        
        public void SetBuyingChances(Player player, Day day, Weather[] weeklyForecast)
        {
            int sugarIndex = 2;
            int minSugar = 3;
            int maxSugar = 7;
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
            if (weeklyForecast[day.DayNumber - 1].IsRaining && !day.TodaysWeather.IsRaining)
            {
                buyingChance -= forecastFactor;
            }
            else if (weeklyForecast[day.DayNumber - 1].IsSunny && !day.TodaysWeather.IsDry)
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
            if (player.Store.Recipe.Amounts[sugarIndex] > minSugar && player.Store.Recipe.Amounts[sugarIndex] < maxSugar)
            {
                buyingChance += sweetnessFactor;
            }
            else
            {
                buyingChance -= sweetnessFactor;
            }
            if (player.Store.CurrentPrice > maxPrice || buyingChance < 0)
            {
                buyingChance = 0;
            }
        }
        
        public void Buy()
        {
            if (buyingChance <= randomNumber.Next(1, 100))
            {
                boughtLemonade = true;
            }          
        }
    }
}
