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
    public async Task<UserEntity> CreateUserAsync(UserEntity userEntity)
    {
        try
        {
            Console.WriteLine($"User DAO Impl T3: {userEntity.Username}");
            EntityEntry<UserEntity> userToAdd = await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
            return userToAdd.Entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    //get user by username
    public async Task<UserEntity> FetchUserByUsernameAsync(string username)
    {
        //username is a primary key so we can use FindAsync
        UserEntity? user = await context.Users.FindAsync(username);
        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    //get user by id
    public async Task<UserEntity> FetchUserByIdAsync(long id)
    {
        UserEntity? user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("Username does not exists");
        }

        return user;
    }

    //get all users
    public async Task<ICollection<UserEntity>> FetchUsersAsync()
    {
        if (context.Users.Any())
        {
            ICollection<UserEntity> users = await context.Users.ToListAsync();
            return users;
        }

        throw new Exception("No users found");
    }

    //update user
    public async Task<UserEntity> UpdateUserAsync(UserEntity userEntity)
    {
        context.Users.Update(userEntity);
        await context.SaveChangesAsync();
        return userEntity;
    }

    //delete user
    public async Task DeleteUserAsync(long id)
    {
        UserEntity existingUserEntity = await FetchUserByIdAsync(id);
        if (existingUserEntity == null)
        {
            throw new Exception($"Username with id {id} does not exists");
        }

        context.Users.Remove(existingUserEntity);
        await context.SaveChangesAsync();
    }

    //update balance
    public async Task<bool> UpdateBalanceAsync(string sender, string receiver, int balance)
    {
        try
        {
            int senderAmount = await FetchBalanceByUsername(sender);
            //sender side
            if (senderAmount > 0 && senderAmount >= balance)
            {
                senderAmount -= balance;
                UserEntity senderEntity = await FetchUserByUsernameAsync(sender);
                senderEntity.Balance = senderAmount;

                //receiver side
                int receiverAmount = await FetchBalanceByUsername(receiver);
                receiverAmount += balance;
                UserEntity receiverEntity = await FetchUserByUsernameAsync(receiver);
                receiverEntity.Balance = receiverAmount;

                await context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return false;
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