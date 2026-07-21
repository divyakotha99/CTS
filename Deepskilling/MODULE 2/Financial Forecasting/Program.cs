using System;

namespace FinancialForecastingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Financial Forecasting Tool ===\n");

            ExplainRecursion();

            TestBasicForecasting();

            TestVaryingGrowthRates();

            TestOptimizedApproaches();

            AnalyzeTimeComplexity();

            Console.WriteLine("\n=== Financial Forecasting Complete ===");
        }

        static void ExplainRecursion()
        {
            Console.WriteLine("\n1. RECURSION CONCEPT EXPLANATION");
            Console.WriteLine("==================================");
            Console.WriteLine("What is Recursion?");
            Console.WriteLine("  Recursion is a programming technique where a method calls itself to solve a problem.");
            Console.WriteLine("  It breaks down complex problems into smaller, simpler instances of the same problem.");
            Console.WriteLine("");
            Console.WriteLine("Key Components of Recursion:");
            Console.WriteLine("  1. Base Case: The condition when recursion stops (prevents infinite loops)");
            Console.WriteLine("  2. Recursive Case: When the method calls itself with modified parameters");
            Console.WriteLine("  3. Recursive Call: The actual call to the same method");
            Console.WriteLine("");
            Console.WriteLine("How Recursion Simplifies Problems:");
            Console.WriteLine("  - Breaks complex problems into simpler sub-problems");
            Console.WriteLine("  - Natural fit for problems with recursive structure");
            Console.WriteLine("  - Cleaner, more readable code for certain algorithms");
            Console.WriteLine("  - Eliminates need for explicit loops in some cases");
            Console.WriteLine("");
            Console.WriteLine("Common Use Cases:");
            Console.WriteLine("  - Mathematical calculations (factorials, Fibonacci)");
            Console.WriteLine("  - Tree and graph traversals");
            Console.WriteLine("  - Search algorithms (binary search)");
            Console.WriteLine("  - Financial calculations (compound interest)");
            Console.WriteLine("  - File system navigation");
            Console.WriteLine("");
            Console.WriteLine("Recursion in Financial Forecasting:");
            Console.WriteLine("  - Each year's value depends on previous year's value");
            Console.WriteLine("  - Natural recursive structure: F(n) = F(n-1) * (1 + growthRate)");
            Console.WriteLine("  - Base case: F(0) = initialValue");
            Console.WriteLine("");
        }

        static void TestBasicForecasting()
        {
            Console.WriteLine("\n2. BASIC FINANCIAL FORECASTING TESTS");
            Console.WriteLine("====================================");

            // Test 1: Simple compound growth
            Console.WriteLine("\nTest 1: Simple Compound Growth (Fixed Rate)");
            double initialValue1 = 10000;
            double growthRate1 = 0.05;
            int periods1 = 5;

            Console.WriteLine($"Initial Value: ${initialValue1}");
            Console.WriteLine($"Growth Rate: {growthRate1 * 100}%");
            Console.WriteLine($"Periods: {periods1} years");

            double recursiveResult1 = FinancialForecast.CalculateFutureValueRecursive(initialValue1, growthRate1, periods1);
            double formulaResult1 = FinancialForecast.CalculateFutureValueFormula(initialValue1, growthRate1, periods1);

            Console.WriteLine($"Recursive Result: ${recursiveResult1:F2}");
            Console.WriteLine($"Formula Result: ${formulaResult1:F2}");
            Console.WriteLine($"Difference: ${Math.Abs(recursiveResult1 - formulaResult1):F2}");

            // Display breakdown
            FinancialForecast.DisplayForecastBreakdown(initialValue1, growthRate1, periods1);

            // Test 2: Higher growth rate
            Console.WriteLine("\nTest 2: Higher Growth Rate");
            double initialValue2 = 50000;
            double growthRate2 = 0.10;
            int periods2 = 10;

            Console.WriteLine($"Initial Value: ${initialValue2}");
            Console.WriteLine($"Growth Rate: {growthRate2 * 100}%");
            Console.WriteLine($"Periods: {periods2} years");

            double recursiveResult2 = FinancialForecast.CalculateFutureValueRecursive(initialValue2, growthRate2, periods2);
            double formulaResult2 = FinancialForecast.CalculateFutureValueFormula(initialValue2, growthRate2, periods2);

            Console.WriteLine($"Recursive Result: ${recursiveResult2:F2}");
            Console.WriteLine($"Formula Result: ${formulaResult2:F2}");

            // Test 3: Longer forecast period
            Console.WriteLine("\nTest 3: Long-term Forecast (20 years)");
            double initialValue3 = 100000;
            double growthRate3 = 0.07;
            int periods3 = 20;

            double recursiveResult3 = FinancialForecast.CalculateFutureValueRecursive(initialValue3, growthRate3, periods3);
            double formulaResult3 = FinancialForecast.CalculateFutureValueFormula(initialValue3, growthRate3, periods3);

            Console.WriteLine($"Initial Value: ${initialValue3}");
            Console.WriteLine($"Growth Rate: {growthRate3 * 100}%");
            Console.WriteLine($"Periods: {periods3} years");
            Console.WriteLine($"Recursive Result: ${recursiveResult3:F2}");
            Console.WriteLine($"Formula Result: ${formulaResult3:F2}");
        }

        static void TestVaryingGrowthRates()
        {
            Console.WriteLine("\n3. VARYING GROWTH RATES TESTS");
            Console.WriteLine("==============================");

            // Test with different growth rates each year
            Console.WriteLine("\nTest 1: Variable Growth Rates");
            double initialValue = 10000;
            double[] growthRates = { 0.03, 0.05, 0.07, 0.04, 0.06 };
            int periods = 5;

            Console.WriteLine($"Initial Value: ${initialValue}");
            Console.WriteLine($"Growth Rates: {string.Join(", ", growthRates)}");

            double recursiveResult = FinancialForecast.CalculateFutureValueVaryingRatesRecursive(initialValue, growthRates, periods);
            
            Console.WriteLine($"Recursive Result: ${recursiveResult:F2}");

            // Calculate manually for verification
            double manualCalc = initialValue;
            Console.WriteLine("\nManual Calculation:");
            for (int i = 0; i < periods; i++)
            {
                manualCalc = manualCalc * (1 + growthRates[i]);
                Console.WriteLine($"  Year {i + 1}: ${manualCalc:F2} (Rate: {growthRates[i] * 100}%)");
            }

            Console.WriteLine($"Manual Result: ${manualCalc:F2}");

            // Test 2: Forecast history
            Console.WriteLine("\nTest 2: Forecast History Generation");
            double initialHist = 5000;
            double growthHist = 0.08;
            int yearsHist = 7;

            var forecastHistory = FinancialForecast.GenerateForecastHistory(initialHist, growthHist, yearsHist);

            Console.WriteLine($"Initial Value: ${initialHist}");
            Console.WriteLine($"Growth Rate: {growthHist * 100}%");
            Console.WriteLine("\nYear-by-Year Forecast:");
            for (int i = 0; i < forecastHistory.Count; i++)
            {
                Console.WriteLine($"  Year {i}: ${forecastHistory[i]:F2}");
            }
        }

        static void TestOptimizedApproaches()
        {
            Console.WriteLine("\n4. OPTIMIZED APPROACHES TESTS");
            Console.WriteLine("==============================");

            // Test memoization
            Console.WriteLine("\nTest 1: Memoized vs Basic Recursive");
            double initialValue = 1000;
            double growthRate = 0.05;
            int periods = 15;

            Console.WriteLine($"Initial Value: ${initialValue}");
            Console.WriteLine($"Growth Rate: {growthRate * 100}%");
            Console.WriteLine($"Periods: {periods}");

            double basicRecursive = FinancialForecast.CalculateFutureValueRecursive(initialValue, growthRate, periods);
            double memoized = FinancialForecast.CalculateFutureValueMemoized(initialValue, growthRate, periods);
            double formula = FinancialForecast.CalculateFutureValueFormula(initialValue, growthRate, periods);

            Console.WriteLine($"Basic Recursive: ${basicRecursive:F2}");
            Console.WriteLine($"Memoized: ${memoized:F2}");
            Console.WriteLine($"Formula: ${formula:F2}");

            // Test varying rates with large dataset
            Console.WriteLine("\nTest 2: Large Dataset with Variable Rates");
            double initialLarge = 50000;
            double[] largeRates = new double[20];
            for (int i = 0; i < 20; i++)
            {
                largeRates[i] = 0.03 + (i * 0.005);
            }

            double resultLarge = FinancialForecast.CalculateFutureValueVaryingRatesRecursive(initialLarge, largeRates, 20);
            Console.WriteLine($"Initial Value: ${initialLarge}");
            Console.WriteLine($"Periods: 20 years");
            Console.WriteLine($"Result: ${resultLarge:F2}");
        }

        static void AnalyzeTimeComplexity()
        {
            Console.WriteLine("\n5. TIME COMPLEXITY ANALYSIS");
            Console.WriteLine("============================");

            Console.WriteLine("\nBasic Recursive Algorithm:");
            Console.WriteLine("  Time Complexity: O(n)");
            Console.WriteLine("  - Makes n recursive calls");
            Console.WriteLine("  - Each call does constant work (multiplication)");
            Console.WriteLine("  - Total: n * O(1) = O(n)");
            Console.WriteLine("");
            Console.WriteLine("  Space Complexity: O(n)");
            Console.WriteLine("  - Call stack depth: n levels");
            Console.WriteLine("  - Each call stores parameters and return value");
            Console.WriteLine("");

            Console.WriteLine("\nMemoized Recursive Algorithm:");
            Console.WriteLine("  Time Complexity: O(n)");
            Console.WriteLine("  - Still makes n calls, but avoids recomputation");
            Console.WriteLine("  - Dictionary lookup: O(1) average");
            Console.WriteLine("");
            Console.WriteLine("  Space Complexity: O(n)");
            Console.WriteLine("  - Call stack: O(n)");
            Console.WriteLine("  - Memoization dictionary: O(n)");
            Console.WriteLine("  - Total: O(n) + O(n) = O(n)");
            Console.WriteLine("");

            Console.WriteLine("\nDirect Formula (Non-recursive):");
            Console.WriteLine("  Time Complexity: O(1)");
            Console.WriteLine("  - Single mathematical operation (pow)");
            Console.WriteLine("  - No recursive calls");
            Console.WriteLine("");
            Console.WriteLine("  Space Complexity: O(1)");
            Console.WriteLine("  - No call stack");
            Console.WriteLine("  - Fixed number of variables");
            Console.WriteLine("");

            Console.WriteLine("\nOPTIMIZATION TECHNIQUES:");
            Console.WriteLine("========================");
            Console.WriteLine("");
            Console.WriteLine("1. memoization (Already Implemented):");
            Console.WriteLine("   - Store results of previous calculations");
            Console.WriteLine("   - Avoid recomputing same values");
            Console.WriteLine("   - Reduces time when same subproblems occur");
            Console.WriteLine("");
            Console.WriteLine("2. Convert to Iterative Approach:");
            Console.WriteLine("   - Replace recursion with loops");
            Console.WriteLine("   - Eliminates call stack overhead");
            Console.WriteLine("   - Better space complexity: O(1)");
            Console.WriteLine("");
            Console.WriteLine("3. Use Direct Formula:");
            Console.WriteLine("   - F(n) = F(0) * (1 + r)^n");
            Console.WriteLine("   - Most efficient: O(1) time and space");
            Console.WriteLine("   - Best for compound interest calculations");
            Console.WriteLine("");
            Console.WriteLine("4. Tail Recursion Optimization:");
            Console.WriteLine("   - Rewrite recursion to be tail-recursive");
            Console.WriteLine("   - Some compilers optimize tail recursion");
            Console.WriteLine("   - Reduces stack space usage");
            Console.WriteLine("");

            Console.WriteLine("\nWHICH APPROACH TO USE?");
            Console.WriteLine("======================");
            Console.WriteLine("");
            Console.WriteLine("For Financial Forecasting:");
            Console.WriteLine("  RECOMMENDATION: Use Direct Formula");
            Console.WriteLine("  - O(1) time and space complexity");
            Console.WriteLine("  - Most accurate (no accumulation of errors)");
            Console.WriteLine("  - Simple and efficient");
            Console.WriteLine("");
            Console.WriteLine("When to Use Recursive:");
            Console.WriteLine("  - Variable growth rates (each year different)");
            Console.WriteLine("  - Educational purposes (understanding recursion)");
            Console.WriteLine("  - Complex dependency on previous values");
            Console.WriteLine("");
            Console.WriteLine("Performance Comparison (n = 1000):");
            Console.WriteLine("  Basic Recursive: ~1000 stack operations");
            Console.WriteLine("  Memoized: ~1000 dictionary operations");
            Console.WriteLine("  Formula: 1 mathematical operation");
            Console.WriteLine("");
        }
    }
}