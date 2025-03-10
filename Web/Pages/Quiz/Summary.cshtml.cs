using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    private readonly IQuizUserService _userService;

    public Summary(IQuizUserService userService)
    {
        _userService = userService;
    }

    [BindProperty(SupportsGet = true)]
    public int QuizId { get; set; }
    
    public int CorrectAnswers { get; set; }
    public int TotalQuestions { get; set; }
    public string? QuizTitle { get; set; }

    public void OnGet()
    {
        var quiz = _userService.FindQuizById(QuizId);
        if (quiz != null)
        {
            QuizTitle = quiz.Title;
            TotalQuestions = quiz.Items.Count;
            CorrectAnswers = _userService.CountCorrectAnswersForQuizFilledByUser(QuizId, 1);
        }
    }
}