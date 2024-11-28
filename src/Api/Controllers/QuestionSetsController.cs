using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Common;
using Models.DTOs.QuestionSets.Create;

namespace Api.Controllers
{
    public class QuestionSetsController : BaseApiController
    {
        private readonly IQuestionSetService _questionSetService;

        public QuestionSetsController(IQuestionSetService questionSetService)
        {
            _questionSetService = questionSetService;
        }
        [HttpPost]
        public IActionResult Create(QuestionSetCreateDto dto)
        {
            var response = _questionSetService.Create(dto);
            return Created("",ApiResponse.Success(response));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ApiResponse.Success(_questionSetService.GetAll()));
        }
    }
}
