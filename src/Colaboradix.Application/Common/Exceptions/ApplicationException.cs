using System;
using System.Collections.Generic;
using Colaboradix.Application.Common.Constants;
using Colaboradix.Application.Common.Models;
using FluentValidation.Results;

namespace Colaboradix.Application.Common.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException() : base(ApplicationErrors.ValidationFailures)
        {
        }

        public ApplicationException(IEnumerable<ValidationFailure> failures) : this()
        {
            ApplicationResponse = ApplicationResponse.FromValidationFailures(failures);
        }

        public ApplicationResponse ApplicationResponse { get; }
    }
}
