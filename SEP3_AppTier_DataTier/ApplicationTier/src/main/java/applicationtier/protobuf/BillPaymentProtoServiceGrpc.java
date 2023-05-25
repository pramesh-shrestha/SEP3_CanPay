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
    comments = "Source: bill_transaction.proto")
public class BillPaymentProtoServiceGrpc {

  private BillPaymentProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "BillPaymentProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> METHOD_CREATE_BILL_PAYMENT_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "CreateBillPaymentAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "FetchBillPaymentByIdAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "FetchAlLBillPaymentsBySenderAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "FetchAllBillPaymentsByReceiverAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "FetchAlLBillPaymentsInvolvingUserAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.StringValue,
      applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "FetchBillPaymentsByDateAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.StringValue.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      com.google.protobuf.BoolValue> METHOD_DELETE_BILL_PAYMENT_ASYNC =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "BillPaymentProtoService", "DeleteBillPaymentAsync"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static BillPaymentProtoServiceStub newStub(io.grpc.Channel channel) {
    return new BillPaymentProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static BillPaymentProtoServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new BillPaymentProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static BillPaymentProtoServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new BillPaymentProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class BillPaymentProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createBillPaymentAsync(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_BILL_PAYMENT_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchBillPaymentByIdAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAlLBillPaymentsBySenderAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAllBillPaymentsByReceiverAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchAlLBillPaymentsInvolvingUserAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC, responseObserver);
    }

    /**
     */
    public void fetchBillPaymentsByDateAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC, responseObserver);
    }

    /**
     */
    public void deleteBillPaymentAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_BILL_PAYMENT_ASYNC, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            METHOD_CREATE_BILL_PAYMENT_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObj,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObj>(
                  this, METHODID_CREATE_BILL_PAYMENT_ASYNC)))
          .addMethod(
            METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObj>(
                  this, METHODID_FETCH_BILL_PAYMENT_BY_ID_ASYNC)))
          .addMethod(
            METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>(
                  this, METHODID_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC)))
          .addMethod(
            METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>(
                  this, METHODID_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC)))
          .addMethod(
            METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>(
                  this, METHODID_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC)))
          .addMethod(
            METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.StringValue,
                applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>(
                  this, METHODID_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC)))
          .addMethod(
            METHOD_DELETE_BILL_PAYMENT_ASYNC,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                com.google.protobuf.BoolValue>(
                  this, METHODID_DELETE_BILL_PAYMENT_ASYNC)))
          .build();
    }
  }

  /**
   */
  public static final class BillPaymentProtoServiceStub extends io.grpc.stub.AbstractStub<BillPaymentProtoServiceStub> {
    private BillPaymentProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BillPaymentProtoServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BillPaymentProtoServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BillPaymentProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createBillPaymentAsync(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_CREATE_BILL_PAYMENT_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchBillPaymentByIdAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAlLBillPaymentsBySenderAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAllBillPaymentsByReceiverAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchAlLBillPaymentsInvolvingUserAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchBillPaymentsByDateAsync(com.google.protobuf.StringValue request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteBillPaymentAsync(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_DELETE_BILL_PAYMENT_ASYNC, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class BillPaymentProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<BillPaymentProtoServiceBlockingStub> {
    private BillPaymentProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BillPaymentProtoServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BillPaymentProtoServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BillPaymentProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObj createBillPaymentAsync(applicationtier.protobuf.BillTransaction.BillPaymentProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_CREATE_BILL_PAYMENT_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObj fetchBillPaymentByIdAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList fetchAlLBillPaymentsBySenderAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList fetchAllBillPaymentsByReceiverAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList fetchAlLBillPaymentsInvolvingUserAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList fetchBillPaymentsByDateAsync(com.google.protobuf.StringValue request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteBillPaymentAsync(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_DELETE_BILL_PAYMENT_ASYNC, getCallOptions(), request);
    }
  }

  /**
   */
  public static final class BillPaymentProtoServiceFutureStub extends io.grpc.stub.AbstractStub<BillPaymentProtoServiceFutureStub> {
    private BillPaymentProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private BillPaymentProtoServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected BillPaymentProtoServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new BillPaymentProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> createBillPaymentAsync(
        applicationtier.protobuf.BillTransaction.BillPaymentProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_CREATE_BILL_PAYMENT_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj> fetchBillPaymentByIdAsync(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> fetchAlLBillPaymentsBySenderAsync(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> fetchAllBillPaymentsByReceiverAsync(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> fetchAlLBillPaymentsInvolvingUserAsync(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList> fetchBillPaymentsByDateAsync(
        com.google.protobuf.StringValue request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteBillPaymentAsync(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_DELETE_BILL_PAYMENT_ASYNC, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_BILL_PAYMENT_ASYNC = 0;
  private static final int METHODID_FETCH_BILL_PAYMENT_BY_ID_ASYNC = 1;
  private static final int METHODID_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC = 2;
  private static final int METHODID_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC = 3;
  private static final int METHODID_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC = 4;
  private static final int METHODID_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC = 5;
  private static final int METHODID_DELETE_BILL_PAYMENT_ASYNC = 6;

  private static class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final BillPaymentProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(BillPaymentProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_BILL_PAYMENT_ASYNC:
          serviceImpl.createBillPaymentAsync((applicationtier.protobuf.BillTransaction.BillPaymentProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_BILL_PAYMENT_BY_ID_ASYNC:
          serviceImpl.fetchBillPaymentByIdAsync((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC:
          serviceImpl.fetchAlLBillPaymentsBySenderAsync((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC:
          serviceImpl.fetchAllBillPaymentsByReceiverAsync((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC:
          serviceImpl.fetchAlLBillPaymentsInvolvingUserAsync((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>) responseObserver);
          break;
        case METHODID_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC:
          serviceImpl.fetchBillPaymentsByDateAsync((com.google.protobuf.StringValue) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.BillTransaction.BillPaymentProtoObjList>) responseObserver);
          break;
        case METHODID_DELETE_BILL_PAYMENT_ASYNC:
          serviceImpl.deleteBillPaymentAsync((com.google.protobuf.Int64Value) request,
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
        METHOD_CREATE_BILL_PAYMENT_ASYNC,
        METHOD_FETCH_BILL_PAYMENT_BY_ID_ASYNC,
        METHOD_FETCH_AL_LBILL_PAYMENTS_BY_SENDER_ASYNC,
        METHOD_FETCH_ALL_BILL_PAYMENTS_BY_RECEIVER_ASYNC,
        METHOD_FETCH_AL_LBILL_PAYMENTS_INVOLVING_USER_ASYNC,
        METHOD_FETCH_BILL_PAYMENTS_BY_DATE_ASYNC,
        METHOD_DELETE_BILL_PAYMENT_ASYNC);
  }

}
