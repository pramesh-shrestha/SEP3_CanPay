package applicationtier.controller;

import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import com.google.api.Http;
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
   public ResponseEntity<RequestEntity> createRequest(@RequestBody RequestEntity request){
        try {
            RequestEntity requestEntity=requestService.createRequest(request);
            return new ResponseEntity<>(request, HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
   }

   @GetMapping("/request")
   public ResponseEntity<List<RequestEntity>> FetchAllRequest()
   {
       try {
           List<RequestEntity> requestEntities= requestService.FetchAllRequest();
           return new ResponseEntity<>(requestEntities,HttpStatus.OK);
       }catch (Exception e){
           return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
       }
   }

   @GetMapping("/request/id/{id}")
   public ResponseEntity<RequestEntity> FetchRequestById(@PathVariable("id") Long id){
        try {
            return new ResponseEntity<>(requestService.FetchRequestById(id),HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
   }

   @GetMapping("/request/username/{username}")
   public ResponseEntity<RequestEntity> FetchRequestByUsername(@PathVariable("username") String username){
        try {
            return new ResponseEntity<>(requestService.FetchRequestByUsername(username),HttpStatus.OK);
        }catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
   }

   @PostMapping("/request/update")
   public ResponseEntity<RequestEntity> UpdateRequest(@RequestBody RequestEntity request){
        try {
            return new ResponseEntity<>(requestService.UpdateRequest(request),HttpStatus.OK);
        }catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
   }

   @DeleteMapping("/request/delete/{id}")
   public ResponseEntity<String> DeleteRequest(@PathVariable("id") Long id){
        try {
            requestService.DeleteRequest(id);
            return new ResponseEntity<>("Request has been deleted",HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
   }
}
