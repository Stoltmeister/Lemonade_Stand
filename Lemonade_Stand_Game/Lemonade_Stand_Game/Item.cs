﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    public abstract class Item
    {
        int price;

        protected Item()
        {

        }
        public int Price
        {
            get => price;
        }
    }
}
