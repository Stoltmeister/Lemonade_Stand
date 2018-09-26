using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemonade_Stand_Game
{
    class Player
    {
        //member variables
        string name;
        Store playerOneStore;

        //constructor
        public Player(string name)
        {
            this.name = name;
            playerOneStore = new Store();
        }

        //methods

        public Store PlayerOneStore
        {
            get => playerOneStore;
        }
    }
}
