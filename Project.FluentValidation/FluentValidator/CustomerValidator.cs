﻿using FluentValidation;
using Project.FluentValidation.Models;

namespace Project.FluentValidation.FluentValidator
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(X=>X.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez."); //Boş geçilemez olsun.
            RuleFor(X=>X.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez.").EmailAddress().WithMessage("Mail formatı düzgün biçimde değil."); //Önce boş geçilemez kontrolü daha sonra da mail tip kontrolü yaptık abc@mail.com şeklinde bir alan olamlı dedik aslında
            RuleFor(x => x.Age).NotEmpty().WithMessage("Yaş alanı boş geçilemez.").InclusiveBetween(18, 60).WithMessage("Yaş aralığı 18 ile 60 arasında olmalıdır.");
        }
    }
}