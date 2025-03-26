using ApplicationCore.Interfaces.AdminService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz;

public class QuizList : PageModel
{
    private readonly IQuizAdminService _quizAdminService;

    public QuizList(IQuizAdminService quizAdminService)
    {
        _quizAdminService = quizAdminService;
    }

    public  List<ApplicationCore.Models.QuizAggregate.Quiz> quizList { get; set; }

    public void OnGet()
    {
        quizList = _quizAdminService.FindAllQuizzes();
    }
}