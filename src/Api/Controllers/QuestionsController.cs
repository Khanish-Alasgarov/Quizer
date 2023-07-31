using Core.Extensions;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Questions.Create;
using Models.Entities;

namespace Api.Controllers;

public class QuestionsController : BaseApiController
{
    private readonly IQuestionService _questionService;
    private readonly Repository<Question> repository;

    public QuestionsController(IQuestionService questionService, Repository<Question> repository)
    {
        _questionService = questionService;
        this.repository = repository;
    }
    [HttpPost]
    public IActionResult Create(QuestionCreateDto dto)
    {
        var response = _questionService.Create(dto);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public IActionResult GetById([FromQuery]Guid id)
    {
        var response = _questionService.GetById(id);
        return Ok(response);
    }

    [HttpPatch]
    public IActionResult ChangeQuestion(Guid id,string text)
    {
        var entity = repository.Get(x => x.Id == id);
        repository.Edit(entity, entry =>
        {
            entry.SetValue(m => m.Text, text);
        });
        return NoContent();
    }
}
