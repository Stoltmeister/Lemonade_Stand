﻿using System;
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
        int daynumber;
        Day currentDay;
        Day[] days;
        Weather weather;
        Weather[] weeklyForecast;
        Supplier supplier;
        Lemon lemon;
        Cup cup;
        Sugar sugar;
        Ice ice;
        List<Item> supplies;
        Random random;

        //constructor
        public Game()
        {
            gameRunning = true;
            totalDays = 7;
            days = new Day[totalDays];
            daynumber = 1;
            weeklyForecast = new Weather[totalDays];
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
            Cup cup = new Cup();
            supplies = new List<Item>() { lemon, sugar, ice, cup };
            supplier = new Supplier(supplies);
            random = new Random();

            // set up weeklyForecast
            for (int j = 0; j < totalDays; j++)
            {
                weeklyForecast[j] = new Weather(true, random);
                weeklyForecast[j].SetWeather();
            }
        }

        //methods
        public void RunGame()
        {
            // Initial Game Setup
            DisplayRules();
            SetPlayers();

            // AFTER MVP: two player
            // always shows current day number

            //main loop
            while (gameRunning)
            {
                // clear console when?
                // create new day
                weather = new Weather(false, random);
                if (weather.SetWeather())
                {
                    currentDay = new Day(daynumber, weather, playerOne.Wallet.currentCash);                    
                }
                else
                {
                    currentDay = new Day(daynumber, weeklyForecast[0], playerOne.Wallet.currentCash);
                }

                Console.WriteLine("Welcome to Day " + currentDay.DayNumber + " " + playerOne.Name + "! \n");
                Console.WriteLine("The weather for today will be: " + currentDay.TodaysWeather.DisplayWeather() + "\n");
                ExecuteChoice(Menu.DisplayMainMenu());

                //end of day
                DisplayDayResults(currentDay, playerOne);
                days[daynumber - 1] = currentDay;
                daynumber++;
                ContinueGame();
            }
        }

        private void ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("The forecast for tomorrow is " + weeklyForecast[currentDay.DayNumber].DisplayWeather());
                    Console.WriteLine("\n");
                    ExecuteChoice(Menu.DisplayMainMenu());
                    break;
                case 2:
                    for (int i = 0; i < totalDays; i++)
                    {
                        Console.WriteLine("The forecast for day " + (i + 1) + ":" + weeklyForecast[i].DisplayWeather());
                    }
                    Console.WriteLine("\n");
                    ExecuteChoice(Menu.DisplayMainMenu());
                    break;
                case 3:
                    playerOne.Store.Recipe.ChangeRecipe();
                    Console.WriteLine("\n");
                    ExecuteChoice(Menu.DisplayMainMenu());
                    break;
                case 4:
                    playerOne.Store.Inventory.DisplayInventory();
                    supplier.SellProduct(playerOne);
                    Console.WriteLine("\n");
                    ExecuteChoice(Menu.DisplayMainMenu());
                    break;
                case 5:
                    double newPrice = playerOne.Store.ChangePrice(playerOne);
                    if (newPrice == 0)
                    {
                        ExecuteChoice(Menu.DisplayMainMenu());
                    }
                    else
                    {
                        Console.WriteLine("Your new price is $" + newPrice + "\n");
                        playerOne.Store.SetPrice(newPrice);
                        ExecuteChoice(Menu.DisplayMainMenu());
                    } 
                    break;
                case 6:
                    // getting the customers
                    for (int i = 0; i < currentDay.PossibleCustomers.Count; i++)
                    {
                        currentDay.PossibleCustomers[i].SetBuyingChances(playerOne, currentDay, weeklyForecast);
                        currentDay.PossibleCustomers[i].Buy();
                    }
                    playerOne.Store.Inventory.CalculateTotalPitchers(playerOne.Store.Recipe);
                    int customers = playerOne.Store.Inventory.UpdateInventory(currentDay.CalculateCustomers(), playerOne.Store.Recipe);
                    currentDay.CalculateDailyProfit(playerOne, customers);
                    break;
                default:
                    ExecuteChoice(Menu.DisplayMainMenu());
                    break;
            }
        }

        private void DisplayRules()
        {
            string rules = "Welcome to the Lemonade Stand Game! \n \n" +
                "Here are the rules of how to play : \n \n" +
                "You are setting up for a week of running a lemonade stand looking to make the most money possible! \n" +
                "Each day you have the chance to change the recipe, buy supplies and change your price using previous days data to perfect your operation. \n" +
                "Weather conditions greatly affect the demand for lemonade so make sure to stock your inventory and set prices accordingly. \n" +
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
            double profit = player.Wallet.currentCash - pastDay.DayStartingCash;
            Console.WriteLine("Today's profit/loss was $" + profit + "\n");
            player.Wallet.CalculateTotalProfit();
            Console.WriteLine("Total profit/loss is $" + player.Wallet.GetTotalProfit + "\n");
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

        private void DisplayGameResults()
        {
            Console.WriteLine("Game results: \n");
            Console.WriteLine("Your total profit was: $" + playerOne.Wallet.GetTotalProfit + "\n");
            Console.WriteLine("Good job ;)             (Any Key to Exit)");
            Console.ReadLine();
        }

    }
}
