using NUnit.Framework;
using System;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Text;
using MarsRover.Model.Models.Internals.Exceptions;

namespace MarsRover.Test
{
    public class Tests
    {        
        private IFactory _factory;


        [SetUp]
        public void Setup()
        {
            var diHelper = new MockDIHelper();
            _factory = diHelper.ServiceProvider.GetRequiredService<IFactory>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "5 1 E")]
        [TestCase("10 10", "4 3 S", "MLMLMRM", "6 3 E")]
        public void IsValid_GivenCommand_ReturnsExpectedResult(string plateauCoordinates, string roverPosition, string navigationLetters, string output)
        {
            var result = _factory.Command(plateauCoordinates, roverPosition, navigationLetters);
            Assert.AreEqual(output, result);
        }


        [TestCase("5 5", "1 2 N", "LMLMLMLMM", "1 5 N")]
        [TestCase("5 5", "3 3 E", "MMRMMRMRRM", "5 1 N")]
        [TestCase("10 10", "6 3 S", "MLMLMRM", "6 3 E")]
        public void IsNotValid_GivenCommand_ReturnsExpectedResult(string plateauCoordinates, string roverPosition, string navigationLetters, string output)
        {
            var result = _factory.Command(plateauCoordinates, roverPosition, navigationLetters);

            Assert.AreNotEqual(output, result);
        }



        [TestCase("5 5 7", "1 2 N", "LMLMLMLMM", "1 5 N")]
        [TestCase("5", "1 2 N", "LMLMLMLMM", "1 5 N")]
        public void InvalidCoordinates_GivenCommand_ReturnsExpectedResult(string plateauCoordinates, string roverPosition, string navigationLetters, string output)
        {
            Action testCode = () => { _factory.Command(plateauCoordinates, roverPosition, navigationLetters); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);
            Assert.AreSame(ex.GetType(), typeof(PlateauValidationException));
        }

    }
}