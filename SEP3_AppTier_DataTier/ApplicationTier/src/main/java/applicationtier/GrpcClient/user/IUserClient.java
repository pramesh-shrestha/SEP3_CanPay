package applicationtier.GrpcClient.user;

import applicationtier.entity.UserEntity;

import java.util.List;

public interface IUserClient {
    UserEntity createUser(UserEntity user);

    UserEntity findByUsername(String username);


    List<UserEntity> fetchUsers();

    UserEntity updateUser(UserEntity user);
}

