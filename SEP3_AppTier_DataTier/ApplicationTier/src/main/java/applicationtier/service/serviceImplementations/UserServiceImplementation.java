package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.user.IUserClient;
import applicationtier.entity.User;
import applicationtier.service.serviceInterfaces.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImplementation implements IUserService {

  private IUserClient userClient;

  @Autowired
  public UserServiceImplementation(IUserClient userClient) {
    this.userClient = userClient;
  }

  @Override
  public User createUser(User user) {
    try{
     return userClient.createUser(user);
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }

  @Override
  public List<User> fetchUsers() {
    return null;
  }

  @Override
  public User fetchUserById(Long id) {
    return null;
  }

  @Override
  public User fetchUserByUsername(String username) {
    return null;
  }

  @Override
  public User updateUser(Long id, User user) {
    return null;
  }

  @Override
  public void deleteUser(Long id) {

  }
}
