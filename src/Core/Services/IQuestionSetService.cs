using Models.DTOs.QuestionSet.Create;

namespace Core.Services;

public interface IQuestionSetService
{
    public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    
}
