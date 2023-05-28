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
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/requests")
    public ResponseEntity<RequestEntity> createRequest(@RequestBody RequestEntity request) {
        try {
            RequestEntity requestEntity = requestService.createRequest(request);
            return new ResponseEntity<>(requestEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * Fetch a request by ID.
     *
     * @param id The ID of the request to be fetched.
     * @return ResponseEntity containing the request entity with the specified ID in the response body
     * with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/requests/{id}")
    public ResponseEntity<RequestEntity> fetchRequestById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(requestService.fetchRequestById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * Update a request.
     *
     * @param request The request entity to be updated.
     * @return ResponseEntity containing the updated request entity in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PutMapping("/requests")
    public ResponseEntity<RequestEntity> updateRequest(@RequestBody RequestEntity request) {
        try {
            return new ResponseEntity<>(requestService.updateRequest(request), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


}
