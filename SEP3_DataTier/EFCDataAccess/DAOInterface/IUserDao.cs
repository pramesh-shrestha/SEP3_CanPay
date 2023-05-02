﻿using Entity.Model;

namespace EFCDataAccess.DAOInterface; 

public interface IUserDao {
    Task<UserEntity> CreateUserAsync(UserEntity userEntity);
    Task<UserEntity> FetchUserByUsernameAsync(string username);
    Task<UserEntity> FetchUserByIdAsync(long id);
    Task<ICollection<UserEntity>> FetchUsersAsync();
    Task<UserEntity> UpdateUserAsync(UserEntity userEntity);
    Task DeleteUserAsync(long id);
    // Task<bool> UpdateBalanceAsync(string username, string receiver, int amount);
   Task<bool> UpdateBalanceAsync(string username, int newBalance);
   

    Task<int> FetchBalanceByUsername(string username);

}