using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class PasswordValidationStrategy : IValidationStrategy
{
    public bool Validate(string input)
    {
        //string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        //Regex regex = new Regex(pattern);

        //if (!regex.IsMatch(input))
        //{
        //    throw new ValidationException("Password must be at least 8 characters, contain an uppercase letter, a lowercase letter, a digit, and a special character.");
        //}

        return true;
    }
}
