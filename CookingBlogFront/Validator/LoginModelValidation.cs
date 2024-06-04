﻿using CookingBlogFront.Data;
using Blazored.FluentValidation;
using FluentValidation;

namespace CookingBlogFront.Validator
{
    public class LoginModelValidation : AbstractValidator<LoginModel>
    {
        public LoginModelValidation()
        {
            RuleFor(_ => _.Login).NotEmpty().WithMessage("Your login cannot be empty");
            RuleFor(p => p.Email).NotEmpty().WithMessage("You must enter a email address");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter valid an email");
            RuleFor(_ => _.Password).NotEmpty().WithMessage("Your password cannot be empty");
            RuleFor(_ => _.Password).MinimumLength(6).WithMessage("Your password length must be at least 6.");
            RuleFor(_ => _.Password).MaximumLength(16).WithMessage("Your password length must not exceed 16.");
            RuleFor(_ => _.Password).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.");
            RuleFor(_ => _.Password).Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.");
            RuleFor(_ => _.Password).Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
            RuleFor(_ => _.Password).Matches(@"[\@\!\?\*\.]+").WithMessage("Your password must contain at least one (@!? *.).");
        }
    }
}
