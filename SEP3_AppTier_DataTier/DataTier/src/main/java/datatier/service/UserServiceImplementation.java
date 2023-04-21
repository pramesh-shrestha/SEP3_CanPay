package datatier.service;

import com.google.protobuf.Empty;
import com.google.protobuf.Int64Value;
import datatier.entity.UserEntity;
import datatier.protobuf.UpdateUserWithId;
import datatier.protobuf.User;
import datatier.protobuf.UserServiceGrpc;
import datatier.repository.UserRepository;
import io.grpc.stub.StreamObserver;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserServiceImplementation extends UserServiceGrpc.UserServiceImplBase {

  @Autowired
  private UserRepository repository;
  @Override
  public void createUser(User request, StreamObserver<User> responseObserver) {
    UserEntity entity = UserEntity.fromProto(request);
    entity = repository.save(entity);

    responseObserver.onNext(entity.toProto());
    responseObserver.onCompleted();
  }

  @Override
  public void fetchAllUsers(Empty request, StreamObserver<User> responseObserver) {
    super.fetchAllUsers(request, responseObserver);
  }

  @Override
  public void fetchUserById(Int64Value request, StreamObserver<User> responseObserver) {
    super.fetchUserById(request, responseObserver);
  }

  @Override
  public void deleteUserById(Int64Value request, StreamObserver<Empty> responseObserver) {
    super.deleteUserById(request, responseObserver);
  }

  @Override
  public void updateUser(UpdateUserWithId request, StreamObserver<User> responseObserver) {
    super.updateUser(request, responseObserver);
  }
}
