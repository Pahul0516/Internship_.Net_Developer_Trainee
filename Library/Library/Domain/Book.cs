using System;

public class Book : Entity<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }

    public Book(string title, string author, int quantity) : base(-1)
    {
        Title = title;
        Author = author;
        Quantity = quantity;
    }
}
