using FluentValidation;
using Models.DTOs.QuestionSets.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.QuestionSets
{
    public class QuestionSetCreateDtoValidator : AbstractValidator<QuestionSetCreateDto>
    {
        public QuestionSetCreateDtoValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Sorğu kolleksiyası üçün mövzu təyin edilməyib!")
                .MinimumLength(5).WithMessage("Mövzu ən az 5 simvoldan ibarət olmalıdır!");

        }
    }
}
