using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;

namespace WebAPI;

public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            //TODO Utwórz trzy pytania typu QuizItem
            //TODO Dodaj je do quizItemRepo
            //TODO Utwórz obiekt klasy Quiz z kolekcją pytań dodanych do quizItemRepo
            //TODO Dodaj Quiz do quizRepo
            
            var quizItems1 = new List<QuizItem>
            {
                new QuizItem(1, "What is the first letter?", new List<string> { "B", "C", "D" }, "A"),
                new QuizItem(2, "What is my name?", new List<string> { "Ala", "Ma", "Kota" }, "Kuba"),
                new QuizItem(3, "Test question", new List<string> { "B", "C", "D" }, "A")
            };

            var quizItems2 = new List<QuizItem>
            {
                new QuizItem(4, "What is the capital of France?", new List<string> { "Berlin", "Madrid", "Lisbon" }, "Paris"),
                new QuizItem(5, "Which planet is known as the Red Planet?", new List<string> { "Venus", "Earth", "Jupiter" }, "Mars"),
                new QuizItem(6, "How many continents are there on Earth?", new List<string> { "5", "6", "4" }, "7")
            };

            foreach (var item in quizItems1.Concat(quizItems2))
            {
                quizItemRepo.Add(item);
            }

            quizRepo.Add(new Quiz(1, quizItems1, "General Knowledge Quiz"));
            quizRepo.Add(new Quiz(2, quizItems2, "Geography and Space Quiz"));
        }
    }
}