package applicationtier.GrpcClient.user;

import applicationtier.entity.UserEntity;

public interface IUserClient {
  UserEntity createUser(UserEntity user);
}
