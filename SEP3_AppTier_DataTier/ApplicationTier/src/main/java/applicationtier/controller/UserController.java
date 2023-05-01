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
            ResponseEntity<UserEntity> response = new ResponseEntity<>(userService.createUser(user), HttpStatus.OK);
            return response;

        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get all users
    @GetMapping("/user")
    public ResponseEntity<List<UserEntity>> fetchUsers() {
        System.out.println("here");
        try {
            return new ResponseEntity<>(userService.fetchUsers(), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by id
    @GetMapping("/user/{id}")
    public ResponseEntity<UserEntity> fetchUserById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(userService.fetchUserById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by username
    @GetMapping("/user/{username}")
    public ResponseEntity<UserEntity> fetchUserByUsername(@PathVariable("username") String username) {
        try {
            return new ResponseEntity<>(userService.fetchUserByUsername(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //update user
    @PutMapping("/user/update/{id}")
    public ResponseEntity<UserEntity> updateUser(@PathVariable Long id, @RequestBody
    UserEntity updatedUser) {
        try {
            return new ResponseEntity<>(userService.updateUser(id, updatedUser), HttpStatus.OK);
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
            @RequestBody LoginDto request
    ) {
        ResponseEntity<AuthenticationResponse> response = ResponseEntity.ok(service.authenticate(request));
        System.out.println(response.getStatusCode());
        return response;
    }


}
