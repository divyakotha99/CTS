using System;
using System.Collections.Generic;

namespace SortingCustomerOrders
{
    public class SortingAlgorithms
    {
        // ==================== BUBBLE SORT ====================
        public static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        Swap(orders, j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public static Order[] BubbleSortCopy(Order[] orders)
        {
            Order[] sortedOrders = new Order[orders.Length];
            for (int i = 0; i < orders.Length; i++)
            {
                sortedOrders[i] = orders[i];
            }

            BubbleSort(sortedOrders);
            return sortedOrders;
        }

        // ==================== QUICK SORT ====================
        public static void QuickSort(Order[] orders)
        {
            QuickSortHelper(orders, 0, orders.Length - 1);
        }

        private static void QuickSortHelper(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);
                QuickSortHelper(orders, low, pivotIndex - 1);
                QuickSortHelper(orders, pivotIndex + 1, high);
            }
        }

        private static int Partition(Order[] orders, int low, int high)
        {
            double pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice <= pivot)
                {
                    i++;
                    Swap(orders, i, j);
                }
            }

            Swap(orders, i + 1, high);
            return i + 1;
        }

        public static Order[] QuickSortCopy(Order[] orders)
        {
            Order[] sortedOrders = new Order[orders.Length];
            for (int i = 0; i < orders.Length; i++)
            {
                sortedOrders[i] = orders[i];
            }

            QuickSort(sortedOrders);
            return sortedOrders;
        }

        // ==================== BUBBLE SORT WITH COUNT ====================
        public static (Order[] sortedOrders, int comparisons, int swaps) BubbleSortWithCount(Order[] orders)
        {
            Order[] sortedOrders = new Order[orders.Length];
            for (int i = 0; i < orders.Length; i++)
            {
                sortedOrders[i] = orders[i];
            }

            int n = sortedOrders.Length;
            int comparisons = 0;
            int swaps = 0;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++;
                    if (sortedOrders[j].TotalPrice > sortedOrders[j + 1].TotalPrice)
                    {
                        Swap(sortedOrders, j, j + 1);
                        swaps++;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            return (sortedOrders, comparisons, swaps);
        }

        // ==================== QUICK SORT WITH COUNT ====================
        public static (Order[] sortedOrders, int comparisons, int swaps) QuickSortWithCount(Order[] orders)
        {
            Order[] sortedOrders = new Order[orders.Length];
            for (int i = 0; i < orders.Length; i++)
            {
                sortedOrders[i] = orders[i];
            }

            int comparisons = 0;
            int swaps = 0;
            QuickSortHelperWithCount(sortedOrders, 0, sortedOrders.Length - 1, ref comparisons, ref swaps);

            return (sortedOrders, comparisons, swaps);
        }

        private static void QuickSortHelperWithCount(Order[] orders, int low, int high, ref int comparisons, ref int swaps)
        {
            if (low < high)
            {
                comparisons++;
                int pivotIndex = Partition(orders, low, high);
                QuickSortHelperWithCount(orders, low, pivotIndex - 1, ref comparisons, ref swaps);
                QuickSortHelperWithCount(orders, pivotIndex + 1, high, ref comparisons, ref swaps);
            }
        }

        // ==================== HELPER METHODS ====================
        private static void Swap(Order[] orders, int i, int j)
        {
            Order temp = orders[i];
            orders[i] = orders[j];
            orders[j] = temp;
        }

        // Display all orders
        public static void DisplayOrders(Order[] orders)
        {
            Console.WriteLine("\n=== Order List ===");
            Console.WriteLine($"Total Orders: {orders.Length}");
            Console.WriteLine("------------------");
            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {orders[i].GetOrderDetails()}");
            }
            Console.WriteLine("------------------\n");
        }

        // Display sorted order details
        public static void DisplaySortedOrders(Order[] orders, string algorithmName)
        {
            Console.WriteLine($"\n=== Sorted by Total Price ({algorithmName}) ===");
            Console.WriteLine($"Total Orders: {orders.Length}");
            Console.WriteLine("------------------");
            for (int i = 0; i < orders.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {orders[i].GetOrderDetails()}");
            }
            Console.WriteLine("------------------\n");
        }
    }
}