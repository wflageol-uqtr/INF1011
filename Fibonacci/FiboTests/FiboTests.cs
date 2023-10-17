using Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FiboTests
{
    [TestClass]
    public class FiboTests
    {
        FibonacciCalculator fibo = new();

        [TestMethod]
        public void TestNegative()
        {
            try
            {
                fibo.Value(-2);
                Assert.Fail();
            } catch (ArgumentException)
            {
                // OK.
            }
        }

        [TestMethod]
        public void TestZero()
        {
            var result = fibo.Value(0);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestOne()
        {
            var result = fibo.Value(1);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestPositive()
        {
            var result = fibo.Value(5);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestLarge()
        {
            var result = fibo.Value(20);
            Assert.AreEqual(10946, result);
        }
    }
}
