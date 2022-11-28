using FluentValidation;
using Project.FluentValidation.Models;

namespace Project.FluentValidation.FluentValidator
{
    public class AddressValidator:AbstractValidator<Adress>
    {
        public string EmptyMessage { get; } = "{PropertyName} alanı boş olamaz.";
        public AddressValidator()
        {
            RuleFor(x => x.ContentAdress).NotEmpty().WithMessage(EmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(EmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(EmptyMessage).MaximumLength(5).WithMessage("{PropertyName} alanı en fazla {MaxLength} karakter olmalıdır.");
        }
    }
}
