using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.DiceClasses;

namespace MonopolyTests
{
    /// <summary>
    /// Summary description for DieTests
    /// </summary>
    [TestClass]
    public class DieTests
    {
        public DieTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void RollDie_Returns1Through6()
        {
            Die die = new Die();
            int value = die.Roll();

            Assert.IsTrue(isValueInRange(value));
        }

        [TestMethod]
        public void Roll100Times_AlwaysReturns1Through6()
        {
            for (int i = 0; i < 100; i++)
            {
                Die die = new Die();
                int value = die.Roll();

                Assert.IsTrue(isValueInRange(value));
            }
        }

        private static bool isValueInRange(int value)
        {
            return value > 0 && value < 7;
        }
    }
}
