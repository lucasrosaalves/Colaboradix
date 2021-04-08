using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Colaboradix.Application.Common.Models
{
    public class ApplicationResponse
    {
        internal ApplicationResponse(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public static ApplicationResponse Success()
        {
            return new ApplicationResponse(true, new string[] { });
        }

        public static ApplicationResponse Failure(IEnumerable<string> errors)
        {
            return new ApplicationResponse(false, errors);
        }

        public static ApplicationResponse Failure(string error)
        {
            return new ApplicationResponse(false, new[] { error });
        }

        public static ApplicationResponse FromValidationResult(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return Success();
            }

            return Failure(validationResult.Errors.Select(e => e.ErrorMessage).Distinct());
        }

        public static ApplicationResponse FromValidationFailures(IEnumerable<ValidationFailure> validationFailures)
        {
            if (validationFailures is null || !validationFailures.Any())
            {
                return Success();
            }

            return Failure(validationFailures.Select(e => e.ErrorMessage).Distinct());
        }
    }
}
