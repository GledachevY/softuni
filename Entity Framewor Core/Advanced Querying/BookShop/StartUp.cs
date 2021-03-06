namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using BookShopContext db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

           // int asd = int.Parse(Console.ReadLine());

            int result = RemoveBooks(db);

            Console.WriteLine(result);

        }
        //problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> bookTitles = context
                .Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }
        //problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                }).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString();
        }
        //problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)

                .ToList();

            return String.Join(Environment.NewLine, books);
        }
        //problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();
            List<string> bookTitles = new List<string>();
            foreach (var item in categories)
            {
                List<string> currentCategoryBookTitles = context
                    .Books
                    .Where(b => b.BookCategories.Any(bk => bk.Category.Name.ToLower() == item))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currentCategoryBookTitles);
            }

            bookTitles = bookTitles.OrderBy(bt => bt).ToList();
            return String.Join(Environment.NewLine, bookTitles);
        }
        //problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();

            var books = context
                .Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,

                })

                .ToList();
            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString();
        }
        //problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in authors)
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }
            return sb.ToString().TrimEnd();
        }
        //problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {

            var titles = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, titles);
        }
        //problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titles = context
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in titles)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }
            return sb.ToString().TrimEnd();
        }
        //problem 11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.BookId)
                .ToList()
                .Count();

            return books;
        }
        //problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context
                .Authors
                .Select(a => new
                {
                    FullName = a.FirstName + ' ' + a.LastName,
                    BookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BookCopies)
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var author in copies)
            {
                sb.AppendLine($"{author.FullName} - {author.BookCopies}");
            }

            return sb.ToString().TrimEnd();
        }
        //problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profit = context
                .Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Select(cb => new
                    {
                        BookProfit = cb.Book.Copies * cb.Book.Price
                    })
                    .Sum(cb => cb.BookProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in profit)
            {
                sb.AppendLine($"{item.Name} ${item.TotalProfit}");
            }

            return sb.ToString().TrimEnd();
        }
        //problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var recentBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Book = c.CategoryBooks.OrderByDescending(cb => cb.Book.ReleaseDate).Take(3).Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })


                })
                .OrderBy(c => c.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var b in recentBooks)
            {
                sb.AppendLine($"--{b.Name}");
                foreach (var item in b.Book)
                {
                    sb.AppendLine($"{item.Title} ({item.ReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        //problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context
                .Books
                .Where(b => b.Copies < 4200);

            int count = 0;
            foreach (var book in booksToRemove)
            {
                context.Books.Remove(book);
                count++;
            }
            context.SaveChanges();

            return count;
        }
    }
}
