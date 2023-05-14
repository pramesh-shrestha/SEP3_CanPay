package applicationtier.controller;

import applicationtier.entity.NotificationEntity;
import applicationtier.service.serviceInterfaces.INotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.server.ResponseStatusException;

import java.util.List;

@RestController
public class NotificationController {
    private final INotificationService notificationService;

    @Autowired
    public NotificationController(INotificationService notificationService) {
        this.notificationService = notificationService;
    }

    //Create notification
    @PostMapping("/notification/create")
    public ResponseEntity<NotificationEntity> createNotification(@RequestBody NotificationEntity notification) {
        try {

            return new ResponseEntity<>(notificationService.createNotification(notification), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error creating notification", e);
        }
    }

    @GetMapping("/notification/receiver/{receiverUsername}")
    public ResponseEntity<List<NotificationEntity>> fetchAllNotificationsByReceiver(@PathVariable("receiverUsername") String receiverUsername) {

        try {
            return new ResponseEntity<>(notificationService.fetchAllNotificationsByReceiver(receiverUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /*@PutMapping("/notifications/markAsRead/{notification}")
    public ResponseEntity<?> markAsRead(@PathVariable("notification") NotificationEntity notification) {
        try {
            notificationService.markAsRead(notification);
            return ResponseEntity.ok().build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }*/

    @PostMapping("/notifications/markAllAsRead")
    public ResponseEntity<?> markAllAsRead(@RequestBody List<NotificationEntity> allNotifications) {
        try {
            System.out.println("Mark All As Read called in notification controller");
            notificationService.markAllAsRead(allNotifications);
            return ResponseEntity.ok().build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    @DeleteMapping("/notification/delete/{id}")
    public ResponseEntity<String> deleteNotification(@PathVariable("id") Long id) {

        try {
            notificationService.deleteNotification(id);
            return new ResponseEntity<>("Notification has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
