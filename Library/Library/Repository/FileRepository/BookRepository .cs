using System;
using System.Collections.Generic;
using System.IO;

public class BookRepository : IRepository<Book, int>
{
    private readonly List<Book> _books = new();
    private int _nextId = 1;
    private readonly string _filePath;

    public BookRepository(string filePath)
    {
        _filePath = filePath;
        ReadFromCsv();
    }

    public void Add(Book book)
    {
        book.Id = _nextId++;
        _books.Add(book);
    }

    public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public IEnumerable<Book> GetAll() => _books;

    public void Update(Book book)
    {
        var index = _books.FindIndex(b => b.Id == book.Id);
        if (index != -1)
        {
            _books[index] = book;
        }
    }

    public void Delete(int id)
    {
        _books.RemoveAll(b => b.Id == id);
    }

    public void ReadFromCsv()
    {
        if (!File.Exists(_filePath)) return;

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 4)
            {
                var id = int.Parse(parts[0].Trim());
                var title = parts[1].Trim();
                var author = parts[2].Trim();
                var quantity = int.Parse(parts[3].Trim());

                var book = new Book(title, author, quantity) { Id = id };
                _books.Add(book);
                _nextId = Math.Max(_nextId, id + 1); 
            }
        }
    }

    public void WriteToCsv()
    {
        var lines = new List<string>();

        foreach (var book in _books)
        {
            var line = $"{book.Id},{book.Title},{book.Author},{book.Quantity}";
            lines.Add(line);
        }

        File.WriteAllLines(_filePath, lines);
    }
}
