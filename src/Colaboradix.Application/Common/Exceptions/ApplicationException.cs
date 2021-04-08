using System;
using System.Collections.Generic;
using Colaboradix.Application.Common.Constants;
using FluentValidation.Results;

namespace Colaboradix.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base(ApplicationErrors.ValidationFailures)
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            if(failures is null) { return; }

            foreach(var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

        public IList<string> Errors { get; } = new List<string>();
    }
}
