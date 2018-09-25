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
        double currentTemperature;
        bool isRaining;
        bool isSunny;
        bool isDry;
        string[] weeklyForecast;

        //constructor
        public Weather()
        {

        }

        //methods
        private void SetWeather()
        {

        }

        private string GetForecast(Day tommorrow)
        {
            string forecast = "";
            return "The forecast for tomorrow is: " + forecast;
        }

        private string GetForecast()
        {
            return "";
        }
    }
}
