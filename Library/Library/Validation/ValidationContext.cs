using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ValidationContext
{
    private IValidationStrategy _strategy;

    public ValidationContext(IValidationStrategy strategy)
    {
        _strategy = strategy;
    }

    public bool ExecuteValidation(string input)
    {
        return _strategy.Validate(input);
    }

    public void SetStrategy(IValidationStrategy strategy)
    {
        _strategy = strategy;
    }
}
