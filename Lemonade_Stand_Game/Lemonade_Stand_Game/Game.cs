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
        int currentDay;
        int totalDays;
        Day dayOne;

        //constructor
        public Game()
        {
            gameRunning = true;
            totalDays = 7;
            dayOne = new Day();
        }

        //methods
        public void RunGame()
        {
            DisplayRules();
            SetPlayers();

            //main loop
            while (gameRunning)
            {
                // main menu
                
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

        private void DisplayMainMenu()
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
    }
}
