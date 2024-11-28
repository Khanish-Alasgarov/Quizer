using FluentValidation;
using Models.DTOs.Questions.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Questions
{
    internal class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Sual mətni qeyd edilməyib!")
            .MinimumLength(5).WithMessage("Sual mətni minimum 5 simvoldan ibarət olmalıdır!");

            RuleFor(x => x.Point)
                .GreaterThan(byte.MinValue).WithMessage("Sual balı 0 ola bilməz!")
                .LessThanOrEqualTo((byte)50).WithMessage("Sual balı 50 dən böyük ola bilməz!");

            RuleFor(x => x.QuestionSetId).Must((model, field) =>
            {
                return field != default;
            }).WithMessage("Sual kodu uyğun deyil!");
        }
    }
}
