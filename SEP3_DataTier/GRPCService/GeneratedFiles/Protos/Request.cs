// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/request.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SEP3_DataTier {

  /// <summary>Holder for reflection information generated from Protos/request.proto</summary>
  public static partial class RequestReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/request.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static RequestReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChRQcm90b3MvcmVxdWVzdC5wcm90bxoeZ29vZ2xlL3Byb3RvYnVmL3dyYXBw",
            "ZXJzLnByb3RvGhFQcm90b3MvdXNlci5wcm90bxobZ29vZ2xlL3Byb3RvYnVm",
            "L2VtcHR5LnByb3RvIs4BCg9SZXF1ZXN0UHJvdG9PYmoSEQoJcmVxdWVzdElk",
            "GAEgASgDEhIKCmlzQXBwcm92ZWQYAiABKAgSDgoGc3RhdHVzGAMgASgJEg4K",
            "BmFtb3VudBgEIAEoBRIPCgdjb21tZW50GAUgASgJEiQKDXJlcXVlc3RTZW5k",
            "ZXIYBiABKAsyDS5Vc2VyUHJvdG9PYmoSJgoPcmVxdWVzdFJlY2VpdmVyGAcg",
            "ASgLMg0uVXNlclByb3RvT2JqEhUKDXJlcXVlc3RlZERhdGUYCCABKAkiOQoT",
            "UmVxdWVzdFByb3RvT2JqTGlzdBIiCghyZXF1ZXN0cxgBIAMoCzIQLlJlcXVl",
            "c3RQcm90b09iajLRAQoTUmVxdWVzdFByb3RvU2VydmljZRI4ChJDcmVhdGVS",
            "ZXF1ZXN0QXN5bmMSEC5SZXF1ZXN0UHJvdG9PYmoaEC5SZXF1ZXN0UHJvdG9P",
            "YmoSRgoVRmV0Y2hSZXF1ZXN0QnlJZEFzeW5jEhsuZ29vZ2xlLnByb3RvYnVm",
            "LkludDY0VmFsdWUaEC5SZXF1ZXN0UHJvdG9PYmoSOAoSVXBkYXRlUmVxdWVz",
            "dEFzeW5jEhAuUmVxdWVzdFByb3RvT2JqGhAuUmVxdWVzdFByb3RvT2JqQhCq",
            "Ag1TRVAzX0RhdGFUaWVyYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::SEP3_DataTier.UserReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.RequestProtoObj), global::SEP3_DataTier.RequestProtoObj.Parser, new[]{ "RequestId", "IsApproved", "Status", "Amount", "Comment", "RequestSender", "RequestReceiver", "RequestedDate" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.RequestProtoObjList), global::SEP3_DataTier.RequestProtoObjList.Parser, new[]{ "Requests" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class RequestProtoObj : pb::IMessage<RequestProtoObj>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<RequestProtoObj> _parser = new pb::MessageParser<RequestProtoObj>(() => new RequestProtoObj());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<RequestProtoObj> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.RequestReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObj() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObj(RequestProtoObj other) : this() {
      requestId_ = other.requestId_;
      isApproved_ = other.isApproved_;
      status_ = other.status_;
      amount_ = other.amount_;
      comment_ = other.comment_;
      requestSender_ = other.requestSender_ != null ? other.requestSender_.Clone() : null;
      requestReceiver_ = other.requestReceiver_ != null ? other.requestReceiver_.Clone() : null;
      requestedDate_ = other.requestedDate_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObj Clone() {
      return new RequestProtoObj(this);
    }

    /// <summary>Field number for the "requestId" field.</summary>
    public const int RequestIdFieldNumber = 1;
    private long requestId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long RequestId {
      get { return requestId_; }
      set {
        requestId_ = value;
      }
    }

    /// <summary>Field number for the "isApproved" field.</summary>
    public const int IsApprovedFieldNumber = 2;
    private bool isApproved_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool IsApproved {
      get { return isApproved_; }
      set {
        isApproved_ = value;
      }
    }

    /// <summary>Field number for the "status" field.</summary>
    public const int StatusFieldNumber = 3;
    private string status_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Status {
      get { return status_; }
      set {
        status_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "amount" field.</summary>
    public const int AmountFieldNumber = 4;
    private int amount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Amount {
      get { return amount_; }
      set {
        amount_ = value;
      }
    }

    /// <summary>Field number for the "comment" field.</summary>
    public const int CommentFieldNumber = 5;
    private string comment_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Comment {
      get { return comment_; }
      set {
        comment_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "requestSender" field.</summary>
    public const int RequestSenderFieldNumber = 6;
    private global::SEP3_DataTier.UserProtoObj requestSender_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::SEP3_DataTier.UserProtoObj RequestSender {
      get { return requestSender_; }
      set {
        requestSender_ = value;
      }
    }

    /// <summary>Field number for the "requestReceiver" field.</summary>
    public const int RequestReceiverFieldNumber = 7;
    private global::SEP3_DataTier.UserProtoObj requestReceiver_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::SEP3_DataTier.UserProtoObj RequestReceiver {
      get { return requestReceiver_; }
      set {
        requestReceiver_ = value;
      }
    }

    /// <summary>Field number for the "requestedDate" field.</summary>
    public const int RequestedDateFieldNumber = 8;
    private string requestedDate_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string RequestedDate {
      get { return requestedDate_; }
      set {
        requestedDate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as RequestProtoObj);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(RequestProtoObj other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (RequestId != other.RequestId) return false;
      if (IsApproved != other.IsApproved) return false;
      if (Status != other.Status) return false;
      if (Amount != other.Amount) return false;
      if (Comment != other.Comment) return false;
      if (!object.Equals(RequestSender, other.RequestSender)) return false;
      if (!object.Equals(RequestReceiver, other.RequestReceiver)) return false;
      if (RequestedDate != other.RequestedDate) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (RequestId != 0L) hash ^= RequestId.GetHashCode();
      if (IsApproved != false) hash ^= IsApproved.GetHashCode();
      if (Status.Length != 0) hash ^= Status.GetHashCode();
      if (Amount != 0) hash ^= Amount.GetHashCode();
      if (Comment.Length != 0) hash ^= Comment.GetHashCode();
      if (requestSender_ != null) hash ^= RequestSender.GetHashCode();
      if (requestReceiver_ != null) hash ^= RequestReceiver.GetHashCode();
      if (RequestedDate.Length != 0) hash ^= RequestedDate.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (RequestId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(RequestId);
      }
      if (IsApproved != false) {
        output.WriteRawTag(16);
        output.WriteBool(IsApproved);
      }
      if (Status.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Status);
      }
      if (Amount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Amount);
      }
      if (Comment.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Comment);
      }
      if (requestSender_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(RequestSender);
      }
      if (requestReceiver_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(RequestReceiver);
      }
      if (RequestedDate.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(RequestedDate);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (RequestId != 0L) {
        output.WriteRawTag(8);
        output.WriteInt64(RequestId);
      }
      if (IsApproved != false) {
        output.WriteRawTag(16);
        output.WriteBool(IsApproved);
      }
      if (Status.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Status);
      }
      if (Amount != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Amount);
      }
      if (Comment.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(Comment);
      }
      if (requestSender_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(RequestSender);
      }
      if (requestReceiver_ != null) {
        output.WriteRawTag(58);
        output.WriteMessage(RequestReceiver);
      }
      if (RequestedDate.Length != 0) {
        output.WriteRawTag(66);
        output.WriteString(RequestedDate);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (RequestId != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(RequestId);
      }
      if (IsApproved != false) {
        size += 1 + 1;
      }
      if (Status.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Status);
      }
      if (Amount != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Amount);
      }
      if (Comment.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Comment);
      }
      if (requestSender_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RequestSender);
      }
      if (requestReceiver_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RequestReceiver);
      }
      if (RequestedDate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RequestedDate);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(RequestProtoObj other) {
      if (other == null) {
        return;
      }
      if (other.RequestId != 0L) {
        RequestId = other.RequestId;
      }
      if (other.IsApproved != false) {
        IsApproved = other.IsApproved;
      }
      if (other.Status.Length != 0) {
        Status = other.Status;
      }
      if (other.Amount != 0) {
        Amount = other.Amount;
      }
      if (other.Comment.Length != 0) {
        Comment = other.Comment;
      }
      if (other.requestSender_ != null) {
        if (requestSender_ == null) {
          RequestSender = new global::SEP3_DataTier.UserProtoObj();
        }
        RequestSender.MergeFrom(other.RequestSender);
      }
      if (other.requestReceiver_ != null) {
        if (requestReceiver_ == null) {
          RequestReceiver = new global::SEP3_DataTier.UserProtoObj();
        }
        RequestReceiver.MergeFrom(other.RequestReceiver);
      }
      if (other.RequestedDate.Length != 0) {
        RequestedDate = other.RequestedDate;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            RequestId = input.ReadInt64();
            break;
          }
          case 16: {
            IsApproved = input.ReadBool();
            break;
          }
          case 26: {
            Status = input.ReadString();
            break;
          }
          case 32: {
            Amount = input.ReadInt32();
            break;
          }
          case 42: {
            Comment = input.ReadString();
            break;
          }
          case 50: {
            if (requestSender_ == null) {
              RequestSender = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(RequestSender);
            break;
          }
          case 58: {
            if (requestReceiver_ == null) {
              RequestReceiver = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(RequestReceiver);
            break;
          }
          case 66: {
            RequestedDate = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            RequestId = input.ReadInt64();
            break;
          }
          case 16: {
            IsApproved = input.ReadBool();
            break;
          }
          case 26: {
            Status = input.ReadString();
            break;
          }
          case 32: {
            Amount = input.ReadInt32();
            break;
          }
          case 42: {
            Comment = input.ReadString();
            break;
          }
          case 50: {
            if (requestSender_ == null) {
              RequestSender = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(RequestSender);
            break;
          }
          case 58: {
            if (requestReceiver_ == null) {
              RequestReceiver = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(RequestReceiver);
            break;
          }
          case 66: {
            RequestedDate = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class RequestProtoObjList : pb::IMessage<RequestProtoObjList>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<RequestProtoObjList> _parser = new pb::MessageParser<RequestProtoObjList>(() => new RequestProtoObjList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<RequestProtoObjList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.RequestReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObjList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObjList(RequestProtoObjList other) : this() {
      requests_ = other.requests_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public RequestProtoObjList Clone() {
      return new RequestProtoObjList(this);
    }

    /// <summary>Field number for the "requests" field.</summary>
    public const int RequestsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SEP3_DataTier.RequestProtoObj> _repeated_requests_codec
        = pb::FieldCodec.ForMessage(10, global::SEP3_DataTier.RequestProtoObj.Parser);
    private readonly pbc::RepeatedField<global::SEP3_DataTier.RequestProtoObj> requests_ = new pbc::RepeatedField<global::SEP3_DataTier.RequestProtoObj>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::SEP3_DataTier.RequestProtoObj> Requests {
      get { return requests_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as RequestProtoObjList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(RequestProtoObjList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!requests_.Equals(other.requests_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= requests_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      requests_.WriteTo(output, _repeated_requests_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      requests_.WriteTo(ref output, _repeated_requests_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += requests_.CalculateSize(_repeated_requests_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(RequestProtoObjList other) {
      if (other == null) {
        return;
      }
      requests_.Add(other.requests_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            requests_.AddEntriesFrom(input, _repeated_requests_codec);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            requests_.AddEntriesFrom(ref input, _repeated_requests_codec);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
