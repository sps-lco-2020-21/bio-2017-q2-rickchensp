using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Grid
    {
        private int _numTurns;
        private Player _player;
        public static List<List<Dot>> _grid = new List<List<Dot>> { };
        public static List<List<Square>> _squares = new List<List<Square>> { };
        public Grid(int p1Start, int p1Modifier, int p2Start, int p2Modifier, int numTurns)
        {
            Player player1 = new Player(1, p1Start, p1Modifier);
            Player player2 = new Player(2, p2Start, p2Modifier);
            _player = player1;
            _numTurns = numTurns;

            InitialiseDots();
            InitialiseSquares();
        }

        private void InitialiseDots()
        {
            for (int i = 0; i < 6; i++)
            {
                List<Dot> row = new List<Dot> { };
                for (int j = 0; j < 6; j++)
                {
                    row.Add(new Dot(i * 6 + j));
                }
                _grid.Add(row);
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    _grid[i][j].InitialiseEdges(i, j);
                }
            }
        }

        private void InitialiseSquares()
        {
            for(int i = 0; i < 5; ++i)
            {
                List<Square> row = new List<Square> { };
                for(int j = 0; j< 5; ++j)
                {
                    row.Add(new Square(_grid[i][j]));
                }
                _squares.Add(row);
            }
        }


        public void StartPlaying()
        {
            while(_numTurns > 0)
            {
                OneTurn();
                
                _numTurns -= 1;
            }
        }

        public void OneTurn()
        {
            _player.CurrentPos += _player.Modifier; //increase current position
            _player.CurrentPos %= 36;   //goes to front when back is reached
            (int row, int column) = RowAndColumn(_player.CurrentPos);  //convert dot id to coordinate
            
            Dot dot = _grid[row][column];
            bool filled = false;
            foreach(Edge connection in dot.Connections)  //get the edges that's connected to the dot
            {
                if (connection.IsFilled == false)
                {
                    connection.IsFilled = true;
                    filled = true;
                    break;
                }
            }
            if(!filled)   //when all the edges are full. go to the next dot
            {
                _player.CurrentPos += 1;
                OneTurn();
            }
            
        }

        public (int, int) RowAndColumn(int Pos)  //returns the coordinate of a dot given its id
        {
            return (Pos / 6, Pos % 6);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
