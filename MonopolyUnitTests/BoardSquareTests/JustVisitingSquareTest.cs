using Monopoly.BoardClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MonopolyTests
{
    
    
    /// <summary>
    ///This is a test class for JustVisitingSquareTest and is intended
    ///to contain all JustVisitingSquareTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JustVisitingSquareTest
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

        [TestMethod]
        public void CanCreateJustVisitingSquare()
        {
            Assert.IsNotNull(new JustVisitingSquare());
        }
    }
}
