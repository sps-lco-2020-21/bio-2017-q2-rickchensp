using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Dot
    {
        private int _value;
        private List<Edge> _connections;
        public Dot(int v)
        {
            _value = v;
            _connections = new List<Edge> { };
        }

        public int Value { get { return _value; } }

        /*intialise _connections, a list with 4 Edges that is connected to this dot, 
         * with the order of up, down, left, right.
        When the edge doesn't exist, set it to null */
        public void InitialiseEdges(int row, int column)  
        {
            _connections.AddRange(
               new List<Edge>
               { new Edge(this, DotUp), new Edge(this, DotRight), new Edge(this, DotDown), new Edge(this, DotLeft) });           
        }
        public List<Edge> Connections
        { get { return _connections; } }

        public Dot DotUp   //returns the dot directly above the current dot
        {
            get
            {
                (int row, int column) = RowAndColumn();
                if (row > 0)
                {
                    return Grid._grid[row - 1][column];
                }
                else
                    return null;   //if the dot doesn't exist, return null
            }
        }
        public Dot DotDown  //returns the dot directly below the current dot
        {
            get
            {
                (int row, int column) = RowAndColumn();
                if (row < 5)
                    return Grid._grid[row + 1][column];
                else
                    return null;
            }
        }
        public Dot DotLeft   //returns the dot to the left the current dot
        {
            get
            {
                (int row, int column) = RowAndColumn();
                if (column > 0)
                    return Grid._grid[row][column - 1];
                else
                    return null;
            }
        }
        public Dot DotRight   //returns the dot to the right the current dot
        {
            get
            {
                (int row, int column) = RowAndColumn();
                if (column < 5)
                    return Grid._grid[row][column + 1];
                else
                    return null;
            }
        }

        public (int, int) RowAndColumn()
        {
            return (_value / 6, _value % 6);
        }

        public override string ToString()
        {
            return Convert.ToString(_value);
        }
    }
}
