using Models.DTOs.QuestionSets.Create;

namespace Core.Services;

public interface IQuestionSetService
{
    public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    
}
