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
        private int dayNumber;

        //constructor
        public Day(int dayNumber)
        {
            this.dayNumber = dayNumber;

        }

        //methods
        public int DayNumber
        {
            get => dayNumber;

        }

    }
}
