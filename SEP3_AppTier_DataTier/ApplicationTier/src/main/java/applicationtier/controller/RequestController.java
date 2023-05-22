package applicationtier.controller;

import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
public class RequestController {

    private final IRequestService requestService;

    @Autowired
    public RequestController(IRequestService requestService) {
        this.requestService = requestService;
    }

    /**
     * Create a new request.
     *
     * @param request The request entity to be created.
     * @return ResponseEntity containing the created request entity in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/request/create")
    public ResponseEntity<RequestEntity> createRequest(@RequestBody RequestEntity request) {
        try {
            RequestEntity requestEntity = requestService.createRequest(request);
            return new ResponseEntity<>(requestEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all requests.
     *
     * @return ResponseEntity containing a list of all request entities in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    /*@GetMapping("/request")
    public ResponseEntity<List<RequestEntity>> fetchAllRequest() {
        try {
            List<RequestEntity> requestEntities = requestService.fetchAllRequest();
            return new ResponseEntity<>(requestEntities, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }*/

    /**
     * Fetch a request by ID.
     *
     * @param id The ID of the request to be fetched.
     * @return ResponseEntity containing the request entity with the specified ID in the response body
     *         with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/request/id/{id}")
    public ResponseEntity<RequestEntity> fetchRequestById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(requestService.fetchRequestById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch a request by username.
     *
     * @param username The username of the request.
     * @return ResponseEntity containing the request entity with the specified username in the response body
     *         with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    /*@GetMapping("/request/username/{username}")
    public ResponseEntity<RequestEntity> fetchRequestByUsername(@PathVariable("username") String username) {
        try {
            return new ResponseEntity<>(requestService.fetchRequestByUsername(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }*/

    /**
     * Update a request.
     *
     * @param request The request entity to be updated.
     * @return ResponseEntity containing the updated request entity in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/request/update")
    public ResponseEntity<RequestEntity> updateRequest(@RequestBody RequestEntity request) {
        try {
            return new ResponseEntity<>(requestService.updateRequest(request), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Delete a request by ID.
     *
     * @param id The ID of the request to be deleted.
     * @return ResponseEntity with a success message in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
   /* @DeleteMapping("/request/delete/{id}")
    public ResponseEntity<String> deleteRequest(@PathVariable("id") Long id) {
        try {
            requestService.deleteRequest(id);
            return new ResponseEntity<>("Request has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }*/
}
