using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GitHubActionsTest
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ILogger<CalculatorService> _logger;
        private readonly IConfiguration _config;

        public CalculatorService(ILogger<CalculatorService> logger, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public void Run()
        {
            var factorialNumber = _config.GetValue<int>("FactorialNumber");
            var fibonacciNumber = _config.GetValue<int>("FibonacciNumber");

            Console.WriteLine($"Factorial {factorialNumber}: {Factorial(factorialNumber)}");
            Console.WriteLine($"Fibonacci {fibonacciNumber}: {Fibonacci(fibonacciNumber)}");
        }

        public double Factorial(int number)
        {
            _logger.LogDebug("Run Factorial {number}", number);

            if (number == 1) return 1;  // Base case
            return number * Factorial(number - 1); // Inductive case
        }

        public double Fibonacci(int number)
        {
            _logger.LogDebug("Run Fibonacci {number}", number);

            if (number <= 1) return number; // Base case
            return Fibonacci(number - 1) + Fibonacci(number - 2); // Inductive case
        }
    }
}
