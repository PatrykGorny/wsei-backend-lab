using System.Collections;

namespace WebAPI.Dto;

public class QuizResultDto
{
    private int quizId;
    private int userId;
    private int totalQuestions;
    private IEnumerable answers;
}