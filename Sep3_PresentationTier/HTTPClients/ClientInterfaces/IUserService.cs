﻿using System.Collections;
using System.Security.Claims;
using Domains.Entity;
using HTTPClients.Auth;

namespace HTTPClients.ClientInterfaces;

public interface IUserService
{
    Task<UserEntity> CreateAsync(UserEntity toCreateUserEntity);
    Task<IEnumerable<UserEntity?>> FetchAllUsersAsync();
    Task<UserEntity> FetchUserByUsernameAsync(string? username);
    Task<AuthenticationResponse> ValidateUser(string username, string password);
    Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    Task<ClaimsPrincipal> GetAuthAsync();

    Task LogoutAsync();

    Task<UserEntity> UpdateUserAsync(UserEntity userEntity);
    
}