using System;
using DotsAndBoxes.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotsAndBoxesTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Grid grid1 = new Grid(4, 10, 14, 23, 47);
            grid1.StartPlaying();
        }
    }
}
