package applicationtier.GrpcClient.user;

import applicationtier.entity.UserEntity;

import java.util.List;

public interface IUserClient {
  UserEntity createUser(UserEntity user);
  UserEntity findByUsername(String username);
  UserEntity FetchUserById(Long id);

  boolean deleteUser(Long id);

  List<UserEntity> fetchUsers();
}
