using ApplicationCore.Models;

namespace BackendLab01;

public class ChatUserService : IChatUserService
{
    private readonly List<(string ConnectionId, string Username)> _users = new();

    public void Add(string connectionId, string username)
    {
        _users.Add((connectionId, username));
    }

    public void RemoveByName(string username)
    {
        _users.RemoveAll(u => u.Username == username);
    }

    public string GetConnectionIdByName(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username).ConnectionId;
    }

    public IEnumerable<(string ConnectionId, string Username)> GetAll()
    {
        return _users;
    }
}