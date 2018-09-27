﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Recipe
    {
        List<Item> ingredients;
        List<int> amounts; 

        public Recipe()
        {            
            Lemon lemon = new Lemon();
            Sugar sugar = new Sugar();
            Ice ice = new Ice();
            ingredients = new List<Item> { lemon, sugar, ice };
            amounts = new List<int> { 3, 3, 3 };
        }

        public List<int> Amounts
        {
            get => amounts;
        }
        public List<Item> Ingredients
        {
            get => ingredients;
        }
    }
}