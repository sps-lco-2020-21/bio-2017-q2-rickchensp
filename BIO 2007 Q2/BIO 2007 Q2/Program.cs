using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotsAndBoxes.Lib;

namespace BIO_2007_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid1 = new Grid(4, 10, 14, 23);
            grid1.Play(47);
            Console.ReadKey();
        }
    }
}
