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
        
        
        private bool SetWeather()
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
                if (dry == 2)
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

        private string GetForecast(Day tommorrow)
        {
            string forecast = "";
            return "The forecast for tomorrow is: " + forecast[tommorrow.DayNumber];
        }

        private string GetForecast(int days)
        {
            for (int i = 0; i <= days; i++)
            {
                Weather weather = new Weather(false);
            }
            return "";
        }
    }
}
