using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotsAndBoxes.Lib;

namespace DotsAndBoxes.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGiven()
        {
            Grid g = new Grid(4, 10, 14, 23);
            g.Play(47);
            Assert.AreEqual("8 2", g.Result);
        }

        [TestMethod]
        public void TestQ1()
        {
            Grid g = new Grid(4, 10, 14, 23);
            g.Play(46);
            Assert.AreEqual("7 2", g.Result);
        }
    }
}
