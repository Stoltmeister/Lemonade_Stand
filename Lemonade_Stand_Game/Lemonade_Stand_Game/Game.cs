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
        Day[] days;
        Customer[] customerArray;
        Weather[] weeklyForecast;
        Weather firstDayWeather;
        Random randNum;

        //constructor
        public Game()
        {            
            gameRunning = true;
            totalDays = 7;
            days = new Day[totalDays];
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
            for (int j = 0; j < weeklyForecast.Length; j++)
            {
                weeklyForecast[j] = new Weather(true);
            }

            // set up first day -- make method?
            firstDayWeather = new Weather(false);

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
                // clear console when?

                // create new day
                // main menu
                DisplayMainMenu(currentDay, playerOne);

                //end of day
                DisplayDayResults(currentDay, playerOne, CalculateDailyProfit(playerOne));
                yesterday = currentDay;
                Console.ReadLine();
                gameRunning = !gameRunning; //for testing
                ContinueGame();
            }
        }

        private void DisplayRules()
        {
            // shows rules at start of game
            string rules = "Welcome to the Lemonade Stand Game! \n \n" +
                "Here are the rules of how to play : \n " +
                "You are setting up for a week of running a lemonade stand looking to make the most money possible! \n" +
                "Each day you have the chance to change the recipe, buy supplies and change your price using previous days data to perfect your operation. \n" +
                "Weather conditions greatly affect the demand for lemonade so make sure to stock your inventory and set prices accordingly \n" +
                "Be sure to check out the daily/weekly forecasts for an idea of what you should do. Be careful though as forecasts aren't always perfect! \n";
                
            Console.WriteLine(rules);
        }

        private void SetPlayers()
        {
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\n");
            playerOne = new Player(name);
        }

        private void DisplayMainMenu(Day currentDay, Player currentPlayer)
        {
            // AFTER MVP: two player
            // options: change recipe(hint at user to check first time?), buy supplies, check weeklyForecast, check tomorrows forecast
            // always shows current day number
            Console.WriteLine("Welcome to Day " + currentDay.DayNumber + "! \n");            
            Console.WriteLine("What would you like to do? " +
                "1 = Show tomorrows weather, 2 = Show full week forecast, 3 = Change Recipe \n" +
                "4 = Buy Ingredients, 5 = ");
            try
            {
                int input = Int32.Parse(Console.ReadLine());
            }
            catch
            {

            }
        }

        private double CalculateDailyProfit(Player player)
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

            return profit;
        }

        private void DisplayDayResults(Day pastDay, Player player, double profit)
        {
            // show daily profit/loss, total profit/loss, and weather
            Console.WriteLine("Today's profit/loss was $" + profit + "\n");
            Console.WriteLine("Total profit/loss is $" + player.PlayerOneStore.GetTotalProfit() + "\n");
        }

        private string GetForecast(Day tommorrow)
        {
            string forecast = "The forecast for tomorrow is: " + weeklyForecast[tommorrow.DayNumber];

            return forecast;
        }
        
        private void ContinueGame()
        {
            if (currentDay.DayNumber == 7)
            {
                // display game results
                gameRunning = false;
            }
            else if (playerOne.PlayerOneStore.currentCash < .01)
            {
                // display game results
                gameRunning = false;
            }
        }
    }
}
