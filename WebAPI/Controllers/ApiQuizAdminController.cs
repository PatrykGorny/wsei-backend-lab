using System.Net;
using ApplicationCore.Interfaces.AdminService;
using ApplicationCore.Models.QuizAggregate;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;


namespace WebAPI.Controllers;

[Route("api/v1/admin/quizzes")]
[ApiController]
public class ApiQuizAdminController : Controller
{
    private readonly IQuizAdminService _service;
    private readonly IMapper _mapper;
    
    
    public ApiQuizAdminController(IQuizAdminService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    //GET
    [HttpGet]
    public ActionResult<List<Quiz>> Index()
    {
        return _service.FindAllQuizzes() is null ? NotFound() :_service.FindAllQuizzes()  ;
    }
    
    //POST
    [HttpPost]
    public ActionResult<object> AddQuiz(LinkGenerator link, NewQuizDto dto)
    {
        var quiz = _service.AddQuiz(_mapper.Map<Quiz>(dto));
        return Created(
            link.GetPathByAction(HttpContext, nameof(GetQuiz), null, new { quiId = quiz.Id }),
            quiz
        );
    }

    //GET
    [HttpGet]
    [Route("{quizId}")]
    public ActionResult<Quiz> GetQuiz(int quizId)
    {
        var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
        return quiz is null ? NotFound() : quiz;
    }
    
    //GET specific item from quiz 
    [HttpGet]
    [Route("{quizId}/{questionID}")]
    public ActionResult<QuizItem> GetQuizQuestion(int quizId, int questionID)
    {
        var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
        var question = quiz.Items.Where(i => i.Id == questionID).FirstOrDefault();
        return question is null ? NotFound() : question;
    }
    
    //PATCH
    [HttpPatch]
    [Route("{quizId}")]
    [Consumes("application/json-patch+json")]
    public ActionResult<Quiz> AddQuizItem(int quizId, JsonPatchDocument<Quiz>? patchDoc)
    {
        var quiz = _service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId);
        if (quiz is null || patchDoc is null)
        {
            return NotFound(new
            {
                error = $"Quiz width id {quizId} not found"
            });
        }
        int previousCount = quiz.Items.Count;
        patchDoc.ApplyTo(quiz, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (previousCount < quiz.Items.Count)
        {
            QuizItem item = quiz.Items[^1];
            quiz.Items.RemoveAt(quiz.Items.Count - 1);
            _service.AddQuizItemToQuiz(quizId, item);
        }
        return Ok(_service.FindAllQuizzes().FirstOrDefault(q => q.Id == quizId));
    }
    
    [HttpPut]
    [Route("{quizId}")]
    public ActionResult<Quiz> UpdateQuiz(int quizId, [FromBody] Quiz updatedQuiz)
    {
        try
        {
            var quiz = _service.UpdateQuiz(quizId, updatedQuiz);
            return Ok(quiz);
        }
        catch (Exception ex)
        {
            return NotFound(new { error = ex.Message });
        }
    }
    
    [HttpDelete]
    [Route("{quizId}")]
    public ActionResult  GetQuizQuestion(int quizId)
    {
        return _service.DeleteQuiz(quizId) ? NoContent() : BadRequest("Quiz have items");
    }
    
}