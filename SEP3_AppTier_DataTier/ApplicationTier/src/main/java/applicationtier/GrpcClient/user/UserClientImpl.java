package applicationtier.GrpcClient.user;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.card.CardClientImpl;
import applicationtier.entity.UserEntity;
import applicationtier.protobuf.User;
import applicationtier.protobuf.UserProtoServiceGrpc;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

@Service
public class UserClientImpl implements IUserClient {

    private UserProtoServiceGrpc.UserProtoServiceBlockingStub userBlockingStub;


    public UserProtoServiceGrpc.UserProtoServiceBlockingStub getUserBlockingStub() {
        if (userBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            userBlockingStub = UserProtoServiceGrpc.newBlockingStub(channel);
        }
        return userBlockingStub;
    }

    @Override
    public UserEntity createUser(UserEntity userEntity) {
        try {
            System.out.println("User Client Impl T2: " + userEntity.getBalance());

            User.UserProtoObj userProtoObj = fromEntityToProtoObj(userEntity);

            User.UserProtoObj protoObjFromServer = getUserBlockingStub().createUser(userProtoObj);
            return fromProtoObjToEntity(protoObjFromServer);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

    }

    @Override
    public UserEntity findByUsername(String username) {
        return null;
    }

    //convert user to proto object
    public static User.UserProtoObj fromEntityToProtoObj(UserEntity userEntity) {
        User.UserProtoObj userProtoObj = User.UserProtoObj.newBuilder()
                .setUserName(userEntity.getUserName())
                .setPassword(userEntity.getPassword())
                .setFullName(userEntity.getFullName())
                .setCard(CardClientImpl.fromEntityToProtoObj(userEntity.getCard()))
                .setBalance(userEntity.getBalance())
                .build();
        return userProtoObj;
    }

    //convert proto to user object
    public static UserEntity fromProtoObjToEntity(User.UserProtoObj userProtoObj) {
        UserEntity userEntity = new UserEntity();
        userEntity.setUserId(userProtoObj.getUserId());
        userEntity.setUserName(userProtoObj.getUserName());
        userEntity.setPassword(userProtoObj.getPassword());
        userEntity.setFullName(userProtoObj.getFullName());
        userEntity.setBalance(userEntity.getBalance());
        return userEntity;
    }


}
