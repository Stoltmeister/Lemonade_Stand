using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Game
    {
        //member variables
        Player playerOne;
        bool gameRunning;
        int totalDays;
        int numberOfPossibleCustomers;
        int customers;
        Day currentDay;
        Day yesterday; // set currentDay to yesterday after all actions for the day are complete
        Customer[] customerArray;
        Weather[] weeklyForecast;
        Random randNum;

        //constructor
        public Game()
        {            
            gameRunning = true;
            totalDays = 7;            
            numberOfPossibleCustomers = 100;
            customerArray = new Customer[numberOfPossibleCustomers];
            weeklyForecast = new Weather[totalDays];
            randNum = new Random();

            // set up customers
            for (int i = 0; i < numberOfPossibleCustomers; i++)
            {
                customerArray[i] = new Customer(randNum);
            }

            // set up weeklyForecast
            for (int j = 0; j <= weeklyForecast.Length; j++)
            {
                weeklyForecast[j] = new Weather(true);
            }

            Weather firstDayWeather = new Weather(false);
            if (firstDayWeather.SetWeather())
            {
                currentDay = new Day(1, firstDayWeather);
            }
            else
            {
                currentDay = new Day(1, weeklyForecast[0]);
            }



        }

        //methods
        public void RunGame()
        {
            // Initial Game Setup
            DisplayRules();
            SetPlayers();

            //main loop
            while (gameRunning)
            {
                // main menu
                DisplayMainMenu(currentDay, playerOne);

                //end of day
                yesterday = currentDay;
            }
        }

        private void DisplayRules()
        {
            // shows rules at start of game
            string rules = "";
            Console.WriteLine(rules);
        }

        private void SetPlayers()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            playerOne = new Player(name);
        }

        private void DisplayMainMenu(Day currentDay, Player currentPlayer)
        {
            // options: change recipe(hint at user to check first time?), buy supplies, check weeklyForecast, check tomorrows forecast
            // always shows current day number
            Console.WriteLine("Welcome to Day " + currentDay.DayNumber + "! \n" +
                "Here are the results from the previous day: ");
            DisplayDayResults(yesterday, playerOne);
            Console.WriteLine("What would you like to do?");
        }

        private void CalculateDailyProfit(Player player)
        {
            for (int i = 0; i < numberOfPossibleCustomers; i++)
            {
                if (customerArray[i].BoughtLemonade)
                {
                    customers++;
                }
            }
            double profit = playerOne.PlayerOneStore.CurrentPrice * customers;
            double expenses = playerOne.PlayerOneStore.GetCostPerPitcher();
            profit -= expenses;
            playerOne.PlayerOneStore.currentCash += profit;
        }

        private void DisplayDayResults(Day pastDay, Player player)
        {
            // show daily profit/loss, total profit/loss, and weather
            Console.WriteLine("Yesterday " + "");
        }

        private string GetForecast(Day tommorrow)
        {
            string forecast = "The forecast for tomorrow is: " + weeklyForecast[tommorrow.DayNumber];

            return forecast;
        }        
    }
}
