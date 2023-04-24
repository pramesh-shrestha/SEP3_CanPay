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
                userProtoObjs.Add(FromEntityToProto(userEntity));
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
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public override async Task<UserProtoObj> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        // todo: have to look into this another time

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
    }

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

    public override Task<Int32Value> FetchBalanceByUsername(StringValue request, ServerCallContext context)
    {
        return base.FetchBalanceByUsername(request, context);
    }

    public override Task<BoolValue> UpdateBalance(Int32Value request, ServerCallContext context)
    {
        return base.UpdateBalance(request, context);
    }

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