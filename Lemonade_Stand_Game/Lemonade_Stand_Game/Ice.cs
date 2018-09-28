using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Ice : Item
    {
        int daysToSpoil;

        public Ice()
        {
            daysToSpoil = 1;
            price = .01;
        }
        public override string ToString()
        {
            return "Ice Cubes";
        }
    }
}
