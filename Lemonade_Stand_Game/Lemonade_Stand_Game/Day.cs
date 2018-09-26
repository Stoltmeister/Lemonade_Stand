using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Day
    {
        //member variables
        Weather todaysWeather;
        int dayNumber;

        //constructor
        public Day(int dayNumber, Weather todaysWeather)
        {
            this.dayNumber = dayNumber;
            this.todaysWeather = todaysWeather;
        }

        //methods
        public int DayNumber
        {
            get => dayNumber;
        }

        public Weather TodaysWeather
        {
            get => todaysWeather;
        }

    }
}
