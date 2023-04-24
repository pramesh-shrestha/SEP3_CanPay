package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.user.IUserClient;
import applicationtier.entity.UserEntity;
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
  public UserEntity createUser(UserEntity user) {
    try{
     return userClient.createUser(user);
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }

  @Override
  public List<UserEntity> fetchUsers() {
    return null;
  }

  @Override
  public UserEntity fetchUserById(Long id) {
    return null;
  }

  @Override
  public UserEntity fetchUserByUsername(String username) {
    return null;
  }

  @Override
  public UserEntity updateUser(Long id, UserEntity user) {
    return null;
  }

  @Override
  public void deleteUser(Long id) {

  }
}
