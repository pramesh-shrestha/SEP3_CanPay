package applicationtier.controller;

import applicationtier.entity.UserEntity;
import applicationtier.jwt.auth.AuthenticationResponse;
import applicationtier.dto.LoginDto;
import applicationtier.service.serviceImplementations.UserServiceImplementation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import applicationtier.service.serviceInterfaces.IUserService;

import java.util.List;

@RestController
@CrossOrigin(origins = "http://localhost:8080")
//@RequestMapping("/api/auth")
public class UserController {

    private final IUserService userService;
    private final UserServiceImplementation service;

    @Autowired
    public UserController(IUserService userService, UserServiceImplementation service) {
        this.userService = userService;
        this.service = service;
    }

    /**
     * Create a new user.
     *
     * @param user The user entity to be created.
     * @return ResponseEntity containing the created user entity in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/user/create")
    public ResponseEntity<UserEntity> createUser(@RequestBody
                                                 UserEntity user) {
        try {
            return new ResponseEntity<>(userService.createUser(user), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all users.
     *
     * @return ResponseEntity containing a list of user entities in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/user")
    public ResponseEntity<List<UserEntity>> fetchUsers() {
        try {
            List<UserEntity> userEntities = userService.fetchUsers();
            return new ResponseEntity<>(userEntities, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch a user by ID.
     *
     * @param id The ID of the user to be fetched.
     * @return ResponseEntity containing the user entity with the specified ID in the response body
     * with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    /*@GetMapping("/user/id/{id}")
    public ResponseEntity<UserEntity> fetchUserById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(userService.fetchUserById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }*/

    /**
     * Fetch a user by username.
     *
     * @param username The username of the user to be fetched.
     * @return ResponseEntity containing the user entity with the specified username in the response body
     * with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/user/username/{username}")
    public ResponseEntity<UserEntity> fetchUserByUsername(@PathVariable("username") String username) {
        try {
            UserEntity user = userService.fetchUserByUsername(username);
            return new ResponseEntity<>(user, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Update a user.
     *
     * @param updatedUser The updated user entity.
     * @return ResponseEntity containing the updated user entity in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/user/update")
    public ResponseEntity<UserEntity> updateUser(@RequestBody
                                                 UserEntity updatedUser) {
        try {
            return new ResponseEntity<>(userService.updateUser(updatedUser), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Delete a user by ID.
     *
     * @param id The ID of the user to be deleted.
     * @return ResponseEntity with a success message in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    /*@DeleteMapping("/user/delete/{id}")
    public ResponseEntity<String> deleteUser(@PathVariable("id") Long id) {
        try {
            userService.deleteUser(id);
            return new ResponseEntity<>("User has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }*/


    /**
     * Authenticate a user.
     *
     * @param request The login request containing the user's credentials.
     * @return ResponseEntity containing the authentication response with a JWT token in the response body
     * with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/user/authenticate")
    public ResponseEntity<AuthenticationResponse> authenticate(
            @RequestBody LoginDto request) {
        ResponseEntity<AuthenticationResponse> response = ResponseEntity.ok(service.authenticate(request));
        return response;
    }


}
