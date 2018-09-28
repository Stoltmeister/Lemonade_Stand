using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    public abstract class Item
    {
        protected double price;

        protected Item()
        {

        }
        public double Price
        {
            get => price;
        }        
    }
}
