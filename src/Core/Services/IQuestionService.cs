using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.GetById;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;

namespace Core.Services;

public interface IQuestionService
{
    QuestionCreateResponseDto Create(QuestionCreateDto request);
    void Save(QuestionSaveDto request);
    QuestionGetByIdResponseDto GetById(Guid Id);
    QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request);
    void RemoveAnswer(Guid Id);
    void Remove(Guid Id);

}
