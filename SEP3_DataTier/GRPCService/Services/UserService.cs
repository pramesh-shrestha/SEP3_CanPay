using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.ObjectMapper;
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
            UserEntity toAddUser = UserEntityMapper.FromProtoToEntity(request);
            UserEntity addedUser = await userDao.CreateUserAsync(toAddUser);

            UserProtoObj userProtoObj = UserEntityMapper.FromEntityToProto(addedUser);
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
                userProtoObjs.Add(UserEntityMapper.FromEntityToProto(userEntity));
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
            UserProtoObj userProtoObj = UserEntityMapper.FromEntityToProto(userByUsername);
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
            UserProtoObj protoObj = UserEntityMapper.FromEntityToProto(userById);
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
            UserEntity userUpdate = UserEntityMapper.FromProtoToEntity(request.ToUpdateUser);
            UserEntity updatedUser = await userDao.UpdateUserAsync(userUpdate);

            UserProtoObj userProtoObj = UserEntityMapper.FromEntityToProto(updatedUser);
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
}