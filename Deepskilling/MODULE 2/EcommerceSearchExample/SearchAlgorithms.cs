using System;

namespace EcommerceSearchExample
{
    public class SearchAlgorithms
    {
        public static int LinearSearchById(Product[] products, int productId)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && products[i].ProductId == productId)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LinearSearchByName(Product[] products, string productName)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && products[i].ProductName == productName)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int LinearSearchByCategory(Product[] products, string category)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] != null && products[i].Category == category)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearchById(Product[] sortedProducts, int productId)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedProducts[mid] == null)
                {
                    left = mid + 1;
                    continue;
                }

                if (sortedProducts[mid].ProductId == productId)
                {
                    return mid;
                }

                if (sortedProducts[mid].ProductId < productId)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        public static int BinarySearchByName(Product[] sortedProducts, string productName)
        {
            int left = 0;
            int right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedProducts[mid] == null)
                {
                    left = mid + 1;
                    continue;
                }

                int comparison = sortedProducts[mid].ProductName.CompareTo(productName);

                if (comparison == 0)
                {
                    return mid;
                }

                if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

        public static Product[] SortProductsById(Product[] products)
        {
            Product[] sortedProducts = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                sortedProducts[i] = products[i];
            }

            for (int i = 0; i < sortedProducts.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < sortedProducts.Length; j++)
                {
                    if (sortedProducts[j] != null && sortedProducts[minIndex] != null)
                    {
                        if (sortedProducts[j].ProductId < sortedProducts[minIndex].ProductId)
                        {
                            minIndex = j;
                        }
                    }
                    else if (sortedProducts[j] != null && sortedProducts[minIndex] == null)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Product temp = sortedProducts[i];
                    sortedProducts[i] = sortedProducts[minIndex];
                    sortedProducts[minIndex] = temp;
                }
            }

            return sortedProducts;
        }

        public static Product[] SortProductsByName(Product[] products)
        {
            Product[] sortedProducts = new Product[products.Length];
            for (int i = 0; i < products.Length; i++)
            {
                sortedProducts[i] = products[i];
            }

            for (int i = 0; i < sortedProducts.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < sortedProducts.Length; j++)
                {
                    if (sortedProducts[j] != null && sortedProducts[minIndex] != null)
                    {
                        if (sortedProducts[j].ProductName.CompareTo(sortedProducts[minIndex].ProductName) < 0)
                        {
                            minIndex = j;
                        }
                    }
                    else if (sortedProducts[j] != null && sortedProducts[minIndex] == null)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    Product temp = sortedProducts[i];
                    sortedProducts[i] = sortedProducts[minIndex];
                    sortedProducts[minIndex] = temp;
                }
            }

            return sortedProducts;
        }
    }
}