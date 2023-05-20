package applicationtier.controller;

import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class RequestController {

    private final IRequestService requestService;

    @Autowired
    public RequestController(IRequestService requestService) {
        this.requestService = requestService;
    }

    @PostMapping("/request/create")
    public ResponseEntity<RequestEntity> createRequest(@RequestBody RequestEntity request) {
        try {
            RequestEntity requestEntity = requestService.createRequest(request);
            return new ResponseEntity<>(requestEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/request")
    public ResponseEntity<List<RequestEntity>> fetchAllRequest() {
        try {
            List<RequestEntity> requestEntities = requestService.fetchAllRequest();
            return new ResponseEntity<>(requestEntities, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/request/id/{id}")
    public ResponseEntity<RequestEntity> fetchRequestById(@PathVariable("id") Long id) {
        try {
            ResponseEntity<RequestEntity> entity = new ResponseEntity<>(requestService.fetchRequestById(id), HttpStatus.OK);
            return entity;
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/request/username/{username}")
    public ResponseEntity<RequestEntity> fetchRequestByUsername(@PathVariable("username") String username) {
        try {
            return new ResponseEntity<>(requestService.fetchRequestByUsername(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @PostMapping("/request/update")
    public ResponseEntity<RequestEntity> updateRequest(@RequestBody RequestEntity request) {
        try {
            return new ResponseEntity<>(requestService.updateRequest(request), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @DeleteMapping("/request/delete/{id}")
    public ResponseEntity<String> deleteRequest(@PathVariable("id") Long id) {
        try {
            requestService.deleteRequest(id);
            return new ResponseEntity<>("Request has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
