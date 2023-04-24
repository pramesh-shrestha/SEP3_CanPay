package applicationtier.GrpcClient.user;

import applicationtier.entity.User;

public interface IUserClient {
  User createUser(User user);
}
