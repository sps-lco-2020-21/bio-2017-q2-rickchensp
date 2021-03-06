﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotsAndBoxes.Lib
{
    public class Edge
    {
        private Dot _dot1, _dot2;
        private bool _filled;
        public Edge(Dot dot1, Dot dot2)
        {
            if(dot1 == null || dot2 == null)
            {
                return;
            }
            if(dot1 == dot2.DotLeft || dot1 == dot2.DotUp)
            {
                _dot1 = dot1;
                _dot2 = dot2;
            }
            else   //always keep the order of left-to-right or up-to-down
            {
                _dot1 = dot2;
                _dot2 = dot1;
            }

            _filled = false;
        }

        public List<Dot> GetDots
        {
            get { return new List<Dot> { _dot1, _dot2 }; }
        }

        public bool IsFilled 
        {
            get { return _filled; }
            set { _filled = value; }
        }

        public Dot OtherDot(Dot dotIn)  //returns the other dot on the same edge
        {
            if (_dot1 == dotIn)
                return _dot2;
            return _dot1;
        }
        public override string ToString()
        {
            string filled;
            if(_dot1 == null || _dot2 == null)
            {
                return null;
            }
            if (_filled)
                filled = "true";
            else
                filled = "false";
            return (_dot1.ToString() + " - " + _dot2.ToString() + filled);
        }

    }
}
