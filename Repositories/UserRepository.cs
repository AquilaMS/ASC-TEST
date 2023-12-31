using ASC_TEST.Data;
using ASC_TEST.Models;

namespace ASC_TEST;

public interface IUserRepository
{
    void Save(User user);
    User FindByEmailOrName(User user);
    User FindByName(User user);
}
public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Save(User user)
    {
        user.Password = PasswordService.GenerateHash(user.Password);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public User FindByEmailOrName(User user)
    {
        User foundUser = _context.Users
            .FirstOrDefault(u => u.Email == user.Email || u.Name == user.Name);
        return foundUser;
    }
    public User FindByName(User user)
    {
        User foundUser = _context.Users
            .FirstOrDefault(u => u.Name == user.Name);
        return foundUser;
    }
}
