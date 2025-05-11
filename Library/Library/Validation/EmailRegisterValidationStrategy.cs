using Library.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EmailRegisterValidationStrategy : IValidationStrategy
{
    private readonly UserRepository _userRepository;

    public EmailRegisterValidationStrategy(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool Validate(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ValidationException("Email cannot be null or empty.");
        }

        if (!input.Contains("@"))
        {
            throw new ValidationException("Email must contain '@'.");
        }

        if (_userRepository.GetAll().Any(u => u.Email == input))
        {
            throw new ValidationException("Email is already in use.");
        }

        return true;
    }
}
