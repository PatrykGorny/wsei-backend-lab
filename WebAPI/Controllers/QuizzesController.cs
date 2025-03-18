using BackendLab01;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/v1/quizzes")]
public class QuizzesController : ControllerBase
{
    private readonly IQuizUserService _service;

    public QuizzesController(IQuizUserService quizUserService)
    {
        _service = quizUserService;
    }
    
    [HttpGet]
    [Route("{id}")]
    public ActionResult<QuizDto> FindById(int id)
    {
        var quiz = _service.FindQuizById(id);

        if (quiz is null)
        {
            return NotFound();
        }
        
        var quizDto = QuizDto.of(quiz);
        return Ok(quizDto);
    }
}