using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GitHubActionsTest.Test
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private static ICalculatorService _calculatorService;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            _calculatorService = new CalculatorService(new NullLogger<CalculatorService>(), new ConfigurationBuilder().Build());
        }

        [TestMethod]
        public void Factorial_0_Expected_1()
        {
            var result = _calculatorService.Factorial(0);

            result.Should().Be(1);
        }

        [TestMethod]
        public void Factorial_5_Expected_120()
        {
            var result = _calculatorService.Factorial(5);

            result.Should().Be(120);
        }

        [TestMethod]
        public void Fibonacci_1_Expected_1()
        {
            var result = _calculatorService.Fibonacci(1);

            result.Should().Be(1);
        }

        [TestMethod]
        public void Fibonacci_7_Expected_13()
        {
            var result = _calculatorService.Fibonacci(7);

            result.Should().Be(13);
        }
    }
}
