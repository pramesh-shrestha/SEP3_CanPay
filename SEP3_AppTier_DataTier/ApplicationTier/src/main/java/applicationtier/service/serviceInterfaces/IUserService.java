package applicationtier.service.serviceInterfaces;


import applicationtier.entity.UserEntity;

import java.util.List;

public interface IUserService {
  UserEntity createUser(UserEntity user);
  List<UserEntity> fetchUsers();
  UserEntity fetchUserById(Long id);
  UserEntity fetchUserByUsername(String username);
  UserEntity updateUser(Long id, UserEntity user);
  void deleteUser(Long id);
}
