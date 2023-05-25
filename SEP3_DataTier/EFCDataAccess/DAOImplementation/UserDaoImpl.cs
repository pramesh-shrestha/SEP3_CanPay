using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Exception = System.Exception;

namespace EFCDataAccess.DAOImplementation;

public class UserDaoImpl : IUserDao
{
    private readonly CanPayDbAccess context;

    public UserDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }

    /// <summary>
    /// Creates a user asynchronously.
    /// </summary>
    /// <param name="userEntity">The user entity to create.</param>
    /// <returns>The created user entity.</returns>
    public async Task<UserEntity?> CreateUserAsync(UserEntity? userEntity)
    {
        try
        {
            EntityEntry<UserEntity?> userToAdd = await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
            return userToAdd.Entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Fetches a user by username asynchronously.
    /// </summary>
    /// <param name="username">The username of the user to fetch.</param>
    /// <returns>The fetched user entity.</returns>
    public async Task<UserEntity?> FetchUserByUsernameAsync(string username)
    {
        //username is a primary key so we can use FindAsync
        UserEntity? user =
            await context.Users.AsNoTracking().Include(entity => entity.Card)
                .FirstOrDefaultAsync(entity => entity.Username.ToLower().Equals(username.ToLower()));

        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    /// <summary>
    /// Fetches a user by ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the user to fetch.</param>
    /// <returns>The fetched user entity.</returns>
    public async Task<UserEntity?> FetchUserByIdAsync(long id)
    {
        UserEntity? user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    /// <summary>
    /// Fetches all users asynchronously.
    /// </summary>
    /// <returns>A collection of user entities.</returns>
    public async Task<ICollection<UserEntity?>> FetchUsersAsync()
    {
        if (!context.Users.Any()) throw new Exception("No users found");
        ICollection<UserEntity?>
            users = await context.Users.AsNoTracking().Include(entity => entity.Card).ToListAsync();
        return users;
    }

    /// <summary>
    /// Updates a user asynchronously.
    /// </summary>
    /// <param name="userEntity">The user entity to update.</param>
    /// <returns>The updated user entity.</returns>
    public async Task<UserEntity?> UpdateUserAsync(UserEntity? userEntity)
    {
        long currentId = await context.Users.Where(u => u.Username.Equals(userEntity.Username)).Select(u => u.Id).FirstOrDefaultAsync();
        
        if (currentId != 0) {
            userEntity.Id = currentId;
        }
        
        if (!context.Users.Local.Contains(userEntity))
        {
            context.Users.Attach(userEntity);
            context.Cards.Attach(userEntity.Card);
        }
        
        context.Entry(userEntity.Card).State = EntityState.Modified; // Mark associated Card entity as modified
        context.Entry(userEntity).State = EntityState.Modified; // Mark userEntity as modified
        
        await context.SaveChangesAsync();
        return userEntity;
    }

    /// <summary>
    /// Deletes a user asynchronously by their ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteUserAsync(long id)
    {
        UserEntity? existingUserEntity = await FetchUserByIdAsync(id);
        if (existingUserEntity == null)
        {
            throw new Exception($"Username with id {id} does not exists");
        }

        context.Users.Remove(existingUserEntity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the balance of a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="newBalance">The new balance to set for the user.</param>
    /// <returns>A boolean indicating whether the balance update was successful.</returns>
    public async Task<bool> UpdateBalanceAsync(string username, int newBalance)
    {
        UserEntity? user = await FetchUserByUsernameAsync(username);
        user.Balance = newBalance;
        await context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Fetches the balance of a user by their username asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>The balance of the user.</returns>
    public async Task<int> FetchBalanceByUsername(string username)
    {
        UserEntity? userEntity = await context.Users.FindAsync(username);
        if (userEntity == null)
        {
            throw new Exception("Username not found");
        }

        return userEntity.Balance;
    }
}