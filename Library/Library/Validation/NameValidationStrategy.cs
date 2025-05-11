using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class NameValidationStrategy : IValidationStrategy
{
    public bool Validate(string input)
    {
        string pattern = @"^[a-zA-Z\s]{2,}$";
        Regex regex = new Regex(pattern);

        if (!regex.IsMatch(input))
        {
            throw new ValidationException("Name must only contain letters and spaces, and be at least 2 characters long.");
        }

        return true;
    }
}
