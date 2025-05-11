using Library.Gui;
using Microsoft.Extensions.Configuration;

namespace Library

{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string booksPath = config["CsvPaths:Books"];
            string usersPath = config["CsvPaths:Users"];
            string borrowingsPath = config["CsvPaths:Borrows"];

            var bookRepo = new BookRepository(booksPath);
            var userRepo = new UserRepository(usersPath);
            var borrowingRepo = new BorrowRepository(borrowingsPath);

            Controller controller = new Controller(userRepo, bookRepo, borrowingRepo);
            
            var books = bookRepo.GetAll();

            Console.WriteLine(books);

            ApplicationConfiguration.Initialize();
            var login = Login.GetInstance(controller);
            Application.Run(login);
        }
    }
}