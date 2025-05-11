using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Borrow : Entity<int>
{
    public int UserId { get; set; }
    public int BookId { get; set; }

    public Borrow(int userId, int bookId) : base(-1)
    {
        UserId = userId;
        BookId = bookId;
    }
}

