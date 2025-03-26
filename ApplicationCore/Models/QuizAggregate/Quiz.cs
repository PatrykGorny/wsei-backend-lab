using ApplicationCore.Commons.Repository;

namespace ApplicationCore.Models.QuizAggregate;

public class Quiz: IIdentity<int>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public List<QuizItem> Items { get; set; }

    public Quiz()
    {
        
    }
    public Quiz(int id, List<QuizItem> items, string title)
    {
        Id = id;
        Items = items;
        Title = title;
    }
    
}