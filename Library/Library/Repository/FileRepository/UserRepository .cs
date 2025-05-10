using System;
using System.Collections.Generic;
using System.IO;

public class UserRepository : IRepository<User, int>
{
    private readonly List<User> _users = new();
    private int _nextId = 1;
    private readonly string _filePath;

    public UserRepository(string filePath)
    {
        _filePath = filePath;
    }

    public void Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }

    public User GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public IEnumerable<User> GetAll() => _users;

    public void Update(User user)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        if (index != -1)
        {
            _users[index] = user;
        }
    }

    public void Delete(int id)
    {
        _users.RemoveAll(u => u.Id == id);
    }

    public void ReadFromCsv()
    {
        if (!File.Exists(_filePath)) return;
        var lines = File.ReadAllLines(_filePath);
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            if (parts.Length == 3)
            {
                var id = int.Parse(parts[0].Trim());
                var email = parts[1].Trim();
                var password = parts[2].Trim();

                var user = new User(email, email, password) { Id = id };
                _users.Add(user);
                _nextId = Math.Max(_nextId, id + 1);
            }
        }
    }

    public void WriteToCsv()
    {
        var lines = new List<string>();

        foreach (var user in _users)
        {
            var line = $"{user.Id},{user.Email},{user.Password}";
            lines.Add(line);
        }

        File.WriteAllLines(_filePath, lines);
    }
}
