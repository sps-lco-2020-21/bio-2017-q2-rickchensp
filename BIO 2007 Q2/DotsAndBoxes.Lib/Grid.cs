using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Grid
    {
        private Player _player;
        private int _playerId = 0;
        private List<Player> _players = new List<Player> { };
        private List<List<Dot>> _grid = new List<List<Dot>> { };
        private List<List<Square>> _squares = new List<List<Square>> { };
        public Grid(int p1Start, int p1Modifier, int p2Start, int p2Modifier)
        {
            Player player1 = new Player(1, p1Start, p1Modifier);
            Player player2 = new Player(2, p2Start, p2Modifier);
            _players.Add(player1);
            _players.Add(player2);

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
                    row.Add(new Dot(i * 6 + j, _grid));
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


        public void Play(int numTurns)
        {
            _player = _players[_playerId];
            while(numTurns > 0)
            {
                _player.CurrentPos += _player.Modifier; //increase current position
                _player.CurrentPos %= 36;   //goes to front when back is reached
                Edge edgeFilled = OneTurn();   //Find and Fills an edge for the round
                List<Square> FilledSquares = FindSquares(edgeFilled);  //Find the Squares related to that edge
                Update(FilledSquares);   //update the square and decide the player for the next round
                         
                numTurns -= 1;
            }

            DisplayResult();
        }

        private void Update(List<Square> filledSquares)
        {
            bool squareFilled = false;
            foreach (Square square in filledSquares)
            {
                if(square != null)
                {
                    if (square.IsFull)
                    {
                        square.SetOwner(_player);
                        squareFilled = true;
                    }
                }
            }
            if (!squareFilled)  // if no squares were filled, change player for the next                                                                                                                                                                                                                                
            {
                _playerId = (_playerId + 1) % 2;
                _player = _players[_playerId];
            }
        }

        private Edge OneTurn()
        {
            (int row, int column) = RowAndColumn(_player.CurrentPos);  //convert dot id to coordinate
            
            Dot dot = _grid[row][column];
            Edge edgeFilled = FillEdge(dot);
            if(edgeFilled == null)   //when all the edges are full. go to the next dot
            {
                _player.CurrentPos = (_player.CurrentPos + 1) % 36;
                edgeFilled = OneTurn();
            }

            return edgeFilled;     
        }

        private Edge FillEdge(Dot dot1)
        {
            List<Edge> edges = dot1.Connections;
            int counter = 1;
            if(_player.ID == 2)  //for player2, go anti-clockwise throught the list of edges
                counter = -1;

            for(int i = 0, count = 0; count < 4; i += counter, count+= 1)  //get the edges that's connected to the dot
            {
                if(i == -1)  //when going anti-clockwise, go to the back of the list
                    i = 3;
                if (edges[i].GetDots[0] != null) // if the edge exists
                {
                    if (edges[i].IsFilled == false)
                    {
                        edges[i].IsFilled = true;     //Fill the edge from both ends
                        edges[i].OtherDot(dot1).Connections[(i + 2) % 4].IsFilled = true;
                        return edges[i];
                    }   
                }
            }
            return null;
        }

        private (int, int) RowAndColumn(int Pos)  //returns the coordinate of a dot given its id
        {
            return (Pos / 6, Pos % 6);
        }

        public void DisplayResult()
        {
            foreach(List<Square> row in _squares)   //display the final grid
            {
                string rowStr = string.Empty;
                foreach(Square square in row)
                {
                    rowStr += square.ToString() + " ";
                }
                Console.WriteLine(rowStr);
            }
            Console.WriteLine();
            Console.WriteLine(Convert.ToString(_players[0].Score) + " " + Convert.ToString(_players[1].Score));
        }

        public string Result
        { get { return Convert.ToString(_players[0].Score) + " " + Convert.ToString(_players[1].Score); } }

        public override string ToString()
        {
            return base.ToString();
        }

        private List<Square> FindSquares(Edge edgeFilled)
        {
            Square square1 = null;
            Square square2 = null;
            
            int dot1Id = edgeFilled.GetDots[0].Value;
            int dot2Id = edgeFilled.GetDots[1].Value;
            (int dot1row, int dot1column) = RowAndColumn(dot1Id);

            if(dot2Id == dot1Id + 6)  // if the edge is vertical
            {
                if (dot1column == 5)   //when the edge is on the right outline
                    square1 = _squares[dot1row][dot1column - 1];
                else if (dot1column == 0) //when the edge is on the left outline
                    square1 = _squares[dot1row][dot1column];
                else
                {
                    square1 = _squares[dot1row][dot1column];
                    square2 = _squares[dot1row][dot1column - 1];
                }
 
            }          
            else
            {
                if (dot1row == 5)  //when the edge is on the bottom outline
                    square1 = _squares[dot1row - 1][dot1column];
                else if (dot1row == 0) //when the edge is on the top outline
                    square1 = _squares[dot1row][dot1column];
                else
                {
                    square1 = _squares[dot1row][dot1column];
                    square2 = _squares[dot1row - 1][dot1column];
                }
            }
           return new List<Square> { square1, square2 };
        }
    }
}
