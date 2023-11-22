using Models.Common.Paging;
using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.GetAll;
using Models.DTOs.Questions.GetById;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;
using Models.DTOs.Questions.Search;

namespace Core.Services;

public interface IQuestionService
{
    QuestionCreateResponseDto Create(QuestionCreateDto request);
    List<QuestionResponseDto> GetAll();
    public IPaginate Search(QuestionSearchDto searchDto);
    void Save(QuestionSaveDto request);
    QuestionGetByIdResponseDto GetById(Guid Id);
    QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request);
    void RemoveAnswer(Guid Id);
    void Remove(Guid Id);

}
