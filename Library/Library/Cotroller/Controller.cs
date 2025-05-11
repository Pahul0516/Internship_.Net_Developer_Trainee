using Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Controller : IObservable
{

    private readonly List<IObserver> observers = new(); 
    UserRepository _userRepository;
    BookRepository _bookRepository;
    BorrowRepository _borrowRepository;

    public Controller(UserRepository userRepository, BookRepository bookRepository, BorrowRepository borrowRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _borrowRepository = borrowRepository;
    }

    public User GetUserByEmail(string email)
    {
        return _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
    }

    internal List<Book> GetAllBooks()
    {
        return _bookRepository.GetAll().ToList();
    }

    internal List<DTOBook> GetAllBorrowedBooks(User user)
    {
        List<DTOBook> borrowedBooks = new List<DTOBook>();

        var borrows = _borrowRepository.GetAll();

        var map = _borrowRepository.GetBorrowedBooksWithDetailsByUser(user.Id, _bookRepository);
        foreach (var entry in map)
        {
            Book book = entry.Key;
            int quantity = entry.Value;

            DTOBook dtoBook = new DTOBook(book.Title, book.Author, quantity);
            dtoBook.Id = book.Id;
            borrowedBooks.Add(dtoBook);
        }

        return borrowedBooks;
    }

    public void BorrowBook(User user, Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book), "Book cannot be null");
        }
        if (book.Quantity <= 0)
        {
            throw new InvalidOperationException("No available copies of the book to borrow.");
        }
        book.Quantity--;
        _bookRepository.Update(book);
        _bookRepository.WriteToCsv();
        Borrow borrow = new Borrow(user.Id, book.Id);
        _borrowRepository.Add(borrow);
        _borrowRepository.WriteToCsv();
    }

    public void removeBorrowBook(User user, DTOBook dTOBook)
    {
        dTOBook.Quantity--;

        var borrow = _borrowRepository.GetByUserAndBook(user, dTOBook);
        _borrowRepository.Delete(borrow.Id);
        _borrowRepository.WriteToCsv();

        Book book = _bookRepository.GetById(dTOBook.Id);
        book.Quantity++;
        _bookRepository.Update(book);
        _bookRepository.WriteToCsv();

    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
            observer.UpdateObserver();
    }

    public int HowManyBooksAreSelected(Book book)
    {
        int cont = -1;
        foreach (var observer in observers)
            if (book == observer.WhatBook()){
                cont++;
            }
        return cont;
    }

    public void modifiedBook(Book? book)
    {
        _bookRepository.Update(book);
        _bookRepository.WriteToCsv();
    }

    public BookRepository getBookRepo()
    {
        return _bookRepository;
    }

    internal void addBook(string name, string author, int quantity)
    {
        Book book = new Book(name, author, quantity);
        _bookRepository.Add(book);
        _bookRepository.WriteToCsv();
    }

    internal void DeleteBook(int id)
    {
        _bookRepository.Delete(id);
    }

    internal UserRepository getUserRepo()
    {
        return _userRepository;
    }

    public void addUser(string name, string email, string password)
    {
        User user = new User(name, email, password);
        _userRepository.Add(user);
        _userRepository.WriteToCsv();
    }
}

