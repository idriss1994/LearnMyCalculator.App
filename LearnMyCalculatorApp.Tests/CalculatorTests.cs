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
        public void AddTest()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actual = calculator.Add(1, 1);

            // Non fluent assert
            //Assert.AreEqual(2, actual);

            //Fluent assert
            actual.Should().Be(2).And.NotBe(1);
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

            Assert.IsNull(actual);
        }
    }
}