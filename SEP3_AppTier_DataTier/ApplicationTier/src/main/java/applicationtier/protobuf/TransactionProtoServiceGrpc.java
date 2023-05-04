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
        comments = "Source: transaction.proto")
public class TransactionProtoServiceGrpc {


  private TransactionProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "TransactionProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Transaction.TransactionProtoObj,
          applicationtier.protobuf.Transaction.TransactionProtoObj> METHOD_CREATE_TRANSACTION_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "CreateTransactionAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObj.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
          applicationtier.protobuf.Transaction.TransactionProtoObj> METHOD_FETCH_TRANSACTION_BY_ID_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "FetchTransactionByIdAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
          applicationtier.protobuf.Transaction.TransactionProtoObjList> METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "FetchAlLTransactionsBySenderAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
          applicationtier.protobuf.Transaction.TransactionProtoObjList> METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "FetchAllTransactionsByReceiverAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
          applicationtier.protobuf.Transaction.TransactionProtoObjList> METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "FetchAlLTransactionsInvolvingUserAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
          applicationtier.protobuf.Transaction.TransactionProtoObjList> METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "FetchTransactionsByDateAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Transaction.TransactionProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
          com.google.protobuf.BoolValue> METHOD_DELETE_TRANSACTION_ASYNC =
          io.grpc.MethodDescriptor.create(
                  io.grpc.MethodDescriptor.MethodType.UNARY,
                  generateFullMethodName(
                          "TransactionProtoService", "DeleteTransactionAsync"),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
                  io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static TransactionProtoServiceStub newStub(io.grpc.Channel channel) {
    return new TransactionProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static TransactionProtoServiceBlockingStub newBlockingStub(
          io.grpc.Channel channel) {
    return new TransactionProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static TransactionProtoServiceFutureStub newFutureStub(
          io.grpc.Channel channel) {
    return new TransactionProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class TransactionProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createTransactionAsync(applicationtier.protobuf.Transaction.TransactionProtoObj request,
                                       io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_TRANSACTION_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchTransactionByIdAsync(com.google.protobuf.Int64Value request,
                                          io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_TRANSACTION_BY_ID_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAlLTransactionsBySenderAsync(com.google.protobuf.StringValue request,
                                                  io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAllTransactionsByReceiverAsync(com.google.protobuf.StringValue request,
                                                    io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAlLTransactionsInvolvingUserAsync(com.google.protobuf.StringValue request,
                                                       io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchTransactionsByDateAsync(com.google.protobuf.StringValue request,
                                             io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC, responseObserver);
    }

    /**
     */
    public void deleteTransactionAsync(com.google.protobuf.Int64Value request,
                                       io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_TRANSACTION_ASYNC, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
              .addMethod(
                      METHOD_CREATE_TRANSACTION_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      applicationtier.protobuf.Transaction.TransactionProtoObj,
                                      applicationtier.protobuf.Transaction.TransactionProtoObj>(
                                      this, METHODID_CREATE_TRANSACTION_ASYNC)))
              .addMethod(
                      METHOD_FETCH_TRANSACTION_BY_ID_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.Int64Value,
                                      applicationtier.protobuf.Transaction.TransactionProtoObj>(
                                      this, METHODID_FETCH_TRANSACTION_BY_ID_ASYNC)))
              .addMethod(
                      METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.StringValue,
                                      applicationtier.protobuf.Transaction.TransactionProtoObjList>(
                                      this, METHODID_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC)))
              .addMethod(
                      METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.StringValue,
                                      applicationtier.protobuf.Transaction.TransactionProtoObjList>(
                                      this, METHODID_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC)))
              .addMethod(
                      METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.StringValue,
                                      applicationtier.protobuf.Transaction.TransactionProtoObjList>(
                                      this, METHODID_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC)))
              .addMethod(
                      METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.StringValue,
                                      applicationtier.protobuf.Transaction.TransactionProtoObjList>(
                                      this, METHODID_FETCH_TRANSACTIONS_BY_DATE_ASYNC)))
              .addMethod(
                      METHOD_DELETE_TRANSACTION_ASYNC,
                      asyncUnaryCall(
                              new MethodHandlers<
                                      com.google.protobuf.Int64Value,
                                      com.google.protobuf.BoolValue>(
                                      this, METHODID_DELETE_TRANSACTION_ASYNC)))
              .build();
    }
  }

  /**
   */
  public static final class TransactionProtoServiceStub extends io.grpc.stub.AbstractStub<TransactionProtoServiceStub> {
    private TransactionProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private TransactionProtoServiceStub(io.grpc.Channel channel,
                                        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TransactionProtoServiceStub build(io.grpc.Channel channel,
                                                io.grpc.CallOptions callOptions) {
      return new TransactionProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createTransactionAsync(applicationtier.protobuf.Transaction.TransactionProtoObj request,
                                       io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_CREATE_TRANSACTION_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchTransactionByIdAsync(com.google.protobuf.Int64Value request,
                                          io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_FETCH_TRANSACTION_BY_ID_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAlLTransactionsBySenderAsync(com.google.protobuf.StringValue request,
                                                  io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAllTransactionsByReceiverAsync(com.google.protobuf.StringValue request,
                                                    io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAlLTransactionsInvolvingUserAsync(com.google.protobuf.StringValue request,
                                                       io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchTransactionsByDateAsync(com.google.protobuf.StringValue request,
                                             io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteTransactionAsync(com.google.protobuf.Int64Value request,
                                       io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
              getChannel().newCall(METHOD_DELETE_TRANSACTION_ASYNC, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class TransactionProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<TransactionProtoServiceBlockingStub> {
    private TransactionProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private TransactionProtoServiceBlockingStub(io.grpc.Channel channel,
                                                io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TransactionProtoServiceBlockingStub build(io.grpc.Channel channel,
                                                        io.grpc.CallOptions callOptions) {
      return new TransactionProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObj createTransactionAsync(applicationtier.protobuf.Transaction.TransactionProtoObj request) {
      return blockingUnaryCall(
              getChannel(), METHOD_CREATE_TRANSACTION_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObj fetchTransactionByIdAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
              getChannel(), METHOD_FETCH_TRANSACTION_BY_ID_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObjList fetchAlLTransactionsBySenderAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
              getChannel(), METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObjList fetchAllTransactionsByReceiverAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
              getChannel(), METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObjList fetchAlLTransactionsInvolvingUserAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
              getChannel(), METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Transaction.TransactionProtoObjList fetchTransactionsByDateAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
              getChannel(), METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteTransactionAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
              getChannel(), METHOD_DELETE_TRANSACTION_ASYNC, getCallOptions(), request);
    }
  }

  /**
   */
  public static final class TransactionProtoServiceFutureStub extends io.grpc.stub.AbstractStub<TransactionProtoServiceFutureStub> {
    private TransactionProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private TransactionProtoServiceFutureStub(io.grpc.Channel channel,
                                              io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected TransactionProtoServiceFutureStub build(io.grpc.Channel channel,
                                                      io.grpc.CallOptions callOptions) {
      return new TransactionProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObj> createTransactionAsync(
            applicationtier.protobuf.Transaction.TransactionProtoObj request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_CREATE_TRANSACTION_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObj> fetchTransactionByIdAsync(
            com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_FETCH_TRANSACTION_BY_ID_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObjList> fetchAlLTransactionsBySenderAsync(
            com.google.protobuf.StringValue request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObjList> fetchAllTransactionsByReceiverAsync(
            com.google.protobuf.StringValue request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObjList> fetchAlLTransactionsInvolvingUserAsync(
            com.google.protobuf.StringValue request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Transaction.TransactionProtoObjList> fetchTransactionsByDateAsync(
            com.google.protobuf.StringValue request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteTransactionAsync(
            com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
              getChannel().newCall(METHOD_DELETE_TRANSACTION_ASYNC, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_TRANSACTION_ASYNC = 0;
  private static final int METHODID_FETCH_TRANSACTION_BY_ID_ASYNC = 1;
  private static final int METHODID_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC = 2;
  private static final int METHODID_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC = 3;
  private static final int METHODID_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC = 4;
  private static final int METHODID_FETCH_TRANSACTIONS_BY_DATE_ASYNC = 5;
  private static final int METHODID_DELETE_TRANSACTION_ASYNC = 6;

  private static class MethodHandlers<Req, Resp> implements
          io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
          io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final TransactionProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(TransactionProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_TRANSACTION_ASYNC:
          serviceImpl.createTransactionAsync((applicationtier.protobuf.Transaction.TransactionProtoObj) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_TRANSACTION_BY_ID_ASYNC:
          serviceImpl.fetchTransactionByIdAsync((com.google.protobuf.Int64Value) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC:
          serviceImpl.fetchAlLTransactionsBySenderAsync((com.google.protobuf.StringValue) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC:
          serviceImpl.fetchAllTransactionsByReceiverAsync((com.google.protobuf.StringValue) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC:
          serviceImpl.fetchAlLTransactionsInvolvingUserAsync((com.google.protobuf.StringValue) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_TRANSACTIONS_BY_DATE_ASYNC:
          serviceImpl.fetchTransactionsByDateAsync((com.google.protobuf.StringValue) request,
                  (io.grpc.stub.StreamObserver<applicationtier.protobuf.Transaction.TransactionProtoObjList>) responseObserver);
          break;
        case METHODID_DELETE_TRANSACTION_ASYNC:
          serviceImpl.deleteTransactionAsync((com.google.protobuf.Int64Value) request,
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
            METHOD_CREATE_TRANSACTION_ASYNC,
            METHOD_FETCH_TRANSACTION_BY_ID_ASYNC,
            METHOD_FETCH_AL_LTRANSACTIONS_BY_SENDER_ASYNC,
            METHOD_FETCH_ALL_TRANSACTIONS_BY_RECEIVER_ASYNC,
            METHOD_FETCH_AL_LTRANSACTIONS_INVOLVING_USER_ASYNC,
            METHOD_FETCH_TRANSACTIONS_BY_DATE_ASYNC,
            METHOD_DELETE_TRANSACTION_ASYNC);
  }

}
