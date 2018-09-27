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
        Day currentDay;
        Day[] days;
        Weather[] weeklyForecast;
        Supplier supplier;
        Lemon lemon;
        Cup cup;
        Sugar sugar;
        Ice ice;
        List<Item> supplies;

        //constructor
        public Game()
        {
            gameRunning = true;
            totalDays = 7;
            days = new Day[totalDays];
            weeklyForecast = new Weather[totalDays];
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
            Cup cup = new Cup();
            supplies = new List<Item>() { lemon, sugar, ice, cup};            
            supplier = new Supplier(supplies);

            // set up weeklyForecast
            for (int j = 0; j < weeklyForecast.Length; j++)
            {
                weeklyForecast[j] = new Weather(true);
            }

            // set up first day -- make method?
            Weather todaysWeather = new Weather(false);

            if (todaysWeather.SetWeather())
            {
                currentDay = new Day(1, todaysWeather, playerOne.Wallet.currentCash);
            }
            else
            {
                currentDay = new Day(1, weeklyForecast[0], playerOne.Wallet.currentCash);
            }
        }

        //methods
        public void RunGame()
        {
            // Initial Game Setup
            DisplayRules();
            SetPlayers();

            // put in userInterface? OR MENU class

            // AFTER MVP: two player
            // options: change recipe(hint at user to check first time?), buy supplies, check weeklyForecast, check tomorrows forecast
            // always shows current day number
            //main loop
            while (gameRunning)
            {
                // clear console when?
                // create new day
                Weather todaysWeather = new Weather(false);
                if (todaysWeather.SetWeather())
                {
                    currentDay = new Day(days.Count() + 1, todaysWeather, playerOne.Wallet.currentCash);
                }
                else
                {
                    currentDay = new Day(days.Count() + 1, weeklyForecast[0], playerOne.Wallet.currentCash);
                }
                Console.WriteLine("Welcome to Day " + currentDay.DayNumber + "! \n");
                // Display weather

                ExecuteChoice(Menu.DisplayMainMenu());
                            


                //end of day
                // fix ***   DisplayDayResults(currentDay, playerOne, CalculateDailyProfit(playerOne, currentDay.CustomerArray));
                days[currentDay.DayNumber] = currentDay;
                Console.ReadLine();
                ContinueGame();
            }
        }

        private void ExecuteChoice(int choice)
        {
            switch(choice)
            {
                case 1:
                    Console.WriteLine("The forecast for tomorrow is " + weeklyForecast[currentDay.DayNumber].DisplayWeather(true));
                    break;
                case 2:
                    for (int i = 0; i < totalDays; i++)
                    {
                        Console.WriteLine("The forecast for day " + i + " is" + weeklyForecast[i].DisplayWeather(true));
                    }
                    break;
                case 3:
                    playerOne.Store.Recipe.ChangeRecipe();
                    break;
                case 4:
                    supplier.SellProduct(playerOne);
                    break;
                case 5:
                    
                    break;
                default:
                    Menu.DisplayMainMenu();
                    break;
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

        private void DisplayDayResults(Day pastDay, Player player)
        {
            // show daily profit/loss, total profit/loss, and weather
            double profit = player.Wallet.currentCash - pastDay.DayStartingCash;
            Console.WriteLine("Today's profit/loss was $" + profit + "\n");
            Console.WriteLine("Total profit/loss is $" + player.Wallet.GetTotalProfit + "\n");
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
                DisplayGameResults();
                gameRunning = false;
            }
            else if (playerOne.Wallet.currentCash < .01)
            {
                DisplayGameResults();
                gameRunning = false;
            }
        }

        // needed methods:
        private void DisplayGameResults()
        {
            // parameters?
        }
    }
}
