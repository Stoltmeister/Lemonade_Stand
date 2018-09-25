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
        Customer[] customerArray;
        Random randNum;

        //constructor
        public Game()
        {            
            gameRunning = true;
            totalDays = 7;
            currentDay = new Day(1);
            numberOfCustomers = 100;
            customerArray = new Customer[numberOfCustomers];
            randNum = new Random();

            for (int i = 0; i <= numberOfCustomers; i++)
            {
                customerArray[i] = new Customer(randNum);
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

        }

        private void IncrementProfit(Player player, int profit)
        {
            
        }

        private void DisplayDayResults(Day pastDay)
        {

        } 
        
        // notes:
        // change all customers percentage of buying when price is
        // in different ranges (25cent ranges?)
        //
        //
        //
    }
}
