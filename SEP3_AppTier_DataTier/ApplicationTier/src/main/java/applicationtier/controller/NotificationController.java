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

    /**
     * Create a new notification.
     *
     * @param notification The notification entity to be created.
     * @return ResponseEntity containing the created notification entity in the response body with HTTP status 200 (OK),
     *         or throws a ResponseStatusException with HTTP status 500 (Internal Server Error) if an exception occurs.
     */
    @PostMapping("/notification/create")
    public ResponseEntity<NotificationEntity> createNotification(@RequestBody NotificationEntity notification) {
        try {

            return new ResponseEntity<>(notificationService.createNotification(notification), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error creating notification", e);
        }
    }

    /**
     * Fetch a notification by ID.
     *
     * @param id The ID of the notification to be fetched.
     * @return ResponseEntity containing the notification entity with the specified ID in the response body
     *         with HTTP status 200 (OK), or throws a ResponseStatusException with HTTP status 500 (Internal Server Error)
     *         if an exception occurs.
     */
    @GetMapping("/notification/id/{id}")
    public ResponseEntity<NotificationEntity> fetchNotificationById(@PathVariable("id") long id) {
        try {
            return new ResponseEntity<>(notificationService.fetchNotificationById(id), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.INTERNAL_SERVER_ERROR, "Error creating notification", e);
        }
    }

    /**
     * Fetch all notifications by receiver username.
     *
     * @param receiverUsername The username of the notification receiver.
     * @return ResponseEntity containing a list of notification entities with the specified receiver username
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/notification/receiver/{receiverUsername}")
    public ResponseEntity<List<NotificationEntity>> fetchAllNotificationsByReceiver(@PathVariable("receiverUsername") String receiverUsername) {

        try {
            return new ResponseEntity<>(notificationService.fetchAllNotificationsByReceiver(receiverUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Mark a notification as read.
     *
     * @param notification The notification entity to be marked as read.
     * @return ResponseEntity with HTTP status 200 (OK) if the notification is marked as read successfully,
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/notifications/markAsRead")
    public ResponseEntity<?> markAsRead(@RequestBody NotificationEntity notification) {
        try {
            notificationService.markAsRead(notification);
            return ResponseEntity.ok().build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    /**
     * Mark all notifications as read.
     *
     * @param allNotifications List of notification entities to be marked as read.
     * @return ResponseEntity with HTTP status 200 (OK) if all notifications are marked as read successfully,
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/notifications/markAllAsRead")
    public ResponseEntity<?> markAllAsRead(@RequestBody List<NotificationEntity> allNotifications) {
        try {
            notificationService.markAllAsRead(allNotifications);
            return ResponseEntity.ok().build();
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    /**
     * Delete a notification by ID.
     *
     * @param id The ID of the notification to be deleted.
     * @return ResponseEntity with a success message in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
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
