using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Exception = System.Exception;

namespace EFCDataAccess.DAOImplementation; 

public class UserDaoImpl : IUserDao {

    private readonly CanPayDbAccess context;

    public UserDaoImpl(CanPayDbAccess context) {
        this.context = context;
    }

    //create user
    public async Task<User> CreateUserAsync(User user) {
        try {
            EntityEntry<User> userToAdd = await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return userToAdd.Entity;
        }
        catch (Exception e) {
            throw new Exception("Username already exists");
        }
    }

    //get user by username
    public async Task<User> FetchUserByUsernameAsync(string username) {
        //username is a primary key so we can use FindAsync
        User? user = await context.Users.FindAsync(username);
        if (user == null) {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    //get user by id
    public async Task<User> FetchUserByIdAsync(long id) {
        User? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null) {
            throw new Exception("Username does not exists");
        }
        return user;
    }

    //get all users
    public async Task<ICollection<User>> FetchUsersAsync() {
        if (context.Users.Any()) {
            ICollection<User> users = await context.Users.ToListAsync();
            return users;
        }

        throw new Exception("No users found");
    }

    //update user
    public async Task<User> UpdateUserAsync(User user) {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    //delete user
    public async Task DeleteUserAsync(long id) {
        User existingUser = await FetchUserByIdAsync(id);
        if (existingUser == null) {
            throw new Exception($"Username with id {id} does not exists");
        }
        context.Users.Remove(existingUser);
        await context.SaveChangesAsync();
    }
    
  
}