﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Day
    {
        Weather todaysWeather;
        int dayNumber;
        int customers;
        int numberOfPossibleCustomers;
        double dayStartingCash;
        List<Customer> possibleCustomers;
        Random randNum;

        public Day(int dayNumber, Weather todaysWeather, double dayStartingCash)
        {
            this.dayNumber = dayNumber;
            this.todaysWeather = todaysWeather;
            numberOfPossibleCustomers = 100;
            this.dayStartingCash = dayStartingCash;
            possibleCustomers = new List<Customer>();
            randNum = new Random();

            for (int i = 0; i < numberOfPossibleCustomers; i++)
            {
                possibleCustomers.Add(new Customer(randNum));
            }

        }

        public int DayNumber
        {
            get => dayNumber;
        }

        public Weather TodaysWeather
        {
            get => todaysWeather;
        }

        public List<Customer> PossibleCustomers
        {
            get => possibleCustomers;
        }
        public double DayStartingCash
        {
            get => dayStartingCash;
        }

        public int CalculateCustomers()
        {
            for (int i = 0; i < possibleCustomers.Count; i++)
            {
                if (possibleCustomers[i].BoughtLemonade)
                {
                    customers++;
                }
            }
            return customers;
        }

        public double CalculateDailyProfit(Player player, int totalCustomers)
        {
            customers = totalCustomers;
            double profit = player.Store.CurrentPrice * totalCustomers;
            double expenses = (customers / 5) * player.Store.Recipe.CostPerPitcher;
            profit -= expenses;
            player.Wallet.currentCash += profit;

            return profit;
        }

    }
}
