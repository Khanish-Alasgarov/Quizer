using Core.Attributes;
using Core.Extensions;
using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Models.Common;
using Models.DTOs.Questions.Create;
using Models.DTOs.Questions.Save;
using Models.DTOs.Questions.SaveAnswer;
using Models.DTOs.Questions.Search;
using Models.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Api.Controllers;
[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
public class QuestionsController : BaseApiController
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost]
    public IActionResult Search(QuestionSearchDto requestModel)
    {
        var data = _questionService.Search(requestModel);
        return Ok(ApiResponse.Success(data));
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [SwaggerOperation(
        Summary ="Yeni sual hazırlamaq",
        Description ="Yeni sual hazırlamaq üçün qeyd olunmuş model ile məlumatlar göndərilməlidir."
        )]
    [ProducesResponseType(typeof(ApiResponse<QuestionCreateResponseDto>),StatusCodes.Status200OK)]

    [Produces(MediaTypeNames.Application.Json)]
    public IActionResult Create(QuestionCreateDto dto)
    {
        var response = _questionService.Create(dto);
        return Ok(ApiResponse.Success(response));
    }
    [HttpPost]
    [Transaction]
    public IActionResult Save(QuestionSaveDto dto)
    {
        _questionService.Save(dto);
        return NoContent();

    }

    [HttpPost]
    [Transaction]
    public IActionResult SaveAnswer(QuestionSaveAnswerDto dto)
    {
        var response = _questionService.SaveAnswer(dto);
        return Ok(response);

    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(ApiResponse.Success(_questionService.GetAll()));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var response = _questionService.GetById(id);
        return Ok(ApiResponse.Success(response));
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
    [Transaction]
    public IActionResult Remove(Guid id)
    {
        _questionService.Remove(id);
        return NoContent();

    }
}
