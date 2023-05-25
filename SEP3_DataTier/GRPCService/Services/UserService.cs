using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class UserService : UserProtoService.UserProtoServiceBase
{
    private readonly IUserDao userDao;

    public UserService(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="request">The UserProtoObj containing the user data.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The created UserProtoObj.</returns>
    public override async Task<UserProtoObj> CreateUser(UserProtoObj request, ServerCallContext context)
    {
        try
        {
            UserEntity? toAddUser = FromProtoToEntity(request);
            UserEntity? addedUser = await userDao.CreateUserAsync(toAddUser);

            UserProtoObj userProtoObj = FromEntityToProto(addedUser);
            // userProtoObj.UserId = addedUser.Id;
            return userProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    /// <summary>
    /// Fetches all users.
    /// </summary>
    /// <param name="request">The Empty request.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A UserListResponse containing all the users.</returns>
    public override async Task<UserListResponse> FetchAllUser(Empty request, ServerCallContext context)
    {
        try
        {
            ICollection<UserEntity?> allUsers = await userDao.FetchUsersAsync();
            RepeatedField<UserProtoObj> userProtoObjs = new RepeatedField<UserProtoObj>();

            foreach (UserEntity? userEntity in allUsers)
            {
                UserProtoObj protoObj = FromEntityToProto(userEntity);
                // protoObj.UserId = userEntity.Id;
                userProtoObjs.Add(protoObj);
            }

            return new UserListResponse() { AllUsers = { userProtoObjs } };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches a user by their username.
    /// </summary>
    /// <param name="request">The username request.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The UserProtoObj representing the user.</returns>
    public override async Task<UserProtoObj> FetchUserByUsername(StringValue request, ServerCallContext context)
    {
        try
        {
            UserEntity? userByUsername = await userDao.FetchUserByUsernameAsync(request.Value);
            UserProtoObj userProtoObj = FromEntityToProto(userByUsername);
            // Console.WriteLine($"UserService: {userProtoObj.UserId}");
            return userProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches a user by their ID.
    /// </summary>
    /// <param name="request">The user ID request.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The UserProtoObj representing the user.</returns>
    public override async Task<UserProtoObj> FetchUserById(Int32Value request, ServerCallContext context)
    {
        try
        {
            UserEntity? userById = await userDao.FetchUserByIdAsync(request.Value);
            UserProtoObj protoObj = FromEntityToProto(userById);
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Updates a user.
    /// </summary>
    /// <param name="request">The UserProtoObj representing the updated user.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The UserProtoObj representing the updated user.</returns>
    public override async Task<UserProtoObj> UpdateUser(UserProtoObj request, ServerCallContext context)
    {
        try
        {
            UserEntity? userEntity = FromProtoToEntity(request);
            userEntity.Id = (int)request.UserId;

            UserEntity? updatedUserEntity = await userDao.UpdateUserAsync(userEntity);
            UserProtoObj updatedProtoObj = FromEntityToProto(updatedUserEntity);
            updatedProtoObj.UserId = updatedUserEntity.Id;

            return updatedProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /*public override async Task<UserProtoObj> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        try
        {
            UserEntity userUpdate = FromProtoToEntity(request.ToUpdateUser);
            UserEntity updatedUser = await userDao.UpdateUserAsync(userUpdate);

            UserProtoObj userProtoObj = FromEntityToProto(updatedUser);
            return userProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.InvalidArgument, e.Message));
        }
    }*/

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="request">The Int64Value representing the ID of the user to delete.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A BoolValue indicating the success of the deletion operation.</returns>
    public override async Task<BoolValue> DeleteUser(Int64Value request, ServerCallContext context)
    {
        try
        {
            await userDao.DeleteUserAsync(request.Value);
            return new BoolValue { Value = true };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches the balance of a user by their username.
    /// </summary>
    /// <param name="request">The StringValue representing the username of the user.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>An Int32Value containing the balance of the user.</returns>
    public override async Task<Int32Value> FetchBalanceByUsername(StringValue request, ServerCallContext context)
    {
        try
        {
            int balanceByUsername = await userDao.FetchBalanceByUsername(request.Value);
            return new Int32Value { Value = balanceByUsername };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }
    
    /// <summary>
    /// Converts a UserProtoObj to a UserEntity.
    /// </summary>
    /// <param name="userProtoObj">The UserProtoObj to convert.</param>
    /// <returns>A UserEntity object.</returns>
    public static UserEntity? FromProtoToEntity(UserProtoObj userProtoObj)
    {
        UserEntity? userEntity = new UserEntity()
        {
            Fullname = userProtoObj.FullName,
            Username = userProtoObj.UserName,
            Password = userProtoObj.Password,
            Card = DebitCardService.FromProtoToEntity(userProtoObj.Card),
            Balance = userProtoObj.Balance
        };

        if (userProtoObj.UserId != 0)
        {
            userEntity.Id = (int)userProtoObj.UserId;
        }

        return userEntity;
    }
    /// <summary>
    /// Converts a UserEntity to a UserProtoObj.
    /// </summary>
    /// <param name="userEntity">The UserEntity to convert.</param>
    /// <returns>A UserProtoObj object.</returns>
    public static UserProtoObj FromEntityToProto(UserEntity? userEntity)
    {
        UserProtoObj protoObj = new UserProtoObj()
        {
            FullName = userEntity.Fullname,
            UserName = userEntity.Username,
            Password = userEntity.Password,
            Balance = userEntity.Balance
        };

        if (userEntity.Id != 0)
        {
            protoObj.UserId = userEntity.Id;
        }

        if (userEntity.Card != null)
        {
            protoObj.Card = DebitCardService.FromEntityToProto(userEntity.Card);
        }

        return protoObj;
    }
}