using JeuDeDes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeDesTests
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void TestRollPowerDie()
        {
            // Arrange
            var rng = new RandomNumberMock { Value = 2 };
            var die = new Die(rng);

            var faceToChange = die.Faces.ElementAt(2);
            var newFace = new PowerFace(4);
            die.ChangeFace(faceToChange, newFace);

            // Act
            var result = die.Roll();

            // Assert
            Assert.AreEqual(newFace, result);
        }
    }
}
