using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Lemon : Item
    {
        int daysToSpoil;

        public Lemon()
        {
            daysToSpoil = 3;
            price = .05;
        }
        public override string ToString()
        {
            return "Lemon";
        }
    }
}
