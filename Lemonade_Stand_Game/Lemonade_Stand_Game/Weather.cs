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
        int averageTemperature;
        bool isRaining;
        bool isSunny;
        bool isDry;
        bool isForecast;
        bool followForecast;
        Random randomNum;
        int forecastChance;
        int rainChance;
        int sunChance;
        int dryChance;

        //constructor
        public Weather(bool isForecast, Random random)
        {
            this.isForecast = isForecast;
            randomNum = new Random();
            rainChance = randomNum.Next(1, 3);
            sunChance = randomNum.Next(1, 3);
            dryChance = randomNum.Next(1, 3);
            averageTemperature = randomNum.Next(30, 101);
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

        public bool IsRaining
        {
            get => isRaining;
        }

        public bool IsDry
        {
            get => isDry;
        }

        public bool IsSunny
        {
            get => isSunny;
        }
        
        public int Temperature
        {
            get => averageTemperature;
        }

        public bool SetWeather()
        {
            if (!followForecast || isForecast)
            {
                if (rainChance == 1)
                {
                    isRaining = false;
                }
                else
                {
                    isRaining = true;
                }
                if (!isRaining && sunChance == 2)
                {
                    isSunny = true;
                }
                else
                {
                    isSunny = false;
                }
                if (!isRaining && dryChance == 2)
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
        
        public string DisplayWeather()
        {
            string weatherText = "";
            if (isRaining)
            {
                weatherText += "Rain.";
            }
            if (isDry)
            {
                weatherText += "Dry ";
            }
            if (isSunny)
            {
                if (weatherText.Length > 1)
                {
                    weatherText += "and sunny. ";
                }
                weatherText += "sunny ";
            }
            if (weatherText == "")
            {
                weatherText = "No rain, not especially sunny or dry.";
            }
            weatherText += " The average temperature will be " + averageTemperature;
            return weatherText;
            
        }
    }
}
