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
        int customers;
        int numberOfPossibleCustomers;
        List <Customer> customerArray;
        Random randNum;

        //constructor
        public Day(int dayNumber, Weather todaysWeather)
        {
            this.dayNumber = dayNumber;
            this.todaysWeather = todaysWeather;
            numberOfPossibleCustomers = 100;
            customerArray = new List <Customer>();
            randNum = new Random();


            // set up customers
            for (int i = 0; i < numberOfPossibleCustomers; i++)
            {                
                customerArray.Add(new Customer(randNum));
            }
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

        public List <Customer> CustomerArray
        {
            get => customerArray;
        }

    }
}
