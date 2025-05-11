using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BorrowRepository : IRepository<Borrow, int>
{
    private readonly List<Borrow> _borrows = new();
    private int _nextId = 1;
    private readonly string _filePath;

    public BorrowRepository(string filePath)
    {
        _filePath = filePath;
        ReadFromCsv();
    }

    public void Add(Borrow borrow)
    {
        borrow.Id = _nextId++;
        _borrows.Add(borrow);
    }

    public Borrow GetById(int id) => _borrows.FirstOrDefault(b => b.Id == id);

    public IEnumerable<Borrow> GetAll() => _borrows;

    public void Update(Borrow borrow)
    {
        var index = _borrows.FindIndex(b => b.Id == borrow.Id);
        if (index != -1)
        {
            _borrows[index] = borrow;
        }
    }

    public void Delete(int id)
    {
        _borrows.RemoveAll(b => b.Id == id);
    }

    public void ReadFromCsv()
    {
        if (!File.Exists(_filePath)) return;

        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3)
            {
                var id = int.Parse(parts[0].Trim());
                var userId = int.Parse(parts[1].Trim());
                var bookId = int.Parse(parts[2].Trim());

                var borrow = new Borrow(userId, bookId) { Id = id };
                _borrows.Add(borrow);
                _nextId = Math.Max(_nextId, id + 1);
            }
        }
    }


    public void WriteToCsv()
    {
        var lines = new List<string>();

        foreach (var borrow in _borrows)
        {
            var line = $"{borrow.Id},{borrow.UserId},{borrow.BookId}";
            lines.Add(line);
        }

        File.WriteAllLines(_filePath, lines);
    }


    public Dictionary<Book, int> GetBorrowedBooksWithDetailsByUser(int userId, BookRepository bookRepository)
    {
        return _borrows
            .Where(b => b.UserId == userId)
            .GroupBy(b => b.BookId)
            .Select(g => new
            {
                Book = bookRepository.GetById(g.Key),
                Count = g.Count()
            })
            .Where(x => x.Book != null)
            .ToDictionary(x => x.Book, x => x.Count);
    }

    public Borrow GetByUserAndBook(User user, DTOBook dTOBook)
    {
        return _borrows.FirstOrDefault(b => b.UserId == user.Id && b.BookId == dTOBook.Id);
    }
}
