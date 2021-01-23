using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Player
    {
        private int _id;
        private int _modifier;
        private int _currentPos;
        private int _score = 0;
        public Player(int ID, int start, int modifier)
        {
            _id = ID;
            _modifier = modifier;
            _currentPos = start - 1;
        }

        public int CurrentPos 
        { 
            get { return _currentPos; } 
            set { _currentPos = value; }
        }
        public int Modifier { get { return _modifier; } }

        public int ID { get { return _id; } }
        public override string ToString()
        {
            return "player" + Convert.ToString(_id);
        }

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
