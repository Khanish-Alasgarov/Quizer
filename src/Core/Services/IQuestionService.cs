using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.GetById;

namespace Core.Services;

public interface IQuestionService
{
    QuestionCreateResponseDto Create(QuestionCreateDto request);
    QuestionGetByIdResponseDto GetById(Guid Id);
}
