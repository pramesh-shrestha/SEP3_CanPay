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
    comments = "Source: debitcard.proto")
public class DebitCardProtoServiceGrpc {

  private DebitCardProtoServiceGrpc() {}

  public static final String SERVICE_NAME = "DebitCardProtoService";

  // Static method descriptors that strictly reflect the proto.
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Debitcard.DebitCardProtoObj,
      applicationtier.protobuf.Debitcard.DebitCardProtoObj> METHOD_CREATE_CARD =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "DebitCardProtoService", "CreateCard"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Debitcard.DebitCardProtoObj.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Debitcard.DebitCardProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      applicationtier.protobuf.Debitcard.DebitCardProtoObj> METHOD_FETCH_CARD_BY_USERNAME =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "DebitCardProtoService", "FetchCardByUsername"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Debitcard.DebitCardProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<applicationtier.protobuf.Debitcard.UpdateCard,
      applicationtier.protobuf.Debitcard.DebitCardProtoObj> METHOD_UPDATE_CARD_DETAILS =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "DebitCardProtoService", "UpdateCardDetails"),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Debitcard.UpdateCard.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(applicationtier.protobuf.Debitcard.DebitCardProtoObj.getDefaultInstance()));
  @io.grpc.ExperimentalApi("https://github.com/grpc/grpc-java/issues/1901")
  public static final io.grpc.MethodDescriptor<com.google.protobuf.Int64Value,
      com.google.protobuf.BoolValue> METHOD_DELETE_CARD =
      io.grpc.MethodDescriptor.create(
          io.grpc.MethodDescriptor.MethodType.UNARY,
          generateFullMethodName(
              "DebitCardProtoService", "DeleteCard"),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.Int64Value.getDefaultInstance()),
          io.grpc.protobuf.ProtoUtils.marshaller(com.google.protobuf.BoolValue.getDefaultInstance()));

  /**
   * Creates a new async stub that supports all call types for the service
   */
  public static DebitCardProtoServiceStub newStub(io.grpc.Channel channel) {
    return new DebitCardProtoServiceStub(channel);
  }

  /**
   * Creates a new blocking-style stub that supports unary and streaming output calls on the service
   */
  public static DebitCardProtoServiceBlockingStub newBlockingStub(
      io.grpc.Channel channel) {
    return new DebitCardProtoServiceBlockingStub(channel);
  }

  /**
   * Creates a new ListenableFuture-style stub that supports unary and streaming output calls on the service
   */
  public static DebitCardProtoServiceFutureStub newFutureStub(
      io.grpc.Channel channel) {
    return new DebitCardProtoServiceFutureStub(channel);
  }

  /**
   */
  public static abstract class DebitCardProtoServiceImplBase implements io.grpc.BindableService {

    /**
     */
    public void createCard(applicationtier.protobuf.Debitcard.DebitCardProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_CREATE_CARD, responseObserver);
    }

    /**
     */
    public void fetchCardByUsername(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_FETCH_CARD_BY_USERNAME, responseObserver);
    }

    /**
     */
    public void updateCardDetails(applicationtier.protobuf.Debitcard.UpdateCard request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_UPDATE_CARD_DETAILS, responseObserver);
    }

    /**
     */
    public void deleteCard(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnimplementedUnaryCall(METHOD_DELETE_CARD, responseObserver);
    }

    @java.lang.Override public io.grpc.ServerServiceDefinition bindService() {
      return io.grpc.ServerServiceDefinition.builder(getServiceDescriptor())
          .addMethod(
            METHOD_CREATE_CARD,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Debitcard.DebitCardProtoObj,
                applicationtier.protobuf.Debitcard.DebitCardProtoObj>(
                  this, METHODID_CREATE_CARD)))
          .addMethod(
            METHOD_FETCH_CARD_BY_USERNAME,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                applicationtier.protobuf.Debitcard.DebitCardProtoObj>(
                  this, METHODID_FETCH_CARD_BY_USERNAME)))
          .addMethod(
            METHOD_UPDATE_CARD_DETAILS,
            asyncUnaryCall(
              new MethodHandlers<
                applicationtier.protobuf.Debitcard.UpdateCard,
                applicationtier.protobuf.Debitcard.DebitCardProtoObj>(
                  this, METHODID_UPDATE_CARD_DETAILS)))
          .addMethod(
            METHOD_DELETE_CARD,
            asyncUnaryCall(
              new MethodHandlers<
                com.google.protobuf.Int64Value,
                com.google.protobuf.BoolValue>(
                  this, METHODID_DELETE_CARD)))
          .build();
    }
  }

  /**
   */
  public static final class DebitCardProtoServiceStub extends io.grpc.stub.AbstractStub<DebitCardProtoServiceStub> {
    private DebitCardProtoServiceStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DebitCardProtoServiceStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DebitCardProtoServiceStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DebitCardProtoServiceStub(channel, callOptions);
    }

    /**
     */
    public void createCard(applicationtier.protobuf.Debitcard.DebitCardProtoObj request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_CREATE_CARD, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void fetchCardByUsername(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_FETCH_CARD_BY_USERNAME, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void updateCardDetails(applicationtier.protobuf.Debitcard.UpdateCard request,
        io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_UPDATE_CARD_DETAILS, getCallOptions()), request, responseObserver);
    }

    /**
     */
    public void deleteCard(com.google.protobuf.Int64Value request,
        io.grpc.stub.StreamObserver<com.google.protobuf.BoolValue> responseObserver) {
      asyncUnaryCall(
          getChannel().newCall(METHOD_DELETE_CARD, getCallOptions()), request, responseObserver);
    }
  }

  /**
   */
  public static final class DebitCardProtoServiceBlockingStub extends io.grpc.stub.AbstractStub<DebitCardProtoServiceBlockingStub> {
    private DebitCardProtoServiceBlockingStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DebitCardProtoServiceBlockingStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DebitCardProtoServiceBlockingStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DebitCardProtoServiceBlockingStub(channel, callOptions);
    }

    /**
     */
    public applicationtier.protobuf.Debitcard.DebitCardProtoObj createCard(applicationtier.protobuf.Debitcard.DebitCardProtoObj request) {
      return blockingUnaryCall(
          getChannel(), METHOD_CREATE_CARD, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Debitcard.DebitCardProtoObj fetchCardByUsername(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_FETCH_CARD_BY_USERNAME, getCallOptions(), request);
    }

    /**
     */
    public applicationtier.protobuf.Debitcard.DebitCardProtoObj updateCardDetails(applicationtier.protobuf.Debitcard.UpdateCard request) {
      return blockingUnaryCall(
          getChannel(), METHOD_UPDATE_CARD_DETAILS, getCallOptions(), request);
    }

    /**
     */
    public com.google.protobuf.BoolValue deleteCard(com.google.protobuf.Int64Value request) {
      return blockingUnaryCall(
          getChannel(), METHOD_DELETE_CARD, getCallOptions(), request);
    }
  }

  /**
   */
  public static final class DebitCardProtoServiceFutureStub extends io.grpc.stub.AbstractStub<DebitCardProtoServiceFutureStub> {
    private DebitCardProtoServiceFutureStub(io.grpc.Channel channel) {
      super(channel);
    }

    private DebitCardProtoServiceFutureStub(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      super(channel, callOptions);
    }

    @java.lang.Override
    protected DebitCardProtoServiceFutureStub build(io.grpc.Channel channel,
        io.grpc.CallOptions callOptions) {
      return new DebitCardProtoServiceFutureStub(channel, callOptions);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Debitcard.DebitCardProtoObj> createCard(
        applicationtier.protobuf.Debitcard.DebitCardProtoObj request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_CREATE_CARD, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Debitcard.DebitCardProtoObj> fetchCardByUsername(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_FETCH_CARD_BY_USERNAME, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<applicationtier.protobuf.Debitcard.DebitCardProtoObj> updateCardDetails(
        applicationtier.protobuf.Debitcard.UpdateCard request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_UPDATE_CARD_DETAILS, getCallOptions()), request);
    }

    /**
     */
    public com.google.common.util.concurrent.ListenableFuture<com.google.protobuf.BoolValue> deleteCard(
        com.google.protobuf.Int64Value request) {
      return futureUnaryCall(
          getChannel().newCall(METHOD_DELETE_CARD, getCallOptions()), request);
    }
  }

  private static final int METHODID_CREATE_CARD = 0;
  private static final int METHODID_FETCH_CARD_BY_USERNAME = 1;
  private static final int METHODID_UPDATE_CARD_DETAILS = 2;
  private static final int METHODID_DELETE_CARD = 3;

  private static class MethodHandlers<Req, Resp> implements
      io.grpc.stub.ServerCalls.UnaryMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ServerStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.ClientStreamingMethod<Req, Resp>,
      io.grpc.stub.ServerCalls.BidiStreamingMethod<Req, Resp> {
    private final DebitCardProtoServiceImplBase serviceImpl;
    private final int methodId;

    public MethodHandlers(DebitCardProtoServiceImplBase serviceImpl, int methodId) {
      this.serviceImpl = serviceImpl;
      this.methodId = methodId;
    }

    @java.lang.Override
    @java.lang.SuppressWarnings("unchecked")
    public void invoke(Req request, io.grpc.stub.StreamObserver<Resp> responseObserver) {
      switch (methodId) {
        case METHODID_CREATE_CARD:
          serviceImpl.createCard((applicationtier.protobuf.Debitcard.DebitCardProtoObj) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj>) responseObserver);
          break;
        case METHODID_FETCH_CARD_BY_USERNAME:
          serviceImpl.fetchCardByUsername((com.google.protobuf.Int64Value) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj>) responseObserver);
          break;
        case METHODID_UPDATE_CARD_DETAILS:
          serviceImpl.updateCardDetails((applicationtier.protobuf.Debitcard.UpdateCard) request,
              (io.grpc.stub.StreamObserver<applicationtier.protobuf.Debitcard.DebitCardProtoObj>) responseObserver);
          break;
        case METHODID_DELETE_CARD:
          serviceImpl.deleteCard((com.google.protobuf.Int64Value) request,
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
        METHOD_CREATE_CARD,
        METHOD_FETCH_CARD_BY_USERNAME,
        METHOD_UPDATE_CARD_DETAILS,
        METHOD_DELETE_CARD);
  }

}
