package applicationtier.service.serviceImplementations;

import applicationtier.service.serviceInterfaces.IUserService;
import entity.User;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImplementation implements IUserService {
    @Override
    public User createUser(User user) {
        return user;
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
