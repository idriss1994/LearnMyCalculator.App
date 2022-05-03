using Microsoft.VisualStudio.TestTools.UnitTesting;
using LearnMyCalculatorApp;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using FluentAssertions;

namespace LearnMyCalculatorApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        private readonly IConfiguration _configuration;
        public CalculatorTests()
        {
            //for this install package: Microsoft.Extensions.Configuration.Json
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false, false)
                .Build();
        }

        [TestMethod]
        public void CheckMyAgeFromAppSettingsFile()
        {
            string actual = _configuration["myName"];
            
            Assert.AreEqual("idriss", actual);
        }
        [TestMethod]
        public void CalculatorNullTest()
        {
            var calculator = new Calculator();
            Assert.IsNotNull(calculator);
            Assert.IsTrue(true); // Will fail the test
        }

        [TestMethod]
        [DataRow(1,1,2)]
        [DataRow(2,5,7)]
        [DataRow(3,3,9)]//should failed
        [DataRow(2,0,0)]//should failed
        public void AddTest(int x, int y, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(x, y);

            // Non fluent assert
            //Assert.AreEqual(2, actual);

            //Fluent assert
            actual.Should().Be(expected).And.NotBe(1);
        }

        [TestMethod]
        public void SubstractTest()
        {
            var calculator = new Calculator();

            int actual = calculator.Subtract(4, 3);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            var calculator = new Calculator();

            int actual = calculator.Multiply(5, 5);

            Assert.AreEqual(25, actual);
        }
        // Resolve conflit
        [TestMethod]
        public void DivideTest()
        {
            var calculator = new Calculator();

            int? actual = calculator.Divide(2, 2);

            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void Divide_ByZero_Test()
        {
            var calculator = new Calculator();

            int? actual = calculator.Divide(4, 0);

            //Assert.IsNull(actual);
            actual.Should().BeNull();
        }
    }
}
