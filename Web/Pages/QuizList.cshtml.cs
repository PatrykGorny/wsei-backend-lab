
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class QuizListModel : PageModel
{
    private readonly IQuizUserService _quizService;

    public QuizListModel(IQuizUserService quizService)
    {
        _quizService = quizService;
    }

    public List<Quiz> Quizzes { get; set; } = new List<Quiz>();

    public void OnGet()
    {
        var availableQuizzes = _quizService.FindAllQuizzes();
        if (availableQuizzes != null)
        {
            Quizzes = availableQuizzes.ToList();
        }
    }
}