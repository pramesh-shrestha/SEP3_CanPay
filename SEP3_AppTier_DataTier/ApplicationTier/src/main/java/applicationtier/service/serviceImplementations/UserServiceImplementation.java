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
    try {
      return userClient.fetchUsers();
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }


  @Override
  public UserEntity fetchUserById(Long id) {
    try {
      return userClient.FetchUserById(id);
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }

  @Override
  public UserEntity fetchUserByUsername(String username) {
    try {
      return userClient.findByUsername(username);
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }

  @Override
  public UserEntity updateUser(Long id, UserEntity user) {
    return null;
  }

  @Override
  public boolean deleteUser(Long id) {
    try {
      return userClient.deleteUser(id);
    }
    catch (Exception e){
      throw new RuntimeException(e.getMessage());
    }
  }



}
