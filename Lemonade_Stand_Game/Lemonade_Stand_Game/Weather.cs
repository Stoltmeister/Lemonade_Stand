using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Weather
    {
        //member variables
        int currentTemperature;
        bool isRaining;
        bool isSunny;
        bool isDry;
        bool isForecast;
        bool followForecast;
        Random randomNum;
        int forecastChance;
        int rain;
        int sun;
        int dry;

        //constructor
        public Weather(bool isForecast)
        {
            this.isForecast = isForecast;
            randomNum = new Random();
            rain = randomNum.Next(1, 3);
            sun = randomNum.Next(1, 3);
            dry = randomNum.Next(1, 3);
            currentTemperature = randomNum.Next(30, 101);
            forecastChance = randomNum.Next(1, 5);

            if (!isForecast && forecastChance == 1)
            {
                followForecast = false;
            }
            else
            {
                followForecast = true;
            }
        }

        //methods


        public bool SetWeather()
        {
            if (!followForecast || isForecast)
            {
                if (rain == 1)
                {
                    isRaining = false;
                }
                else
                {
                    isRaining = true;
                }
                if (!isRaining && sun == 2)
                {
                    isSunny = true;
                }
                else
                {
                    isSunny = false;
                }
                if (!isRaining && dry == 2)
                {
                    isDry = true;
                }
                else
                {
                    isDry = false;
                }
                return false; // if bool returns true that means you should set weather to forecasted weather
            }
            return true;

        }
        
        public void DisplayWeather()
        {
            string weatherText = "";
            if (isRaining)
            {
                weatherText = "raining but the air is quite dry";
            }
            if (isDry)
            {
                weatherText = "dry ";
            }
            if (isSunny)
            {
                if (weatherText.Length > 1)
                {
                    weatherText += "and sunny.";
                }
                weatherText += "sunny ";
            }
            weatherText += "with an average temperature of " + currentTemperature;
            Console.WriteLine("The weather for today is " + weatherText);
        }
    }
}
