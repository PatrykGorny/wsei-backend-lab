using ApplicationCore.Interfaces.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages.Quiz;

public class Summary : PageModel
{
    private IQuizUserService _userService;

    public Summary(IQuizUserService userService)
    {
        _userService = userService;
    }

    public int CorrectAnswers { get; set; }
    public int TotalQuestions { get; set; }

    public IActionResult OnGet(int quizId,int itemId)
    {
        var quiz = _userService.FindQuizById(quizId);
        if (quiz == null)
        {
            return NotFound("Taki Quiz nie istnieje");
        }

        int userId = 1;
        var userAnswers = _userService.GetUserAnswersForQuiz(quizId, userId);

        TotalQuestions = quiz.Items.Count;

        CorrectAnswers = userAnswers.Count(a => a.IsCorrect());
        return Page();
    }
}