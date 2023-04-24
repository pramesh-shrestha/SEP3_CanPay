using Entity.Model;
using SEP3_DataTier;

namespace GrpcService.ObjectMapper;

public class UserEntityMapper
{
    public static UserEntity FromProtoToEntity(UserProtoObj userProtoObj)
    {
        return new UserEntity()
        {
            Fullname = userProtoObj.FullName,
            Username = userProtoObj.UserName,
            Password = userProtoObj.Password,
            Card = DebitCardMapper.FromProtoToEntity(userProtoObj.Card),
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
            Card = DebitCardMapper.FromEntityToProto(userEntity.Card),
            Balance = userEntity.Balance
        };
    }
}