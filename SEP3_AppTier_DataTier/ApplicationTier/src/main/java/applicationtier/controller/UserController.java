package applicationtier.controller;

import entity.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import applicationtier.service.user.IUserService;

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
    public ResponseEntity<User> createUser(@RequestBody User user) {
        try {
            ResponseEntity<User> response = new ResponseEntity<>(userService.createUser(user), HttpStatus.OK);
            System.out.println(response);
            return response;

        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get all users
    @GetMapping("/user")
    public ResponseEntity<List<User>> fetchUsers() {
        System.out.println("here");
        try {
            return new ResponseEntity<>(userService.fetchUsers(), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by id
    @GetMapping("/user/{id}")
    public ResponseEntity<User> fetchUserById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(userService.fetchUserById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //get user by username
    @GetMapping("/user/{username}")
    public ResponseEntity<User> fetchUserByUsername(@PathVariable("username") String username) {
        try {
            return new ResponseEntity<>(userService.fetchUserByUsername(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //update user
    @PutMapping("/user/{id}")
    public ResponseEntity<User> updateUser(@PathVariable Long id, @RequestBody User updatedUser) {
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
