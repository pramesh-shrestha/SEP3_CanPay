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
    comments = "Source: notification.proto")
public class NotificationProtoServiceGrpc {

  private NotificationProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "NotificationProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Notification.NotificationProtoObj,
      applicationtier.protobuf.Notification.NotificationProtoObj> METHOD_CREATE_NOTIFICATION_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "NotificationProtoService", "CreateNotificationAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Notification.NotificationProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Notification.NotificationProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.Notification.NotificationProtoObjList> METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "NotificationProtoService", "FetchAllNotificationsByReceiverAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Notification.NotificationProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Notification.NotificationProtoObj,
      com.google.protobuf.Empty> METHOD_MARK_AS_READ =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "NotificationProtoService", "MarkAsRead"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Notification.NotificationProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Empty.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Notification.NotificationProtoObjList,
      com.google.protobuf.Empty> METHOD_MARK_ALL_AS_READ =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "NotificationProtoService", "MarkAllAsRead"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Notification.NotificationProtoObjList.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Empty.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      com.google.protobuf.BoolValue> METHOD_DELETE_NOTIFICATION_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "NotificationProtoService", "DeleteNotificationAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static NotificationProtoServiceStub newStub(io.grpc.Channel channel) {
    return new NotificationProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static NotificationProtoServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new NotificationProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static NotificationProtoServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new NotificationProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class NotificationProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createNotificationAsync(applicationtier.protobuf.Notification.NotificationProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_NOTIFICATION_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAllNotificationsByReceiverAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC, responseObserver);
    }

    /**
     */
    public void markAsRead(applicationtier.protobuf.Notification.NotificationProtoObj request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Empty> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_MARK_AS_READ, responseObserver);
    }

    /**
     */
    public void markAllAsRead(applicationtier.protobuf.Notification.NotificationProtoObjList request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Empty> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_MARK_ALL_AS_READ, responseObserver);
    }

    /**
     */
    public void deleteNotificationAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_NOTIFICATION_ASYNC, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            METHOD_CREATE_NOTIFICATION_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Notification.NotificationProtoObj,
                applicationtier.protobuf.Notification.NotificationProtoObj>(
                  this, METHODID_CREATE_NOTIFICATION_ASYNC)))
          .addMethod(
            METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.Notification.NotificationProtoObjList>(
                  this, METHODID_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC)))
          .addMethod(
            METHOD_MARK_AS_READ,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Notification.NotificationProtoObj,
                com.google.protobuf.Empty>(
                  this, METHODID_MARK_AS_READ)))
          .addMethod(
            METHOD_MARK_ALL_AS_READ,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Notification.NotificationProtoObjList,
                com.google.protobuf.Empty>(
                  this, METHODID_MARK_ALL_AS_READ)))
          .addMethod(
            METHOD_DELETE_NOTIFICATION_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                com.google.protobuf.BoolValue>(
                  this, METHODID_DELETE_NOTIFICATION_ASYNC)))
          .build();
    }
  }

  /**
   */
  public static final class NotificationProtoServiceStub extends io.grpc.stub.AbstractStub<NotificationProtoServiceStub> {
    private NotificationProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private NotificationProtoServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected NotificationProtoServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new NotificationProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createNotificationAsync(applicationtier.protobuf.Notification.NotificationProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_CREATE_NOTIFICATION_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAllNotificationsByReceiverAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void markAsRead(applicationtier.protobuf.Notification.NotificationProtoObj request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Empty> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_MARK_AS_READ, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void markAllAsRead(applicationtier.protobuf.Notification.NotificationProtoObjList request,
        io.grpc.stub.StreamObserver<com.google.protobuf.Empty> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_MARK_ALL_AS_READ, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteNotificationAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_DELETE_NOTIFICATION_ASYNC, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class NotificationProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<NotificationProtoServiceBlockingStub> {
    private NotificationProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private NotificationProtoServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected NotificationProtoServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new NotificationProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.Notification.NotificationProtoObj createNotificationAsync(applicationtier.protobuf.Notification.NotificationProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_CREATE_NOTIFICATION_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Notification.NotificationProtoObjList fetchAllNotificationsByReceiverAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.Empty markAsRead(applicationtier.protobuf.Notification.NotificationProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_MARK_AS_READ, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.Empty markAllAsRead(applicationtier.protobuf.Notification.NotificationProtoObjList request) {
      return blockingUnaryCall(
          getChannel(), METHOD_MARK_ALL_AS_READ, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteNotificationAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_DELETE_NOTIFICATION_ASYNC, getCallOptions(), request);
    }
  }

  /**
   */
  public static final class NotificationProtoServiceFutureStub extends io.grpc.stub.AbstractStub<NotificationProtoServiceFutureStub> {
    private NotificationProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private NotificationProtoServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected NotificationProtoServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new NotificationProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Notification.NotificationProtoObj> createNotificationAsync(
        applicationtier.protobuf.Notification.NotificationProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_CREATE_NOTIFICATION_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Notification.NotificationProtoObjList> fetchAllNotificationsByReceiverAsync(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.Empty> markAsRead(
        applicationtier.protobuf.Notification.NotificationProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_MARK_AS_READ, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.Empty> markAllAsRead(
        applicationtier.protobuf.Notification.NotificationProtoObjList request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_MARK_ALL_AS_READ, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteNotificationAsync(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_DELETE_NOTIFICATION_ASYNC, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_NOTIFICATION_ASYNC = 0;
  private static final int METHODID_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC = 1;
  private static final int METHODID_MARK_AS_READ = 2;
  private static final int METHODID_MARK_ALL_AS_READ = 3;
  private static final int METHODID_DELETE_NOTIFICATION_ASYNC = 4;

  private static class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final NotificationProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(NotificationProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_NOTIFICATION_ASYNC:
          serviceImpl.createNotificationAsync((applicationtier.protobuf.Notification.NotificationProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC:
          serviceImpl.fetchAllNotificationsByReceiverAsync((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Notification.NotificationProtoObjList>) responseObserver);
          break;
        case METHODID_MARK_AS_READ:
          serviceImpl.markAsRead((applicationtier.protobuf.Notification.NotificationProtoObj) request,
              (io.grpc.stub.StreamObserver<com.google.protobuf.Empty>) responseObserver);
          break;
        case METHODID_MARK_ALL_AS_READ:
          serviceImpl.markAllAsRead((applicationtier.protobuf.Notification.NotificationProtoObjList) request,
              (io.grpc.stub.StreamObserver<com.google.protobuf.Empty>) responseObserver);
          break;
        case METHODID_DELETE_NOTIFICATION_ASYNC:
          serviceImpl.deleteNotificationAsync((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue>) responseObserver);
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
        METHOD_CREATE_NOTIFICATION_ASYNC,
        METHOD_FETCH_ALL_NOTIFICATIONS_BY_RECEIVER_ASYNC,
        METHOD_MARK_AS_READ,
        METHOD_MARK_ALL_AS_READ,
        METHOD_DELETE_NOTIFICATION_ASYNC);
  }

}
