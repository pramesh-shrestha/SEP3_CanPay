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

    //create user
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

    //get user by username
    public async Task<UserEntity?> FetchUserByUsernameAsync(string username)
    {
        //username is a primary key so we can use FindAsync
        UserEntity? user =
            await context.Users.Include(entity => entity.Card)
                .FirstOrDefaultAsync(entity => entity.Username.ToLower().Equals(username.ToLower()));

        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    //get user by id
    public async Task<UserEntity?> FetchUserByIdAsync(long id)
    {
        UserEntity? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    //get all users
    public async Task<ICollection<UserEntity?>> FetchUsersAsync()
    {
        if (!context.Users.Any()) throw new Exception("No users found");
        ICollection<UserEntity?> users = await context.Users.Include(entity => entity.Card).ToListAsync();
        return users;
    }

    //update user
    public async Task<UserEntity?> UpdateUserAsync(UserEntity? userEntity)
    {
        context.Users.Update(userEntity);
        await context.SaveChangesAsync();
        return userEntity;
    }

    //delete user
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

    //update balance
    public async Task<bool> UpdateBalanceAsync(string username, int newBalance)
    {
        //todo: balance adding and removing should be done in application tier. need to consult with group 
        UserEntity? user = await FetchUserByUsernameAsync(username);
        user.Balance = newBalance;
        await context.SaveChangesAsync();
        return true;

        /*try
        {
            int senderAmount = await FetchBalanceByUsername(sender);
            //sender side
            if (senderAmount > 0 && senderAmount >= amount)
            {
                senderAmount -= amount;
                UserEntity senderEntity = await FetchUserByUsernameAsync(sender);
                senderEntity.Balance = senderAmount;

                //receiver side
                UserEntity receiverUser = await FetchUserByUsernameAsync(receiver);
                receiverUser.Balance += amount;

                await context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return false;*/
    }

    //get balance by username
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