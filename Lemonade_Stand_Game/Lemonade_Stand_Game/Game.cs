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
        int numberOfCustomers;
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
            currentDay = new Day(1);
            numberOfCustomers = 100;
            customerArray = new Customer[numberOfCustomers];
            weeklyForecast = new Weather[totalDays];
            randNum = new Random();

            // set up customers
            for (int i = 0; i <= numberOfCustomers; i++)
            {
                customerArray[i] = new Customer(randNum);
            }

            // set up weeklyForecast
            for (int j = 0; j <= weeklyForecast.Length; j++)
            {
                weeklyForecast[j] = new Weather(true);
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

        private void IncrementProfit(Player player, int profit)
        {
            // what is the best way to access this info
            // 
        }

        private void DisplayDayResults(Day pastDay, Player player)
        {
            // show daily profit/loss, total profit/loss, and weather
            Console.WriteLine("Yesterday " + "");
        } 
        
        // notes:
        // change all customers percentage of buying when price is
        // in different ranges (25cent ranges?)
        //
        //
        //
    }
}
