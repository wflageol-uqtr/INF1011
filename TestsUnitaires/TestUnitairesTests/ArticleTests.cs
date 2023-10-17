using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestsUnitaires;
using System;
using System.Text.RegularExpressions;

namespace TestUnitairesTests
{
    [TestClass]
    public class ArticleTests
    {
        private Article article;

        [TestInitialize]
        public void Setup()
        {
            article = new();
        }

        [TestMethod]
        public void TestArticleNoDiscount()
        {
            // Arrange
            article.Price = 45;
            // Act
            var result = article.CalculatePrice();
            // Assert
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void TestArticleWithDiscount()
        {
            // Arrange
            article.Price = 45;
            article.Discount = new DiscountMock { Ratio = 0.9 };
            // Act
            var result = article.CalculatePrice();
            // Assert
            Assert.AreEqual(40.5, result);
        }

        [TestMethod]
        public void TestArticleNoPrice()
        {
            // Arrange
            article.Price = null;
            // Act
            try
            {
                article.CalculatePrice();
                // Assert
                Assert.Fail();
            } 
            catch(InvalidOperationException)
            {
                // OK!
            }
        }

        [TestMethod]
        public void TestArticleNoPriceLog()
        {
            // Arrange
            article.Price = null;
            var loggerMock = new LoggerMock();
            article.Logger = loggerMock;
            // Act
            try
            {
                article.CalculatePrice();
                Assert.Fail();
            }
            catch (InvalidOperationException)
            {
                // Assert
                StringAssert.Matches(loggerMock.loggedData.Pop(), new Regex("Price was null"));
            }
        }

        [TestMethod]
        public void TestPriceFull()
        {

        }

        [TestMethod]
        public void TestPricePartial()
        {

        }

        [TestMethod]
        public void TestPriceZero()
        {

        }

        [TestMethod]
        public void TestPriceNegative()
        {

        }

        [TestMethod]
        public void TestPriceOverfull()
        {

        }
    }
}
