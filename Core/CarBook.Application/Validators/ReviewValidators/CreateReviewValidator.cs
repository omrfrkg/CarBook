﻿using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.ReytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz!");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz!");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız!");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter veri girişi yapınız!");

        }
    }
}
