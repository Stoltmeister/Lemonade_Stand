using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Sugar : Item
    {

        public Sugar()
        {
            price = .01;
        }
        public override string ToString()
        {
            return "Cups of Sugar";
        }
    }
}
