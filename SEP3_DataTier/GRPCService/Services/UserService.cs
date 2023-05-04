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

    public override async Task<UserProtoObj> CreateUser(UserProtoObj request, ServerCallContext context)
    {
        try
        {
            UserEntity toAddUser = FromProtoToEntity(request);
            UserEntity addedUser = await userDao.CreateUserAsync(toAddUser);

            UserProtoObj userProtoObj = FromEntityToProto(addedUser);
            userProtoObj.UserId = addedUser.Id;
            return userProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    public override async Task<UserListResponse> FetchAllUser(Empty request, ServerCallContext context)
    {
        try
        {
            ICollection<UserEntity> allUsers = await userDao.FetchUsersAsync();
            RepeatedField<UserProtoObj> userProtoObjs = new RepeatedField<UserProtoObj>();

            foreach (UserEntity userEntity in allUsers)
            {
                UserProtoObj protoObj = FromEntityToProto(userEntity);
                protoObj.UserId = userEntity.Id;
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

    public override async Task<UserProtoObj> FetchUserByUsername(StringValue request, ServerCallContext context)
    {
        try
        {
            UserEntity userByUsername = await userDao.FetchUserByUsernameAsync(request.Value);
            UserProtoObj userProtoObj = FromEntityToProto(userByUsername);
            userProtoObj.UserId = userByUsername.Id;
            return userProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public override async Task<UserProtoObj> FetchUserById(Int32Value request, ServerCallContext context)
    {
        try
        {
            UserEntity userById = await userDao.FetchUserByIdAsync(request.Value);
            UserProtoObj protoObj = FromEntityToProto(userById);
            protoObj.UserId = userById.Id;
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }


    public override async Task<UserProtoObj> UpdateUser(UserProtoObj request, ServerCallContext context)
    {
        try
        {
            UserEntity userEntity = FromProtoToEntity(request);
            userEntity.Id = (int)request.UserId;

            UserEntity updatedUserEntity = await userDao.UpdateUserAsync(userEntity);
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

    /*public override Task<BoolValue> UpdateBalance(Int32Value request, ServerCallContext context)
    {
        return base.UpdateBalance(request, context);
    }*/

    public static UserEntity FromProtoToEntity(UserProtoObj userProtoObj)
    {
        return new UserEntity()
        {
            Fullname = userProtoObj.FullName,
            Username = userProtoObj.UserName,
            Password = userProtoObj.Password,
            Card = DebitCardService.FromProtoToEntity(userProtoObj.Card),
            Balance = userProtoObj.Balance
        };
    }

    public static UserProtoObj FromEntityToProto(UserEntity userEntity)
    {
        return new UserProtoObj()
        {
            FullName = userEntity.Fullname,
            UserName = userEntity.Username,
            Password = userEntity.Password,
            Card = DebitCardService.FromEntityToProto(userEntity.Card),
            Balance = userEntity.Balance
        };
    }
}