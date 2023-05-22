package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.user.IUserClient;
import applicationtier.entity.UserEntity;
import applicationtier.jwt.JwtService;
import applicationtier.jwt.auth.AuthenticationResponse;
import applicationtier.dto.LoginDto;
import applicationtier.service.serviceInterfaces.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class UserServiceImplementation implements IUserService {

    private IUserClient userClient;
    private final PasswordEncoder passwordEncoder;
    private final JwtService jwtService;
    private final AuthenticationManager authenticationManager;

    @Autowired
    public UserServiceImplementation(IUserClient userClient, PasswordEncoder passwordEncoder, JwtService jwtService, AuthenticationManager authenticationManager) {
        this.userClient = userClient;
        this.passwordEncoder = passwordEncoder;
        this.jwtService = jwtService;
        this.authenticationManager = authenticationManager;
    }

    /**
     * Creates a new user.
     *
     * @param user The user entity to create.
     * @return The created user entity.
     * @throws RuntimeException If an error occurs during the creation process.
     */
    @Override
    public UserEntity createUser(UserEntity user) {
        try {
            user.setPassword(passwordEncoder.encode(user.getPassword()));
            return userClient.createUser(user);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /* public AuthenticationResponse register(RegisterRequest request) {
          UserEntity user = User.builder()
                  .firstname(request.getFirstname())
                  .lastname(request.getLastname())
                  .username(request.getUsername())
                  .password(passwordEncoder.encode(request.getPassword()))
                  //.role(Role.USER)
                  .build();
          iUserClient.save(user);
          var jwtToken = jwtService.generateToken(user);
          return AuthenticationResponse.builder()
                  .token(jwtToken)
                  .build();
      }*/

    /**
     * Fetches all users.
     *
     * @return The list of fetched user entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public List<UserEntity> fetchUsers() {
        try {
            List<UserEntity> userEntities = userClient.fetchUsers();
            return userEntities;
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    /**
     * Fetches a user by their ID.
     *
     * @param id The ID of the user to fetch.
     * @return The fetched user entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    /*@Override
    public UserEntity fetchUserById(Long id) {
        try {
            return userClient.FetchUserById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Fetches a user by their username.
     *
     * @param username The username of the user to fetch.
     * @return The fetched user entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public UserEntity fetchUserByUsername(String username) {
        try {
            UserEntity byUsername = userClient.findByUsername(username);
            return byUsername;
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    /**
     * Updates a user.
     *
     * @param user The user entity to update.
     * @return The updated user entity.
     * @throws RuntimeException If an error occurs during the update process.
     */
    @Override
    public UserEntity updateUser(UserEntity user) {
        try {
            user.setPassword(passwordEncoder.encode(user.getPassword()));
            return userClient.updateUser(user);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Deletes a user by their ID.
     *
     * @param id The ID of the user to delete.
     * @return True if the deletion is successful, false otherwise.
     * @throws RuntimeException If an error occurs during the deletion process.
     */
    /*@Override
    public boolean deleteUser(Long id) {
        try {
            return userClient.deleteUser(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/


    /**
     * Authenticates a user.
     *
     * @param request The login credentials.
     * @return The authentication response containing the JWT token.
     * @throws RuntimeException If authentication fails or an error occurs during the authentication process.
     */
    public AuthenticationResponse authenticate(LoginDto request) {
        authenticationManager.authenticate(
                new UsernamePasswordAuthenticationToken(
                        request.getUsername(),
                        request.getPassword()
                )
        );
        var user = userClient.findByUsername(request.getUsername());

        var jwtToken = jwtService.generateToken(user);
        return AuthenticationResponse.builder()
                .token(jwtToken)
                .build();
    }


}
