package applicationtier;

import org.lognet.springboot.grpc.autoconfigure.security.SecurityAutoConfiguration;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication(exclude = SecurityAutoConfiguration.class)
public class ApplicationTierApplication {

    public static void main(String[] args) {
        SpringApplication.run(ApplicationTierApplication.class, args);
    }

}
