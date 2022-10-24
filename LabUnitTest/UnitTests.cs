using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP2022Lab1;
using System;

namespace LabUnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cell c = new Cell();
            c.formula = "5+10/2-1*3";
            int v = 5 + 10 / 2 - 1 * 3;//7
            NumberValue nv = c.calculate() as NumberValue;
            int ci = nv.number;
            Assert.AreEqual(ci, v);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Cell c = new Cell();
            c.formula = "div(mod(inc(10),6),dec(3))";
            int v = ((10+1)%6)/(3-1);//2
            NumberValue nv = c.calculate() as NumberValue;
            int ci = nv.number;
            Assert.AreEqual(ci, v);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Cell c = new Cell();
            c.formula = "((inc( -  3 )) ^  d   e c ( (    (8))  )   )";
            int v = -128;// a hassle to count like the rest
            NumberValue nv = c.calculate() as NumberValue;
            int ci = nv.number;
            Assert.AreEqual(ci, v);
        }
    }
}
