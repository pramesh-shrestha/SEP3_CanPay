package applicationtier.GrpcClient.user;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.card.CardClientImpl;
import applicationtier.entity.UserEntity;
import applicationtier.protobuf.User;
import applicationtier.protobuf.UserProtoServiceGrpc;
import com.google.protobuf.*;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

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

            User.UserProtoObj userProtoObj = fromEntityToProtoObj(userEntity);

            User.UserProtoObj protoObjFromServer = getUserBlockingStub().createUser(userProtoObj);
            return fromProtoObjToEntity(protoObjFromServer);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

    }

    @Override
    public UserEntity findByUsername(String username) {
        try {
            User.UserProtoObj userProtoObj = getUserBlockingStub().fetchUserByUsername(StringValue.of(username));
            return fromProtoObjToEntity(userProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<UserEntity> fetchUsers() {
        try {
            User.UserListResponse allUserProto = getUserBlockingStub().fetchAllUser(Empty.newBuilder().build());
            List<UserEntity> userEntities = new ArrayList<>();

            for (User.UserProtoObj userProtoObj : allUserProto.getAllUsersList()) {
                UserEntity user = fromProtoObjToEntity(userProtoObj);
                userEntities.add(user);
            }
            return userEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public UserEntity FetchUserById(Long id) {
        try {
            User.UserProtoObj userProtoObj = getUserBlockingStub().fetchUserById(Int64Value.of(id));
            return fromProtoObjToEntity(userProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public UserEntity updateUser(UserEntity user) {
        try {

            System.out.println(user.getUserName());

            User.UserProtoObj userProtoObj = getUserBlockingStub().updateUser(fromEntityToProtoObj(user));

            System.out.println(user.getUserName());

            return fromProtoObjToEntity(userProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public boolean deleteUser(Long id) {
        try {
            BoolValue userProtoObj = getUserBlockingStub().deleteUser(Int64Value.of(id));
            return userProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    //convert user to proto object
    public static User.UserProtoObj fromEntityToProtoObj(UserEntity userEntity) {
        return User.UserProtoObj.newBuilder()
                .setUserName(userEntity.getUserName())
                .setPassword(userEntity.getPassword())
                .setFullName(userEntity.getFullName())
                .setCard(CardClientImpl.fromEntityToProtoObj(userEntity.getCard()))
                .setBalance(userEntity.getBalance())
                .build();
    }

    //convert proto to user object
    public static UserEntity fromProtoObjToEntity(User.UserProtoObj userProtoObj) {
        UserEntity userEntity = new UserEntity();
        userEntity.setUserId(userProtoObj.getUserId());
        userEntity.setUserName(userProtoObj.getUserName());
        userEntity.setPassword(userProtoObj.getPassword());
        userEntity.setFullName(userProtoObj.getFullName());
        userEntity.setBalance(userProtoObj.getBalance());
        userEntity.setCard(CardClientImpl.fromProtoObjToEntity(userProtoObj.getCard()));
        return userEntity;
    }


}
