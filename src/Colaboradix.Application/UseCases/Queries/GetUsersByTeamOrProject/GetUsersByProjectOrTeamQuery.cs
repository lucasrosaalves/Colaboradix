using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;
using Colaboradix.Domain.Dtos;
using System;
using System.Collections.Generic;

namespace Colaboradix.Application.UseCases.Queries.GetUsersByTeamOrProject
{
    public class GetUsersByProjectOrTeamQuery : IQuery<IEnumerable<UserDto>>
    {
        public Guid? ProjectId { get; set; }
        public Guid? TeamId { get; set; }

        public Result IsValid()
        {
            var validationResult = new GetUsersByTeamOrProjectQueryValidator().Validate(this);

            return Result.FromValidationResult(validationResult);
        }
    }
}
