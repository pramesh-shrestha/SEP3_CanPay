package applicationtier.protobuf;

import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.asyncServerStreamingCall;
import static io.grpc.stub.ClientCalls.asyncClientStreamingCall;
import static io.grpc.stub.ClientCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.blockingServerStreamingCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncServerStreamingCall;
import static io.grpc.stub.ServerCalls.asyncClientStreamingCall;
import static io.grpc.stub.ServerCalls.asyncBidiStreamingCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedStreamingCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.0.1)",
    comments = "Source: user.proto")
public class UserProtoServiceGrpc {

  private UserProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "UserProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.User.UserProtoObj,
      applicationtier.protobuf.User.UserProtoObj> METHOD_CREATE_USER =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "CreateUser"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      applicationtier.protobuf.User.UserListResponse> METHOD_FETCH_ALL_USER =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "FetchAllUser"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Empty.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserListResponse.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.User.UserProtoObj> METHOD_FETCH_USER_BY_USERNAME =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "FetchUserByUsername"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      applicationtier.protobuf.User.UserProtoObj> METHOD_FETCH_USER_BY_ID =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "FetchUserById"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.User.UserProtoObj,
      applicationtier.protobuf.User.UserProtoObj> METHOD_UPDATE_USER =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "UpdateUser"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.User.UserProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      com.google.protobuf.BoolValue> METHOD_DELETE_USER =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "DeleteUser"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      com.google.protobuf.Int32Value> METHOD_FETCH_BALANCE_BY_USERNAME =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "UserProtoService", "FetchBalanceByUsername"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int32Value.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static UserProtoServiceStub newStub(io.grpc.Channel channel) {
    return new UserProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static UserProtoServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new UserProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static UserProtoServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new UserProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class UserProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createUser(applicationtier.protobuf.User.UserProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_USER, responseObserver);
    }

    /**
     */
    public void fetchAllUser(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserListResponse> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_ALL_USER, responseObserver);
    }

    /**
     */
    public void fetchUserByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_USER_BY_USERNAME, responseObserver);
    }

    /**
     */
    public void fetchUserById(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_USER_BY_ID, responseObserver);
    }

    /**
     */
    public void updateUser(applicationtier.protobuf.User.UserProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_UPDATE_USER, responseObserver);
    }

    /**
     */
    public void deleteUser(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_USER, responseObserver);
    }

    /**
     * <pre>
     *  rpc UpdateBalance(google.protobuf.Int32Value) returns(google.protobuf.BoolValue);
     * </pre>
     */
    public void fetchBalanceByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Int32Value> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_BALANCE_BY_USERNAME, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            METHOD_CREATE_USER,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.User.UserProtoObj,
                applicationtier.protobuf.User.UserProtoObj>(
                  this, METHODID_CREATE_USER)))
          .addMethod(
            METHOD_FETCH_ALL_USER,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Empty,
                applicationtier.protobuf.User.UserListResponse>(
                  this, METHODID_FETCH_ALL_USER)))
          .addMethod(
            METHOD_FETCH_USER_BY_USERNAME,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.User.UserProtoObj>(
                  this, METHODID_FETCH_USER_BY_USERNAME)))
          .addMethod(
            METHOD_FETCH_USER_BY_ID,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                applicationtier.protobuf.User.UserProtoObj>(
                  this, METHODID_FETCH_USER_BY_ID)))
          .addMethod(
            METHOD_UPDATE_USER,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.User.UserProtoObj,
                applicationtier.protobuf.User.UserProtoObj>(
                  this, METHODID_UPDATE_USER)))
          .addMethod(
            METHOD_DELETE_USER,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                com.google.protobuf.BoolValue>(
                  this, METHODID_DELETE_USER)))
          .addMethod(
            METHOD_FETCH_BALANCE_BY_USERNAME,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                com.google.protobuf.Int32Value>(
                  this, METHODID_FETCH_BALANCE_BY_USERNAME)))
          .build();
    }
  }

  /**
   */
  public static final class UserProtoServiceStub extends io.grpc.stub.AbstractStub<UserProtoServiceStub> {
    private UserProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserProtoServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserProtoServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createUser(applicationtier.protobuf.User.UserProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_CREATE_USER, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAllUser(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserListResponse> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_USER, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchUserByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_USER_BY_USERNAME, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchUserById(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_USER_BY_ID, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void updateUser(applicationtier.protobuf.User.UserProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_UPDATE_USER, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteUser(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_DELETE_USER, getCallOptions()), request, responseObserver);
    }

    /**
     * <pre>
     *  rpc UpdateBalance(google.protobuf.Int32Value) returns(google.protobuf.BoolValue);
     * </pre>
     */
    public void fetchBalanceByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Int32Value> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_BALANCE_BY_USERNAME, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class UserProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<UserProtoServiceBlockingStub> {
    private UserProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserProtoServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserProtoServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.User.UserProtoObj createUser(applicationtier.protobuf.User.UserProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_CREATE_USER, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.User.UserListResponse fetchAllUser(com.google.protobuf.Empty request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_ALL_USER, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.User.UserProtoObj fetchUserByUsername(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_USER_BY_USERNAME, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.User.UserProtoObj fetchUserById(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_USER_BY_ID, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.User.UserProtoObj updateUser(applicationtier.protobuf.User.UserProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_UPDATE_USER, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteUser(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_DELETE_USER, getCallOptions(), request);
    }

    /**
     * <pre>
     *  rpc UpdateBalance(google.protobuf.Int32Value) returns(google.protobuf.BoolValue);
     * </pre>
     */
    public com.google.protobuf.Int32Value fetchBalanceByUsername(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_BALANCE_BY_USERNAME, getCallOptions(), request);
    }
  }

  /**
   */
  public static final class UserProtoServiceFutureStub extends io.grpc.stub.AbstractStub<UserProtoServiceFutureStub> {
    private UserProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private UserProtoServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected UserProtoServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new UserProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.User.UserProtoObj> createUser(
        applicationtier.protobuf.User.UserProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_CREATE_USER, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.User.UserListResponse> fetchAllUser(
        com.google.protobuf.Empty request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_USER, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.User.UserProtoObj> fetchUserByUsername(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_USER_BY_USERNAME, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.User.UserProtoObj> fetchUserById(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_USER_BY_ID, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.User.UserProtoObj> updateUser(
        applicationtier.protobuf.User.UserProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_UPDATE_USER, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteUser(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_DELETE_USER, getCallOptions()), request);
    }

    /**
     * <pre>
     *  rpc UpdateBalance(google.protobuf.Int32Value) returns(google.protobuf.BoolValue);
     * </pre>
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.Int32Value> fetchBalanceByUsername(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_BALANCE_BY_USERNAME, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_USER = 0;
  private static final int METHODID_FETCH_ALL_USER = 1;
  private static final int METHODID_FETCH_USER_BY_USERNAME = 2;
  private static final int METHODID_FETCH_USER_BY_ID = 3;
  private static final int METHODID_UPDATE_USER = 4;
  private static final int METHODID_DELETE_USER = 5;
  private static final int METHODID_FETCH_BALANCE_BY_USERNAME = 6;

  private static class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final UserProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(UserProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_USER:
          serviceImpl.createUser((applicationtier.protobuf.User.UserProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_ALL_USER:
          serviceImpl.fetchAllUser((com.google.protobuf.Empty) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserListResponse>) responseObserver);
          break;
        case METHODID_FETCH_USER_BY_USERNAME:
          serviceImpl.fetchUserByUsername((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_USER_BY_ID:
          serviceImpl.fetchUserById((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj>) responseObserver);
          break;
        case METHODID_UPDATE_USER:
          serviceImpl.updateUser((applicationtier.protobuf.User.UserProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.User.UserProtoObj>) responseObserver);
          break;
        case METHODID_DELETE_USER:
          serviceImpl.deleteUser((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue>) responseObserver);
          break;
        case METHODID_FETCH_BALANCE_BY_USERNAME:
          serviceImpl.fetchBalanceByUsername((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<com.google.protobuf.Int32Value>) responseObserver);
          break;
        default:
          throw new AssertionError();
      }
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public io.grpc.stub.StreamObserver<Req> invoke(
        io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        default:
          throw new AssertionError();
      }
    }
  }

  public static io.grpc.ServiceDescriptor getServiceDescriptor() {
    return new io.grpc.ServiceDescriptor(SERVICE_NAME,
        METHOD_CREATE_USER,
        METHOD_FETCH_ALL_USER,
        METHOD_FETCH_USER_BY_USERNAME,
        METHOD_FETCH_USER_BY_ID,
        METHOD_UPDATE_USER,
        METHOD_DELETE_USER,
        METHOD_FETCH_BALANCE_BY_USERNAME);
  }

}
