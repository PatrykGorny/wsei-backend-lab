
using ApplicationCore.Models.QuizAggregate;

namespace WebAPI.Dto;

public class QuizItemDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public List<string> Options { get; set; }

    public static QuizItemDto of(QuizItem quiz)
    {
        var options = new List<string>(quiz.IncorrectAnswers) { quiz.CorrectAnswer };
        
        var random = new Random();
        options = options.OrderBy(_ => random.Next()).ToList();
        
        return new QuizItemDto()
        {
            Id = quiz.Id,
            Question = quiz.Question,
            Options = options
        };
    }
}