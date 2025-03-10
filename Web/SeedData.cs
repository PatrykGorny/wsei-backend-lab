using ApplicationCore.Commons.Repository;
using ApplicationCore.Models.QuizAggregate;
using BackendLab01;

namespace Infrastructure.Memory;

public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            if (quizRepo != null && quizItemRepo != null)
            {
                var animalQuestion1 = new QuizItem(
                    1,
                    "Which of these animals can live without water for several months?",
                    new List<string> { "Elephant", "Penguin" }, 
                    "Kangaroo rat");

                var animalQuestion2 = new QuizItem(
                    2,
                    "What is the largest living species of lizard?",
                    new List<string> { "Iguana", "Monitor lizard" }, 
                    "Komodo dragon");

                var animalQuestion3 = new QuizItem(
                    3,
                    "Which animal has the longest migration of any mammal?",
                    new List<string> { "Caribou", "African elephant" },  
                    "Gray whale");

                quizItemRepo.Add(animalQuestion1);
                quizItemRepo.Add(animalQuestion2);
                quizItemRepo.Add(animalQuestion3);

                var AnimalsQuiz = new Quiz(
                    1,
                    new List<QuizItem> { animalQuestion1, animalQuestion2, animalQuestion3 },
                    " Animal Quiz");

                quizRepo.Add(AnimalsQuiz);

                var sportsQuestion1 = new QuizItem(
                    1,
                    "Which country won the 2018 FIFA World Cup?",
                    new List<string> { "Germany", "Brazil" },  
                    "France");

                var sportsQuestion2 = new QuizItem(
                    2,
                    "Which city hosted the 2008 Summer Olympics?",
                    new List<string> { "Athens","London" },  
                    "Beijing");

                var sportsQuestion3 = new QuizItem(
                    3,
                    "Who holds the record for most Grand Slam singles titles in tennis?",
                    new List<string> {"Serena Williams", "Rafael Nadal" },
                    "Roger Federer");

                quizItemRepo.Add(sportsQuestion1);
                quizItemRepo.Add(sportsQuestion2);
                quizItemRepo.Add(sportsQuestion3);

                var sportsQuiz = new Quiz(
                    1,
                    new List<QuizItem> { sportsQuestion1, sportsQuestion2, sportsQuestion3 },
                    "Sports Quiz");

                quizRepo.Add(sportsQuiz);



            }

        }
    }
}