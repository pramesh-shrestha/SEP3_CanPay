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

    //create user
    @PostMapping("/user/create")
    public ResponseEntity<UserEntity> createUser(@RequestBody
                                                 UserEntity user) {
        try {
            return new ResponseEntity<>(userService.createUser(user), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get all users
    @GetMapping("/user")
    public ResponseEntity<List<UserEntity>> fetchUsers() {
        try {
            List<UserEntity> userEntities = userService.fetchUsers();
            return new ResponseEntity<>(userEntities, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by id
    @GetMapping("/user/id/{id}")
    public ResponseEntity<UserEntity> fetchUserById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(userService.fetchUserById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by username
    @GetMapping("/user/username/{username}")
    public ResponseEntity<UserEntity> fetchUserByUsername(@PathVariable("username") String username) {
        try {
            UserEntity user = userService.fetchUserByUsername(username);
            return new ResponseEntity<>(user, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //update user
    @PostMapping("/user/update")
    public ResponseEntity<UserEntity> updateUser(@RequestBody
                                                 UserEntity updatedUser) {
        try {
            return new ResponseEntity<>(userService.updateUser(updatedUser), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //delete user
    @DeleteMapping("/user/delete/{id}")
    public ResponseEntity<String> deleteUser(@PathVariable("id") Long id) {
        try {
            userService.deleteUser(id);
            return new ResponseEntity<>("User has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


   /* @PostMapping("/register")
    public ResponseEntity<AuthenticationResponse> register(
            @RequestBody RegisterRequest request
    ){
        return ResponseEntity.ok(service.register(request));
    }*/

    //login
    @PostMapping("/user/authenticate")
    public ResponseEntity<AuthenticationResponse> authenticate(
            @RequestBody LoginDto request) {
        ResponseEntity<AuthenticationResponse> response = ResponseEntity.ok(service.authenticate(request));
        return response;
    }


}
