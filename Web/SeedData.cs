using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;

namespace BackendLab01;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();

            List<QuizItem> quiz1_Items = new List<QuizItem>();
            quiz1_Items.Add(quizItemRepo.Add(new QuizItem(id: 1, correctAnswer: "A", incorrectAnswers: new List<string>(){"B", "C", "D"},question: "Pierwsza litera alfabetu?")));
            quiz1_Items.Add(quizItemRepo.Add(new QuizItem(id: 2, correctAnswer: "B", incorrectAnswers: new List<string>(){"A", "C", "D"},question: "Druga litera alfabetu?")));
            quiz1_Items.Add(quizItemRepo.Add(new QuizItem(id: 3, correctAnswer: "C", incorrectAnswers: new List<string>(){"B", "A", "D"},question: "Trzecia litera alfabetu?")));
            quizRepo.Add(new Quiz(id: 1, items: quiz1_Items, title: "Alfabet"));
            
            /*List<QuizItem> quiz2_Items = new List<QuizItem>();

            quiz2_Items.Add(quizItemRepo.Add(new QuizItem(id: 4, correctAnswer: "1", incorrectAnswers: new List<string>(){"4", "2", "3"},question: "Ile to jest 1 + 0?")));
            quiz2_Items.Add(quizItemRepo.Add(new QuizItem(id: 5, correctAnswer: "2", incorrectAnswers: new List<string>(){"1", "4", "3"},question: "Ile to jest 1 + 1?")));
            quiz2_Items.Add(quizItemRepo.Add(new QuizItem(id: 6, correctAnswer: "3", incorrectAnswers: new List<string>(){"1", "2", "4"},question: "Ile to jest 1 + 2?")));
            quizRepo.Add(new Quiz(id: 2, items: quiz2_Items, title: "Matematyka"));

            quizRepo.Add(new Quiz(id: 3, items: new List<QuizItem>(), title: "Test"));*/
            
        }
    }
}