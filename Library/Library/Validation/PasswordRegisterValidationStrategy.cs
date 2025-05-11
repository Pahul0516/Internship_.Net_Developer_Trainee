using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Validation
{
    public class PasswordRegisterValidationStrategy : IValidationStrategy
    {
        private readonly UserRepository _userRepository;

        public PasswordRegisterValidationStrategy(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Validate(string input)
        {
            // Check if the password is null or empty
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ValidationException("Password cannot be null or empty.");
            }

            // Check if the password is unique in the repository
            if (_userRepository.GetAll().Any(u => u.Password == input))
            {
                throw new ValidationException("Password is already in use.");
            }

            return true;
        }
    }
}
