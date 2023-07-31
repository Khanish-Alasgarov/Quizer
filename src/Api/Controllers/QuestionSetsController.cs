using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.QuestionSet.Create;

namespace Api.Controllers
{
    public class QuestionSetsController : BaseApiController
    {
        private readonly IQuestionSetService _questionSetService;

        public QuestionSetsController(IQuestionSetService questionSetService)
        {
            _questionSetService = questionSetService;
        }

        public IActionResult Create(QuestionSetCreateDto dto)
        {
            var response = _questionSetService.Create(dto);
            return Created("",response);
        }
    }
}
