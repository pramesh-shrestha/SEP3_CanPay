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


    /**
     * Retrieves the UserProtoServiceBlockingStub instance.
     *
     * @return The UserProtoServiceBlockingStub instance.
     */
    public UserProtoServiceGrpc.UserProtoServiceBlockingStub getUserBlockingStub() {
        if (userBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            userBlockingStub = UserProtoServiceGrpc.newBlockingStub(channel);
        }
        return userBlockingStub;
    }

    /**
     * Creates a new user.
     *
     * @param userEntity The UserEntity object representing the user to create.
     * @return The created UserEntity object.
     * @throws RuntimeException If an exception occurs during the creation process.
     */
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

    /**
     * Finds a user by their username.
     *
     * @param username The username of the user to find.
     * @return The found UserEntity object, or null if no user with the specified username exists.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    @Override
    public UserEntity findByUsername(String username) {
        try {
            User.UserProtoObj userProtoObj = getUserBlockingStub().fetchUserByUsername(StringValue.of(username));
            UserEntity userEntity = fromProtoObjToEntity(userProtoObj);
            return userEntity;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches all users.
     *
     * @return A list of UserEntity objects representing all the users.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
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


    /**
     * Fetches a user by their ID.
     *
     * @param id The ID of the user to fetch.
     * @return The fetched UserEntity object.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    @Override
    public UserEntity FetchUserById(Long id) {
        try {
            User.UserProtoObj userProtoObj = getUserBlockingStub().fetchUserById(Int64Value.of(id));
            return fromProtoObjToEntity(userProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Updates a user.
     *
     * @param user The UserEntity object representing the user to update.
     * @return The updated UserEntity object.
     * @throws RuntimeException If an exception occurs during the update process.
     */
    @Override
    public UserEntity updateUser(UserEntity user) {
        try {
            User.UserProtoObj userProtoObj = getUserBlockingStub().updateUser(fromEntityToProtoObj(user));
            return fromProtoObjToEntity(userProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Deletes a user.
     *
     * @param id The ID of the user to delete.
     * @return True if the deletion was successful, false otherwise.
     * @throws RuntimeException If an exception occurs during the deletion process.
     */
    @Override
    public boolean deleteUser(Long id) {
        try {
            BoolValue userProtoObj = getUserBlockingStub().deleteUser(Int64Value.of(id));
            return userProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Converts a UserEntity object to a User.UserProtoObj object.
     *
     * @param userEntity The UserEntity object to convert.
     * @return The converted User.UserProtoObj object.
     */
    public static User.UserProtoObj fromEntityToProtoObj(UserEntity userEntity) {
        User.UserProtoObj.Builder builder = User.UserProtoObj.newBuilder()
                .setUserName(userEntity.getUserName())
                .setPassword(userEntity.getPassword())
                .setFullName(userEntity.getFullName())
                .setCard(CardClientImpl.fromEntityToProtoObj(userEntity.getCard()))
                .setBalance(userEntity.getBalance());

        if (userEntity.getUserId() != null || userEntity.getUserId() != 0) {
            builder.setUserId(userEntity.getUserId());
        }

        return builder.build();
    }

    /**
     * Converts a User.UserProtoObj object to a UserEntity object.
     *
     * @param userProtoObj The User.UserProtoObj object to convert.
     * @return The converted UserEntity object.
     */
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
