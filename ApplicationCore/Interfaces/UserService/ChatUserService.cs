using ApplicationCore.Commons.Repository;
using ApplicationCore.Models;

namespace ApplicationCore.Interfaces.UserService;

public class ChatUserService:IChatUserService
{
    
    private readonly IGenericRepository<ChatUser, int> _chatUserRepository ;
    
    public ChatUserService(IGenericRepository<ChatUser, int> chatUserRepository)
    {
        this._chatUserRepository = chatUserRepository ?? throw new ArgumentNullException(nameof(chatUserRepository));
    }
    
    public void Add(string connectionId, string username)
    {
        _chatUserRepository.Add(new ChatUser(){ConnectionId = connectionId, Username = username});
    }

    public void RemoveByName(string username)
    {
        var user = _chatUserRepository.FindAll().Find(u => u.Username == username);
        if (user != null)
        {
            _chatUserRepository.RemoveById(user.Id);
        }
    }

    public string GetConnectionIdByName(string username)
    {
        return _chatUserRepository.FindAll()
            .Where(u => u.Username == username)
            .Select(u => u.ConnectionId)
            .FirstOrDefault("");
    }
    

    public IEnumerable<(string ConnectionId, string Username)> GetAll()
    {
        return _chatUserRepository.FindAll().Select(u=>(u.ConnectionId,u.Username));
    }
}