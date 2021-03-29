﻿using Colaboradix.Application.Common.Models;
using Colaboradix.Application.Common.UseCases;
using System;

namespace Colaboradix.Application.UseCases.Commands.CreateUser
{
    public class CreateUserCommand : ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? ProjectId { get; set; }
        public Guid? TeamId { get; set; }

        public Result IsValid()
        {
            var validationResult = new CreateUserCommandValidator().Validate(this);

            return Result.FromValidationResult(validationResult);
        }
    }
}
