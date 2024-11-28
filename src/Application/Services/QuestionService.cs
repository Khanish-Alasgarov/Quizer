using Core.Extensions;
using Core.Repositories.Special;
using Core.Services;
using Models.Common.Paging;
using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.GetAll;
using Models.DTOs.Questions.GetById;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;
using Models.DTOs.Questions.Search;
using Models.Entities;

namespace Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;
    private readonly IQuestionSetRepository _questionSetRepository;

    public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository, IQuestionSetRepository questionSetRepository)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _questionSetRepository = questionSetRepository;
    }

    public QuestionCreateResponseDto Create(QuestionCreateDto request)
    {
        var response = _questionRepository.Add(request.ToEntity());

        _questionRepository.Save();
        return QuestionCreateResponseDto.Create(response);
    }

    public List<QuestionResponseDto> GetAll()
    {

        return _questionRepository.GetAll().Select(x => new QuestionResponseDto
        {
            Id = x.Id,
            Point = x.Point,
            Text = x.Text,
            QuestionSetId = x.QuestionSetId,
        }).ToList();
    }

    public QuestionGetByIdResponseDto GetById(Guid Id)
    {
        var response = _questionRepository.Get(x => x.Id == Id);
        response.Answers = _answerRepository.GetAll(x => x.QuestionId == Id).ToList();

        return QuestionGetByIdResponseDto.Create(response);


    }

    public void Remove(Guid Id)
    {
        var response = _questionRepository.Get(x => x.Id == Id);

        _questionRepository.Remove(response);
        var answers = _answerRepository.GetAll(x => x.QuestionId == Id);

        foreach (var item in answers)
        {
            _answerRepository.Remove(item);
        }

        _questionRepository.Save();
    }

    public void RemoveAnswer(Guid Id)
    {

    }

    public void Save(QuestionSaveDto request)
    {
        var question = _questionRepository.Get(x => x.Id == request.Id);

        _questionSetRepository.Get(x => x.Id == request.QuestionSetId);

        _questionRepository.Edit(question, entry =>
        {
            entry.SetValue(m => m.Text, request.Text)
                 .SetValue(m => m.Point, request.Point)
                 .SetValue(m => m.QuestionSetId, request.QuestionSetId);
        });



        if (request.CorrectAnswerId == null)
            goto end;




        var correctAnswer = _answerRepository.Get(m => m.Id == request.CorrectAnswerId, false);
        if (correctAnswer != null)
        {
            _answerRepository.Edit(correctAnswer, entry => entry.SetValue(m => m.IsCorrect, true));

            var otherAnswers = _answerRepository.GetAll(m => m.QuestionId == request.Id && m.Id != request.CorrectAnswerId).ToArray();

            foreach (var item in otherAnswers)
            {
                _answerRepository.Edit(item, entry =>
                {
                    entry.SetValue(m => m.IsCorrect, false);
                });
            }
        }
    end:
        _questionRepository.Save();


    }

    public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request)
    {
        var answer = request.Id == null ? null : _answerRepository.Get(m => m.Id == request.Id, false);

        if (answer == null)
        {
            answer = new Answer
            {
                Id = Guid.NewGuid(),
                IsCorrect = request.IsCorrect,
                Text = request.Text,
                QuestionId = request.QuestionId

            };
            _answerRepository.Add(answer);
        }
        else
        {
            _answerRepository.Edit(answer, entry =>
            {
                entry.SetValue(m => m.Text, request.Text);
                entry.SetValue(m => m.QuestionId, request.QuestionId);
                entry.SetValue(m => m.IsCorrect, request.IsCorrect);
            });
        }

        if (request.IsCorrect)
        {
            var otherAnswers = _answerRepository.GetAll(x => x.Id != request.Id &&
                x.QuestionId == request.QuestionId).ToList();

            foreach (var item in otherAnswers)
            {
                _answerRepository.Edit(item, entry =>
                {
                    entry.SetValue(m => m.IsCorrect, false);
                });
            }

        }
        _answerRepository.Save();

        return QuestionSaveAnswerResponseDto.Create(answer);

    }

    public IPaginate Search(QuestionSearchDto searchDto)
    {
        return _questionRepository.GetAll().OrderBy(m => m.Id).ToPaginate(searchDto);
    }
}
