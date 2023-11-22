using Core.Repositories.Special;
using Core.Services;
using Models.DTOs.QuestionSets;
using Models.DTOs.QuestionSets.Create;
using Models.Entities;

namespace Application.Services;

public class QuestionSetService : IQuestionSetService
{
    private readonly IQuestionSetRepository _questionSetRepository;

    public QuestionSetService(IQuestionSetRepository questionSetRepository)
    {
        _questionSetRepository = questionSetRepository;
    }

    public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request)
    {

        var response = _questionSetRepository.Add(request.ToEntity());

        _questionSetRepository.Save();
        return QuestionSetCreateResponseDto.Create(response);
    }

    public IEnumerable<QuestionSetResponseDto> GetAll()
    {
        return _questionSetRepository.GetAll().Select(x => new QuestionSetResponseDto
        {
            Id = x.Id,
            Subject = x.Subject,
        }).AsEnumerable();
    }
}
