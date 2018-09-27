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
        Store store;
        Wallet wallet;

        //constructor
        public Player(string name)
        {
            this.name = name;
            store = new Store();
            wallet = new Wallet(20);
        }

        //methods

        public Store Store
        {
            get => store;
        }
        public Wallet Wallet
        {
            get => wallet;
        }
    }
}
