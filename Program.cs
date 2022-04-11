using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork42
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStorage bookStorage = new BookStorage(new List<Book>(0));

            bookStorage.AccessStorage();
        }
    }

    class BookStorage
    {
        private List<Book> _allBooks = new List<Book>();

        public BookStorage(List<Book> allBooks)
        {
            _allBooks = allBooks;
        }

        public void AccessStorage()
        {
            const string AddBook = "addbook";
            const string RemoveBook = "removebook";
            const string ShowAll = "showall";
            const string FindByTitle = "findbytitle";
            const string FindByAuthor = "findbyauthor";
            const string FindByReleaseYear = "findbyyear";
            const string ExitCommand = "exit";
            string userInput = null;

            while (userInput != ExitCommand)
            {
                Console.WriteLine($"Вам доступны следующие команды:\n" +
                    $"{AddBook} - добавить книгу\n" +
                    $"{RemoveBook} - убрать книгу\n" +
                    $"{ShowAll} - показать все книги\n" +
                    $"{FindByTitle} - найти по названию\n" +
                    $"{FindByAuthor} - найти по автору\n" +
                    $"{FindByReleaseYear} - найти по году выпуска\n" +
                    $"{ExitCommand} - выйти\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBook:
                        this.AddBook();
                        break;

                    case RemoveBook:
                        this.RemoveBook();
                        break;

                    case ShowAll:
                        this.ShowAll();
                        break;

                    case FindByTitle:
                        this.FindByTitle();
                        break;

                    case FindByAuthor:
                        this.FindByAuthor();
                        break;

                    case FindByReleaseYear:
                        this.FindByReleaseYear();
                        break;

                    case ExitCommand:
                        break;

                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }

        }

        private void AddBook()
        {
            Console.WriteLine("Введите название книги");
            string title = Console.ReadLine();
            Console.WriteLine("Введите автора");
            string author = Console.ReadLine();
            Console.WriteLine("Введите год выпуска");
            int releaseYear = Convert.ToInt32(Console.ReadLine());

            _allBooks.Add(new Book(title, author, releaseYear));
            Console.WriteLine("Книга добавлена\n");
        }

        private void RemoveBook()
        {
            if (_allBooks.Count > 0)
            {
                Console.WriteLine("Введите название книги, которую хотите убрать");
                string title = Console.ReadLine();

                foreach (var book in _allBooks)
                {
                    if (book.Title == title)
                    {
                        _allBooks.Remove(book);
                        Console.WriteLine("Книга удалена\n");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("В хранилище пока нет книг\n");
            }
        }

        private void ShowAll()
        {
            if (_allBooks.Count > 0)
            {
                foreach (var book in _allBooks)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("В хранилище пока нет книг");
            }

            Console.WriteLine();
        }

        private void FindByTitle()
        {
            Console.WriteLine("Введите название");
            string title = Console.ReadLine();

            foreach (var book in _allBooks)
            {
                if (book.Title == title)
                {
                    book.ShowInfo();
                }
            }

            Console.WriteLine();
        }

        private void FindByAuthor()
        {
            Console.WriteLine("Введите автора");
            string author = Console.ReadLine();

            foreach (var book in _allBooks)
            {
                if (book.Author == author)
                {
                    book.ShowInfo();
                }
            }

            Console.WriteLine();
        }

        private void FindByReleaseYear()
        {
            Console.WriteLine("Введите год выпуска");
            int releaseYear = Convert.ToInt32(Console.ReadLine());

            foreach (var book in _allBooks)
            {
                if (book.ReleaseYear == releaseYear)
                {
                    book.ShowInfo();
                }
            }

            Console.WriteLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private int _releaseYear;

        public string Title => _title;
        public string Author => _author;
        public int ReleaseYear => _releaseYear;

        public Book(string title, string author, int releaseYear)
        {
            _title = title;
            _author = author;
            _releaseYear = releaseYear;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название - {_title}, Автор - {_author}, Год выпуска - {_releaseYear}");
        }
    }
}
