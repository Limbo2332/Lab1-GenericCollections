﻿using FluentValidation;
using NewsSite.BLL.Interfaces;
using NewsSite.DAL.Constants;
using NewsSite.DAL.DTO.Request.Auth;
using NewsSite.UI.Extensions;

namespace NewsSite.UI.Validators.Request.Auth
{
    public class UserLoginRequestValidator : AbstractValidator<UserLoginRequest>
    {
        public UserLoginRequestValidator()
        {
            RuleFor(ur => ur.Email)
                .CustomEmail();

            RuleFor(ur => ur.Password)
                .CustomPassword();
        }
    }
}