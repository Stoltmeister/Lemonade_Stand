using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Cup : Item
    {
        public Cup()
        {
            price = .01;
        }
        public override string ToString()
        {
            return "Cups";
        }
    }
}
