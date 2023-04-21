package applicationtier.service;

import entity.User;

import java.util.List;

public interface IUserService {
  User createUser(User user);
  List<User> fetchUsers();
  User fetchUserById(Long id);
  User fetchUserByUsername(String username);
  User updateUser(Long id, User user);
  void deleteUser(Long id);
}
