using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class LibrarySearch
    {
        // ==================== LINEAR SEARCH ====================
        public static Book? LinearSearchByTitle(Book[] books, string title)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Title == title)
                {
                    return books[i];
                }
            }
            return null;
        }

        public static List<Book> LinearSearchByTitlePartial(Book[] books, string title)
        {
            List<Book> results = new List<Book>();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Title.ToLower().Contains(title.ToLower()))
                {
                    results.Add(books[i]);
                }
            }
            return results;
        }

        public static Book? LinearSearchByAuthor(Book[] books, string author)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Author == author)
                {
                    return books[i];
                }
            }
            return null;
        }

        public static List<Book> LinearSearchByAuthorPartial(Book[] books, string author)
        {
            List<Book> results = new List<Book>();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Author.ToLower().Contains(author.ToLower()))
                {
                    results.Add(books[i]);
                }
            }
            return results;
        }

        public static (Book? found, int comparisons) LinearSearchWithCount(Book[] books, string title)
        {
            int comparisons = 0;
            for (int i = 0; i < books.Length; i++)
            {
                comparisons++;
                if (books[i].Title == title)
                {
                    return (books[i], comparisons);
                }
            }
            return (null, comparisons);
        }

        // ==================== BINARY SEARCH ====================
        public static Book? BinarySearchByTitle(Book[] sortedBooks, string title)
        {
            int left = 0;
            int right = sortedBooks.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int compare = string.Compare(sortedBooks[mid].Title, title, StringComparison.Ordinal);

                if (compare == 0)
                {
                    return sortedBooks[mid];
                }

                if (compare < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return null;
        }

        public static (Book? found, int comparisons) BinarySearchWithCount(Book[] sortedBooks, string title)
        {
            int left = 0;
            int right = sortedBooks.Length - 1;
            int comparisons = 0;

            while (left <= right)
            {
                comparisons++;
                int mid = left + (right - left) / 2;
                int compare = string.Compare(sortedBooks[mid].Title, title, StringComparison.Ordinal);

                if (compare == 0)
                {
                    return (sortedBooks[mid], comparisons);
                }

                if (compare < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return (null, comparisons);
        }

        public static Book[] SortBooksByTitle(Book[] books)
        {
            Book[] sortedBooks = new Book[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                sortedBooks[i] = books[i];
            }

            for (int i = 0; i < sortedBooks.Length - 1; i++)
            {
                for (int j = 0; j < sortedBooks.Length - i - 1; j++)
                {
                    if (string.Compare(sortedBooks[j].Title, sortedBooks[j + 1].Title, StringComparison.Ordinal) > 0)
                    {
                        Book temp = sortedBooks[j];
                        sortedBooks[j] = sortedBooks[j + 1];
                        sortedBooks[j + 1] = temp;
                    }
                }
            }

            return sortedBooks;
        }

        public static void DisplayBooks(Book[] books)
        {
            Console.WriteLine("\n=== Book List ===");
            Console.WriteLine($"Total Books: {books.Length}");
            Console.WriteLine("-----------------");
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].GetBookDetails()}");
            }
            Console.WriteLine("-----------------\n");
        }

        public static void DisplaySortedBooks(Book[] sortedBooks)
        {
            Console.WriteLine("\n=== Sorted Books (by Title) ===");
            Console.WriteLine($"Total Books: {sortedBooks.Length}");
            Console.WriteLine("-----------------");
            for (int i = 0; i < sortedBooks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedBooks[i].GetBookDetails()}");
            }
            Console.WriteLine("-----------------\n");
        }

        public static void DisplayResults(List<Book> results)
        {
            if (results.Count == 0)
            {
                Console.WriteLine("No books found");
                return;
            }

            Console.WriteLine($"Found {results.Count} book(s):");
            foreach (Book book in results)
            {
                Console.WriteLine($"  {book.GetBookDetails()}");
            }
        }
    }
}