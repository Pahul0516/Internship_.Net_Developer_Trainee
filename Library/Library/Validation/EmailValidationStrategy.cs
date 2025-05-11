using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class EmailValidationStrategy : IValidationStrategy
{
    public bool Validate(string input)
    {
        //string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        //Regex regex = new Regex(pattern);

        //if (!regex.IsMatch(input))
        //{
        //    throw new ValidationException("Invalid email format.");
        //}

        return true;
    }
}
