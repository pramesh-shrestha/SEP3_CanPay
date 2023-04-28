package applicationtier.controller;

import applicationtier.entity.UserEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import applicationtier.service.serviceInterfaces.IUserService;

import java.util.List;

@RestController
public class UserController {

    private final IUserService userService;

    @Autowired
    public UserController(IUserService userService) {
        this.userService = userService;
    }

    //create user
    @PostMapping("/user/create")
    public ResponseEntity<UserEntity> createUser(@RequestBody
                                                 UserEntity user) {
        try {
            System.out.println("User Controller T2: " + user.getBalance());
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



}
