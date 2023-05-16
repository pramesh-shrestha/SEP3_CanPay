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
    @Override
    public List<UserEntity> fetchUsers() {
        try {
            List<UserEntity> userEntities = userClient.fetchUsers();
            return userEntities;
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    @Override
    public UserEntity fetchUserById(Long id) {
        try {
            return userClient.FetchUserById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public UserEntity fetchUserByUsername(String username) {
        try {
            UserEntity byUsername = userClient.findByUsername(username);
            return byUsername;
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    @Override
    public UserEntity updateUser(UserEntity user) {
        try {
            user.setPassword(passwordEncoder.encode(user.getPassword()));
            return userClient.updateUser(user);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public boolean deleteUser(Long id) {
        try {
            return userClient.deleteUser(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


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
