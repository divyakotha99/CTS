using System;
using System.Collections.Generic;

namespace FinancialForecastingExample
{
    public class FinancialForecast
    {
        // Recursive method to calculate future value with compound growth
        public static double CalculateFutureValueRecursive(double currentValue, double growthRate, int periods)
        {
            if (periods == 0)
            {
                return currentValue;
            }

            double previousValue = CalculateFutureValueRecursive(currentValue, growthRate, periods - 1);
            return previousValue * (1 + growthRate);
        }

        // Recursive method with memoization (optimized)
        public static double CalculateFutureValueMemoized(double currentValue, double growthRate, int periods)
        {
            Dictionary<int, double> memo = new Dictionary<int, double>();
            return CalculateFutureValueHelper(currentValue, growthRate, periods, memo);
        }

        private static double CalculateFutureValueHelper(double currentValue, double growthRate, int periods, Dictionary<int, double> memo)
        {
            if (periods == 0)
            {
                return currentValue;
            }

            if (memo.ContainsKey(periods))
            {
                return memo[periods];
            }

            double previousValue = CalculateFutureValueHelper(currentValue, growthRate, periods - 1, memo);
            double result = previousValue * (1 + growthRate);
            
            memo[periods] = result;
            return result;
        }

        // Direct formula (non-recursive) - for comparison
        public static double CalculateFutureValueFormula(double currentValue, double growthRate, int periods)
        {
            return currentValue * Math.Pow(1 + growthRate, periods);
        }

        // Recursive method to calculate sum of growth rates
        public static double CalculateCumulativeGrowthRecursive(double[] growthRates, int index)
        {
            if (index == 0)
            {
                return growthRates[0];
            }

            return growthRates[index] + CalculateCumulativeGrowthRecursive(growthRates, index - 1);
        }

        // Recursive method to predict value with varying growth rates
        public static double CalculateFutureValueVaryingRatesRecursive(double initialValue, double[] growthRates, int periods)
        {
            if (periods == 0)
            {
                return initialValue;
            }

            if (periods > growthRates.Length)
            {
                Console.WriteLine($"Warning: Not enough growth rates. Using last rate for remaining periods.");
                double lastRate = growthRates[growthRates.Length - 1];
                return CalculateFutureValueRecursive(initialValue, lastRate, periods);
            }

            double previousValue = CalculateFutureValueVaryingRatesRecursive(initialValue, growthRates, periods - 1);
            return previousValue * (1 + growthRates[periods - 1]);
        }

        // Recursive method to calculate moving average
        public static double CalculateMovingAverageRecursive(double[] values, int index, int windowSize)
        {
            if (index < windowSize - 1)
            {
                return CalculateSumRecursive(values, index, 0) / (index + 1);
            }

            return CalculateSumRecursive(values, index, windowSize) / windowSize;
        }

        private static double CalculateSumRecursive(double[] values, int endIndex, int windowSize)
        {
            int startIndex = endIndex - windowSize + 1;
            
            if (startIndex == endIndex)
            {
                return values[endIndex];
            }

            return values[endIndex] + CalculateSumRecursive(values, endIndex - 1, windowSize);
        }

        // Recursive method for exponential smoothing
        public static double ExponentialSmoothingRecursive(double[] values, int index, double alpha, double[] smoothedValues)
        {
            if (index == 0)
            {
                smoothedValues[0] = values[0];
                return smoothedValues[0];
            }

            double previousSmoothed = ExponentialSmoothingRecursive(values, index - 1, alpha, smoothedValues);
            smoothedValues[index] = alpha * values[index] + (1 - alpha) * previousSmoothed;
            return smoothedValues[index];
        }

        // Generate forecast history
        public static List<double> GenerateForecastHistory(double initialValue, double growthRate, int periods)
        {
            List<double> history = new List<double>();
            GenerateForecastHistoryHelper(initialValue, growthRate, periods, history);
            return history;
        }

        private static void GenerateForecastHistoryHelper(double currentValue, double growthRate, int periods, List<double> history)
        {
            if (periods < 0)
            {
                return;
            }

            if (periods == 0)
            {
                history.Insert(0, currentValue);
                return;
            }

            GenerateForecastHistoryHelper(currentValue, growthRate, periods - 1, history);
            double nextValue = currentValue * (1 + growthRate);
            history.Insert(history.Count, nextValue);
            currentValue = nextValue;
        }

        // Calculate year-by-year breakdown
        public static void DisplayForecastBreakdown(double initialValue, double growthRate, int years)
        {
            Console.WriteLine("\n=== Financial Forecast Breakdown ===");
            Console.WriteLine($"Initial Value: ${initialValue}");
            Console.WriteLine($"Growth Rate: {growthRate * 100}%");
            Console.WriteLine($"Forecast Period: {years} years");
            Console.WriteLine("----------------------------------------");
            
            DisplayForecastYear(initialValue, growthRate, years, 0);
            
            double finalValue = CalculateFutureValueFormula(initialValue, growthRate, years);
            double totalGrowth = finalValue - initialValue;
            double percentageGrowth = (totalGrowth / initialValue) * 100;
            
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Final Value: ${finalValue:F2}");
            Console.WriteLine($"Total Growth: ${totalGrowth:F2}");
            Console.WriteLine($"Percentage Growth: {percentageGrowth:F2}%");
            Console.WriteLine("========================================\n");
        }

        private static void DisplayForecastYear(double currentValue, double growthRate, int totalYears, int currentYear)
        {
            if (currentYear > totalYears)
            {
                return;
            }

            double yearValue = CalculateFutureValueFormula(currentValue, growthRate, 1);
            Console.WriteLine($"Year {currentYear + 1}: ${yearValue:F2}");
            
            DisplayForecastYear(yearValue, growthRate, totalYears, currentYear + 1);
        }
    }
}