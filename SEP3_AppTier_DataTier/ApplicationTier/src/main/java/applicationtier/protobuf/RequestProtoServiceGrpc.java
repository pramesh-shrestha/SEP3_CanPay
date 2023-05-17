package applicationtier.protobuf;

import static io.grpc.stub.ClientCalls.asyncUnaryCall;
import static io.grpc.stub.ClientCalls.blockingUnaryCall;
import static io.grpc.stub.ClientCalls.futureUnaryCall;
import static io.grpc.MethodDescriptor.generateFullMethodName;
import static io.grpc.stub.ServerCalls.asyncUnaryCall;
import static io.grpc.stub.ServerCalls.asyncUnimplementedUnaryCall;

/**
 */
@javax.annotation.Generated(
    value = "by gRPC proto compiler (version 1.0.1)",
    comments = "Source: request.proto")
public class RequestProtoServiceGrpc {

  private RequestProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "RequestProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Request.RequestProtoObj,
      applicationtier.protobuf.Request.RequestProtoObj> METHOD_CREATE_REQUEST_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "createRequestAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Empty,
      applicationtier.protobuf.Request.RequestProtoObjList> METHOD_FETCH_ALL_REQUESTS_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "fetchAllRequestsAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Empty.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      applicationtier.protobuf.Request.RequestProtoObj> METHOD_FETCH_REQUEST_BY_ID_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "fetchRequestByIdAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.Request.RequestProtoObj> METHOD_FETCH_REQUEST_BY_USERNAME =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "fetchRequestByUsername"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Request.RequestProtoObj,
      applicationtier.protobuf.Request.RequestProtoObj> METHOD_UPDATE_REQUEST_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "updateRequestAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Request.RequestProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      com.google.protobuf.BoolValue> METHOD_DELETE_REQUEST_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "RequestProtoService", "deleteRequestAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static RequestProtoServiceStub newStub(io.grpc.Channel channel) {
    return new RequestProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static RequestProtoServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new RequestProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static RequestProtoServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new RequestProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class RequestProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_REQUEST_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAllRequestsAsync(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_ALL_REQUESTS_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchRequestByIdAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_REQUEST_BY_ID_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchRequestByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_REQUEST_BY_USERNAME, responseObserver);
    }

    /**
     */
    public void updateRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_UPDATE_REQUEST_ASYNC, responseObserver);
    }

    /**
     */
    public void deleteRequestAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_REQUEST_ASYNC, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            METHOD_CREATE_REQUEST_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Request.RequestProtoObj,
                applicationtier.protobuf.Request.RequestProtoObj>(
                  this, METHODID_CREATE_REQUEST_ASYNC)))
          .addMethod(
            METHOD_FETCH_ALL_REQUESTS_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Empty,
                applicationtier.protobuf.Request.RequestProtoObjList>(
                  this, METHODID_FETCH_ALL_REQUESTS_ASYNC)))
          .addMethod(
            METHOD_FETCH_REQUEST_BY_ID_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                applicationtier.protobuf.Request.RequestProtoObj>(
                  this, METHODID_FETCH_REQUEST_BY_ID_ASYNC)))
          .addMethod(
            METHOD_FETCH_REQUEST_BY_USERNAME,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.Request.RequestProtoObj>(
                  this, METHODID_FETCH_REQUEST_BY_USERNAME)))
          .addMethod(
            METHOD_UPDATE_REQUEST_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Request.RequestProtoObj,
                applicationtier.protobuf.Request.RequestProtoObj>(
                  this, METHODID_UPDATE_REQUEST_ASYNC)))
          .addMethod(
            METHOD_DELETE_REQUEST_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                com.google.protobuf.BoolValue>(
                  this, METHODID_DELETE_REQUEST_ASYNC)))
          .build();
    }
  }

  /**
   */
  public static final class RequestProtoServiceStub extends io.grpc.stub.AbstractStub<RequestProtoServiceStub> {
    private RequestProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private RequestProtoServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected RequestProtoServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new RequestProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_CREATE_REQUEST_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAllRequestsAsync(com.google.protobuf.Empty request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_REQUESTS_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchRequestByIdAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_REQUEST_BY_ID_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchRequestByUsername(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_REQUEST_BY_USERNAME, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void updateRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_UPDATE_REQUEST_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteRequestAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_DELETE_REQUEST_ASYNC, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class RequestProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<RequestProtoServiceBlockingStub> {
    private RequestProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private RequestProtoServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected RequestProtoServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new RequestProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.Request.RequestProtoObj createRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_CREATE_REQUEST_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Request.RequestProtoObjList fetchAllRequestsAsync(com.google.protobuf.Empty request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_ALL_REQUESTS_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Request.RequestProtoObj fetchRequestByIdAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_REQUEST_BY_ID_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Request.RequestProtoObj fetchRequestByUsername(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_REQUEST_BY_USERNAME, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Request.RequestProtoObj updateRequestAsync(applicationtier.protobuf.Request.RequestProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_UPDATE_REQUEST_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteRequestAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_DELETE_REQUEST_ASYNC, getCallOptions(), request);
    }


  }

  /**
   */
  public static final class RequestProtoServiceFutureStub extends io.grpc.stub.AbstractStub<RequestProtoServiceFutureStub> {
    private RequestProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private RequestProtoServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected RequestProtoServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new RequestProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Request.RequestProtoObj> createRequestAsync(
        applicationtier.protobuf.Request.RequestProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_CREATE_REQUEST_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Request.RequestProtoObjList> fetchAllRequestsAsync(
        com.google.protobuf.Empty request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_REQUESTS_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Request.RequestProtoObj> fetchRequestByIdAsync(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_REQUEST_BY_ID_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Request.RequestProtoObj> fetchRequestByUsername(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_REQUEST_BY_USERNAME, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Request.RequestProtoObj> updateRequestAsync(
        applicationtier.protobuf.Request.RequestProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_UPDATE_REQUEST_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteRequestAsync(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_DELETE_REQUEST_ASYNC, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_REQUEST_ASYNC = 0;
  private static final int METHODID_FETCH_ALL_REQUESTS_ASYNC = 1;
  private static final int METHODID_FETCH_REQUEST_BY_ID_ASYNC = 2;
  private static final int METHODID_FETCH_REQUEST_BY_USERNAME = 3;
  private static final int METHODID_UPDATE_REQUEST_ASYNC = 4;
  private static final int METHODID_DELETE_REQUEST_ASYNC = 5;

  private static class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final RequestProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(RequestProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_REQUEST_ASYNC:
          serviceImpl.createRequestAsync((applicationtier.protobuf.Request.RequestProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_ALL_REQUESTS_ASYNC:
          serviceImpl.fetchAllRequestsAsync((com.google.protobuf.Empty) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_REQUEST_BY_ID_ASYNC:
          serviceImpl.fetchRequestByIdAsync((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_REQUEST_BY_USERNAME:
          serviceImpl.fetchRequestByUsername((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj>) responseObserver);
          break;
        case METHODID_UPDATE_REQUEST_ASYNC:
          serviceImpl.updateRequestAsync((applicationtier.protobuf.Request.RequestProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Request.RequestProtoObj>) responseObserver);
          break;
        case METHODID_DELETE_REQUEST_ASYNC:
          serviceImpl.deleteRequestAsync((com.google.protobuf.Int64Value) request,
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
        METHOD_CREATE_REQUEST_ASYNC,
        METHOD_FETCH_ALL_REQUESTS_ASYNC,
        METHOD_FETCH_REQUEST_BY_ID_ASYNC,
        METHOD_FETCH_REQUEST_BY_USERNAME,
        METHOD_UPDATE_REQUEST_ASYNC,
        METHOD_DELETE_REQUEST_ASYNC);
  }

}
