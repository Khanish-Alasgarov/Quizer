using Core.Extensions;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;
using Models.Entities;

namespace Api.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    [HttpPost]
    public IActionResult Create(QuestionCreateDto dto)
    {
        var response = _questionService.Create(dto);
        return Ok(response);
    }
    [HttpPost]
    public IActionResult Save(QuestionSaveDto dto)
    {
        _questionService.Save(dto);
        return NoContent();

    }

    [HttpPost]
    public IActionResult SaveAnswer(QuestionSaveAnswerDto dto)
    {
        var response = _questionService.SaveAnswer(dto);
        return Ok(response);

    }


    [HttpGet("{id}")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var response = _questionService.GetById(id);
        return Ok(response);
    }

    [HttpPatch]
    public IActionResult ChangeQuestion(Guid id, string text)
    {
        //var entity = repository.Get(x => x.Id == id);
        //repository.Edit(entity, entry =>
        //{
        //    entry.SetValue(m => m.Text, text);
        //});
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult RemoveAnswer(Guid id)
    {
        _questionService.RemoveAnswer(id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Remove(Guid id)
    {
        _questionService.Remove(id);
        return NoContent();

    }
}
