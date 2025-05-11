using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DTOBook : Entity<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }

    public DTOBook(string title, string author, int quantity) : base(-1)
    {
        Title = title;
        Author = author;
        Quantity = quantity;
    }
}
