using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    class Player
    {
        private int _id;
        private int _modifier;
        private int _currentPos;

        public Player(int ID, int start, int modifier)
        {
            _id = ID;
            _modifier = modifier;
            _currentPos = start;
        }

        public int CurrentPos 
        { 
            get { return _currentPos; } 
            set { _currentPos = value; }
        }
        public int Modifier { get { return _modifier; } }


        public override string ToString()
        {
            return "player" + Convert.ToString(_id);
        }
    }
}
