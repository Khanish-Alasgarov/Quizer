using Models.DTOs.QuestionSets;
using Models.DTOs.QuestionSets.Create;
using System.Collections.Generic;

namespace Core.Services;

public interface IQuestionSetService
{
    public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    public IEnumerable<QuestionSetResponseDto> GetAll();
    
}
