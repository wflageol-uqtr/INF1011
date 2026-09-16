using HarryPotter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HarryPotterTests
{
    [TestClass]
    public class CashierTests
    {
        private Cashier cashier;

        [TestInitialize]
        public void Setup()
        {
            cashier = new Cashier(
                8,
                new Discount[]
                {
                    new Discount(2, 0.95),
                    new Discount(3, 0.9),
                    new Discount(4, 0.8),
                    new Discount(5, 0.75) 
                });
        }

        private Basket Build(params int[] values)
            => new Basket(values.Select(v => new Book(v)));

        [TestMethod]
        public void SimpleCase1()
        {
            Assert.AreEqual(15.2, cashier.Compute(Build(1, 2)));
        }

        [TestMethod]
        public void SimpleCase2()
        {
            Assert.AreEqual(21.6, cashier.Compute(Build(1, 3, 5)));
        }

        [TestMethod]
        public void SimpleCase3()
        {
            Assert.AreEqual(25.6, cashier.Compute(Build(1, 2, 3, 5)));
        }

        [TestMethod]
        public void SimpleCase4()
        {
            Assert.AreEqual(30, cashier.Compute(Build(1, 2, 3, 4, 5)));
        }

        [TestMethod]
        public void EdgeCase1()
        {
            Assert.AreEqual(51.2, cashier.Compute(Build(1, 2, 2, 3, 4, 4, 5, 5)));
        }

        [TestMethod]
        public void EdgeCase2()
        {
            Assert.AreEqual(132.4, cashier.Compute(Build(
                1, 1, 1, 
                2, 2, 2, 2, 2, 
                3, 3, 3, 
                4, 4, 4, 4, 4, 
                5, 5, 5, 5, 5)));
        }

        [TestMethod]
        public void EdgeCase3()
        {
            Assert.AreEqual(29.6, cashier.Compute(Build(1, 2, 3, 3)));
        }
    }
}
