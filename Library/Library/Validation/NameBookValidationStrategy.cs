using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Validation
{
    class NameBookValidationStrategy : IValidationStrategy
    {
        private BookRepository _bookRepository;
        public NameBookValidationStrategy(BookRepository bookRepo)
        {
            _bookRepository = bookRepo;
        }

        public bool Validate(string input)
        {
            bool exists = _bookRepository.GetAll()
                .Any(book => book.Title.Equals(input, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                throw new ValidationException($"A book with the title \"{input}\" already exists.");
            }

            return true;
        }
    }
}
