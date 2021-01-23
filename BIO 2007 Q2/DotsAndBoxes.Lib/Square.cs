using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Square
    {
        Dot _dot1, _dot2, _dot3, _dot4;
        Edge _edge1, _edge2, _edge3, _edge4;
        Player _owner = null;
        public Square(Dot dotTopLeft)
        {
            _dot1 = dotTopLeft;
            _edge1 = _dot1.Connections[1];    //the top edge of the square
            _edge4 = _dot1.Connections[2];    //the left edge of the square
            
            _dot4 = dotTopLeft.DotDown.DotRight;
            _edge2 = _dot4.Connections[0];   //the right edge of the square
            _edge3 = _dot4.Connections[3];   //the bottom edge of the square
            
            _dot2 = dotTopLeft.DotRight;
            _dot3 = dotTopLeft.DotDown;          
        }

        public bool IsFull
        {
            get 
            {
                if (_edge1.IsFilled && _edge2.IsFilled && _edge3.IsFilled && _edge4.IsFilled)
                {
                    return true;
                }
                return false;
            }
        }

        public void SetOwner(Player player)
        {
            _owner = player;
            player.Score += 1;
        }

        public override string ToString()
        {
            if (_owner == null)
                return "*";
            else if (_owner.ID == 1)
                return "X";
            else
                return "O";
        }

    }
}
