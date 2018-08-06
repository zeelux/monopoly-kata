using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MonopolyTests
{
    
    
    /// <summary>
    ///This is a test class for GoSquareTest and is intended
    ///to contain all GoSquareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GoSquareTest
    {


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

        
        /// <summary>
        ///A test for ApplyEffectOnPass
        ///</summary>
        [TestMethod()]
        public void ApplyEffectOnPassTest()
        {
            GoSquare gosquare = new GoSquare();
            Assert.IsTrue(gosquare.ApplyEffectOnPass);
            
        }
    }
}
