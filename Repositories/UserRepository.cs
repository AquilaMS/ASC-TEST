using ASC_TEST.Data;
using ASC_TEST.Models;

namespace ASC_TEST;

public interface IUserRepository
{
    void Save(User user);
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
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
