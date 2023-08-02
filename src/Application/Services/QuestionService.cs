using Core.Extensions;
using Core.Repositories.Special;
using Core.Services;
using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.GetById;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;
using Models.Entities;

namespace Application.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IAnswerRepository _answerRepository;

    public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
    {
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
    }

    public QuestionCreateResponseDto Create(QuestionCreateDto request)
    {
        var response = _questionRepository.Add(request.ToEntity());

        return QuestionCreateResponseDto.Create(response);
    }

    public QuestionGetByIdResponseDto GetById(Guid Id)
    {
        var response = _questionRepository.Get(x => x.Id == Id);

        return QuestionGetByIdResponseDto.Create(response);


    }

    public void Remove(Guid Id)
    {
        var response = _questionRepository.Get(x => x.Id == Id);

        _questionRepository.Remove(response);
        _questionRepository.Save();
    }

    public void RemoveAnswer(Guid Id)
    {

    }

    public void Save(QuestionSaveDto request)
    {
        var question = _questionRepository.Get(x => x.Id == request.Id);
        _questionRepository.Edit(question, entry =>
        {
            entry.SetValue(m => m.Text, request.Text)
                 .SetValue(m => m.Point, request.Point)
                 .SetValue(m => m.QuestionSetId, request.QuestionSetId);
        });

        var correctAnswer = _answerRepository.Get(m => m.Id == request.CorrectAnswerId,false);
        if (correctAnswer!=null)
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

        
    }

    public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request)
    {
        var answer = _answerRepository.Get(m => m.Id == request.Id,false);

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
}
