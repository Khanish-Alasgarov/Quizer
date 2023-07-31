using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Questions.Create;

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
    [HttpGet("{id}")]
    public IActionResult GetById([FromQuery]Guid id)
    {
        var response = _questionService.GetById(id);
        return Ok(response);
    }
}
