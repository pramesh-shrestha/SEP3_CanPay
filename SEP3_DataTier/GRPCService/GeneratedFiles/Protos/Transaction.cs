// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/transaction.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SEP3_DataTier {

  /// <summary>Holder for reflection information generated from Protos/transaction.proto</summary>
  public static partial class TransactionReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/transaction.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TransactionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChhQcm90b3MvdHJhbnNhY3Rpb24ucHJvdG8aHmdvb2dsZS9wcm90b2J1Zi93",
            "cmFwcGVycy5wcm90bxoRUHJvdG9zL3VzZXIucHJvdG8aG2dvb2dsZS9wcm90",
            "b2J1Zi9lbXB0eS5wcm90byLrAQoTVHJhbnNhY3Rpb25Qcm90b09iahIzCg50",
            "cmFuc2FjdGlvbl9pZBgBIAEoCzIbLmdvb2dsZS5wcm90b2J1Zi5JbnQ2NFZh",
            "bHVlEiEKCnNlbmRlclVzZXIYAiABKAsyDS5Vc2VyUHJvdG9PYmoSIwoMcmVj",
            "ZWl2ZXJVc2VyGAMgASgLMg0uVXNlclByb3RvT2JqEisKBmFtb3VudBgEIAEo",
            "CzIbLmdvb2dsZS5wcm90b2J1Zi5JbnQzMlZhbHVlEioKBGRhdGUYBSABKAsy",
            "HC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWUieQobRmlsdGVyQnlVc2Vy",
            "QW5kRGF0ZVByb3RvT2JqEi4KCHVzZXJuYW1lGAEgASgLMhwuZ29vZ2xlLnBy",
            "b3RvYnVmLlN0cmluZ1ZhbHVlEioKBGRhdGUYAiABKAsyHC5nb29nbGUucHJv",
            "dG9idWYuU3RyaW5nVmFsdWUiSAoXVHJhbnNhY3Rpb25Qcm90b09iakxpc3QS",
            "LQoPYWxsVHJhbnNhY3Rpb25zGAEgAygLMhQuVHJhbnNhY3Rpb25Qcm90b09i",
            "ajLXBQoXVHJhbnNhY3Rpb25Qcm90b1NlcnZpY2USRAoWQ3JlYXRlVHJhbnNh",
            "Y3Rpb25Bc3luYxIULlRyYW5zYWN0aW9uUHJvdG9PYmoaFC5UcmFuc2FjdGlv",
            "blByb3RvT2JqEk4KGUZldGNoVHJhbnNhY3Rpb25CeUlkQXN5bmMSGy5nb29n",
            "bGUucHJvdG9idWYuSW50NjRWYWx1ZRoULlRyYW5zYWN0aW9uUHJvdG9PYmoS",
            "WwohRmV0Y2hBbExUcmFuc2FjdGlvbnNCeVNlbmRlckFzeW5jEhwuZ29vZ2xl",
            "LnByb3RvYnVmLlN0cmluZ1ZhbHVlGhguVHJhbnNhY3Rpb25Qcm90b09iakxp",
            "c3QSXQojRmV0Y2hBbGxUcmFuc2FjdGlvbnNCeVJlY2VpdmVyQXN5bmMSHC5n",
            "b29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWUaGC5UcmFuc2FjdGlvblByb3Rv",
            "T2JqTGlzdBJgCiZGZXRjaEFsTFRyYW5zYWN0aW9uc0ludm9sdmluZ1VzZXJB",
            "c3luYxIcLmdvb2dsZS5wcm90b2J1Zi5TdHJpbmdWYWx1ZRoYLlRyYW5zYWN0",
            "aW9uUHJvdG9PYmpMaXN0ElYKHEZldGNoVHJhbnNhY3Rpb25zQnlEYXRlQXN5",
            "bmMSHC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWUaGC5UcmFuc2FjdGlv",
            "blByb3RvT2JqTGlzdBJdCiNGZXRjaFRyYW5zYWN0aW9uc0J5UmVjaXBpZW50",
            "QW5kRGF0ZRIcLkZpbHRlckJ5VXNlckFuZERhdGVQcm90b09iahoYLlRyYW5z",
            "YWN0aW9uUHJvdG9PYmpMaXN0ElEKFkRlbGV0ZVRyYW5zYWN0aW9uQXN5bmMS",
            "Gy5nb29nbGUucHJvdG9idWYuSW50NjRWYWx1ZRoaLmdvb2dsZS5wcm90b2J1",
            "Zi5Cb29sVmFsdWVCEKoCDVNFUDNfRGF0YVRpZXJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::SEP3_DataTier.UserReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.TransactionProtoObj), global::SEP3_DataTier.TransactionProtoObj.Parser, new[]{ "TransactionId", "SenderUser", "ReceiverUser", "Amount", "Date" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.FilterByUserAndDateProtoObj), global::SEP3_DataTier.FilterByUserAndDateProtoObj.Parser, new[]{ "Username", "Date" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.TransactionProtoObjList), global::SEP3_DataTier.TransactionProtoObjList.Parser, new[]{ "AllTransactions" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class TransactionProtoObj : pb::IMessage<TransactionProtoObj>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TransactionProtoObj> _parser = new pb::MessageParser<TransactionProtoObj>(() => new TransactionProtoObj());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TransactionProtoObj> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.TransactionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObj() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObj(TransactionProtoObj other) : this() {
      TransactionId = other.TransactionId;
      senderUser_ = other.senderUser_ != null ? other.senderUser_.Clone() : null;
      receiverUser_ = other.receiverUser_ != null ? other.receiverUser_.Clone() : null;
      Amount = other.Amount;
      Date = other.Date;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObj Clone() {
      return new TransactionProtoObj(this);
    }

    /// <summary>Field number for the "transaction_id" field.</summary>
    public const int TransactionIdFieldNumber = 1;
    private static readonly pb::FieldCodec<long?> _single_transactionId_codec = pb::FieldCodec.ForStructWrapper<long>(10);
    private long? transactionId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long? TransactionId {
      get { return transactionId_; }
      set {
        transactionId_ = value;
      }
    }


    /// <summary>Field number for the "senderUser" field.</summary>
    public const int SenderUserFieldNumber = 2;
    private global::SEP3_DataTier.UserProtoObj senderUser_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::SEP3_DataTier.UserProtoObj SenderUser {
      get { return senderUser_; }
      set {
        senderUser_ = value;
      }
    }

    /// <summary>Field number for the "receiverUser" field.</summary>
    public const int ReceiverUserFieldNumber = 3;
    private global::SEP3_DataTier.UserProtoObj receiverUser_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::SEP3_DataTier.UserProtoObj ReceiverUser {
      get { return receiverUser_; }
      set {
        receiverUser_ = value;
      }
    }

    /// <summary>Field number for the "amount" field.</summary>
    public const int AmountFieldNumber = 4;
    private static readonly pb::FieldCodec<int?> _single_amount_codec = pb::FieldCodec.ForStructWrapper<int>(34);
    private int? amount_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int? Amount {
      get { return amount_; }
      set {
        amount_ = value;
      }
    }


    /// <summary>Field number for the "date" field.</summary>
    public const int DateFieldNumber = 5;
    private static readonly pb::FieldCodec<string> _single_date_codec = pb::FieldCodec.ForClassWrapper<string>(42);
    private string date_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Date {
      get { return date_; }
      set {
        date_ = value;
      }
    }


    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TransactionProtoObj);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TransactionProtoObj other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (TransactionId != other.TransactionId) return false;
      if (!object.Equals(SenderUser, other.SenderUser)) return false;
      if (!object.Equals(ReceiverUser, other.ReceiverUser)) return false;
      if (Amount != other.Amount) return false;
      if (Date != other.Date) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (transactionId_ != null) hash ^= TransactionId.GetHashCode();
      if (senderUser_ != null) hash ^= SenderUser.GetHashCode();
      if (receiverUser_ != null) hash ^= ReceiverUser.GetHashCode();
      if (amount_ != null) hash ^= Amount.GetHashCode();
      if (date_ != null) hash ^= Date.GetHashCode();
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
      if (transactionId_ != null) {
        _single_transactionId_codec.WriteTagAndValue(output, TransactionId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (receiverUser_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ReceiverUser);
      }
      if (amount_ != null) {
        _single_amount_codec.WriteTagAndValue(output, Amount);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(output, Date);
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
      if (transactionId_ != null) {
        _single_transactionId_codec.WriteTagAndValue(ref output, TransactionId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (receiverUser_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ReceiverUser);
      }
      if (amount_ != null) {
        _single_amount_codec.WriteTagAndValue(ref output, Amount);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(ref output, Date);
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
      if (transactionId_ != null) {
        size += _single_transactionId_codec.CalculateSizeWithTag(TransactionId);
      }
      if (senderUser_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SenderUser);
      }
      if (receiverUser_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReceiverUser);
      }
      if (amount_ != null) {
        size += _single_amount_codec.CalculateSizeWithTag(Amount);
      }
      if (date_ != null) {
        size += _single_date_codec.CalculateSizeWithTag(Date);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TransactionProtoObj other) {
      if (other == null) {
        return;
      }
      if (other.transactionId_ != null) {
        if (transactionId_ == null || other.TransactionId != 0L) {
          TransactionId = other.TransactionId;
        }
      }
      if (other.senderUser_ != null) {
        if (senderUser_ == null) {
          SenderUser = new global::SEP3_DataTier.UserProtoObj();
        }
        SenderUser.MergeFrom(other.SenderUser);
      }
      if (other.receiverUser_ != null) {
        if (receiverUser_ == null) {
          ReceiverUser = new global::SEP3_DataTier.UserProtoObj();
        }
        ReceiverUser.MergeFrom(other.ReceiverUser);
      }
      if (other.amount_ != null) {
        if (amount_ == null || other.Amount != 0) {
          Amount = other.Amount;
        }
      }
      if (other.date_ != null) {
        if (date_ == null || other.Date != "") {
          Date = other.Date;
        }
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
          case 10: {
            long? value = _single_transactionId_codec.Read(input);
            if (transactionId_ == null || value != 0L) {
              TransactionId = value;
            }
            break;
          }
          case 18: {
            if (senderUser_ == null) {
              SenderUser = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(SenderUser);
            break;
          }
          case 26: {
            if (receiverUser_ == null) {
              ReceiverUser = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(ReceiverUser);
            break;
          }
          case 34: {
            int? value = _single_amount_codec.Read(input);
            if (amount_ == null || value != 0) {
              Amount = value;
            }
            break;
          }
          case 42: {
            string value = _single_date_codec.Read(input);
            if (date_ == null || value != "") {
              Date = value;
            }
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
            long? value = _single_transactionId_codec.Read(ref input);
            if (transactionId_ == null || value != 0L) {
              TransactionId = value;
            }
            break;
          }
          case 18: {
            if (senderUser_ == null) {
              SenderUser = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(SenderUser);
            break;
          }
          case 26: {
            if (receiverUser_ == null) {
              ReceiverUser = new global::SEP3_DataTier.UserProtoObj();
            }
            input.ReadMessage(ReceiverUser);
            break;
          }
          case 34: {
            int? value = _single_amount_codec.Read(ref input);
            if (amount_ == null || value != 0) {
              Amount = value;
            }
            break;
          }
          case 42: {
            string value = _single_date_codec.Read(ref input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class FilterByUserAndDateProtoObj : pb::IMessage<FilterByUserAndDateProtoObj>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<FilterByUserAndDateProtoObj> _parser = new pb::MessageParser<FilterByUserAndDateProtoObj>(() => new FilterByUserAndDateProtoObj());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<FilterByUserAndDateProtoObj> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.TransactionReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FilterByUserAndDateProtoObj() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FilterByUserAndDateProtoObj(FilterByUserAndDateProtoObj other) : this() {
      Username = other.Username;
      Date = other.Date;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public FilterByUserAndDateProtoObj Clone() {
      return new FilterByUserAndDateProtoObj(this);
    }

    /// <summary>Field number for the "username" field.</summary>
    public const int UsernameFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _single_username_codec = pb::FieldCodec.ForClassWrapper<string>(10);
    private string username_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Username {
      get { return username_; }
      set {
        username_ = value;
      }
    }


    /// <summary>Field number for the "date" field.</summary>
    public const int DateFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _single_date_codec = pb::FieldCodec.ForClassWrapper<string>(18);
    private string date_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Date {
      get { return date_; }
      set {
        date_ = value;
      }
    }


    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as FilterByUserAndDateProtoObj);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(FilterByUserAndDateProtoObj other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Username != other.Username) return false;
      if (Date != other.Date) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (username_ != null) hash ^= Username.GetHashCode();
      if (date_ != null) hash ^= Date.GetHashCode();
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
      if (username_ != null) {
        _single_username_codec.WriteTagAndValue(output, Username);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(output, Date);
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
      if (username_ != null) {
        _single_username_codec.WriteTagAndValue(ref output, Username);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(ref output, Date);
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
      if (username_ != null) {
        size += _single_username_codec.CalculateSizeWithTag(Username);
      }
      if (date_ != null) {
        size += _single_date_codec.CalculateSizeWithTag(Date);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(FilterByUserAndDateProtoObj other) {
      if (other == null) {
        return;
      }
      if (other.username_ != null) {
        if (username_ == null || other.Username != "") {
          Username = other.Username;
        }
      }
      if (other.date_ != null) {
        if (date_ == null || other.Date != "") {
          Date = other.Date;
        }
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
          case 10: {
            string value = _single_username_codec.Read(input);
            if (username_ == null || value != "") {
              Username = value;
            }
            break;
          }
          case 18: {
            string value = _single_date_codec.Read(input);
            if (date_ == null || value != "") {
              Date = value;
            }
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
            string value = _single_username_codec.Read(ref input);
            if (username_ == null || value != "") {
              Username = value;
            }
            break;
          }
          case 18: {
            string value = _single_date_codec.Read(ref input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class TransactionProtoObjList : pb::IMessage<TransactionProtoObjList>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<TransactionProtoObjList> _parser = new pb::MessageParser<TransactionProtoObjList>(() => new TransactionProtoObjList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<TransactionProtoObjList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.TransactionReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObjList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObjList(TransactionProtoObjList other) : this() {
      allTransactions_ = other.allTransactions_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public TransactionProtoObjList Clone() {
      return new TransactionProtoObjList(this);
    }

    /// <summary>Field number for the "allTransactions" field.</summary>
    public const int AllTransactionsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SEP3_DataTier.TransactionProtoObj> _repeated_allTransactions_codec
        = pb::FieldCodec.ForMessage(10, global::SEP3_DataTier.TransactionProtoObj.Parser);
    private readonly pbc::RepeatedField<global::SEP3_DataTier.TransactionProtoObj> allTransactions_ = new pbc::RepeatedField<global::SEP3_DataTier.TransactionProtoObj>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::SEP3_DataTier.TransactionProtoObj> AllTransactions {
      get { return allTransactions_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as TransactionProtoObjList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(TransactionProtoObjList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!allTransactions_.Equals(other.allTransactions_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= allTransactions_.GetHashCode();
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
      allTransactions_.WriteTo(output, _repeated_allTransactions_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      allTransactions_.WriteTo(ref output, _repeated_allTransactions_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += allTransactions_.CalculateSize(_repeated_allTransactions_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(TransactionProtoObjList other) {
      if (other == null) {
        return;
      }
      allTransactions_.Add(other.allTransactions_);
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
            allTransactions_.AddEntriesFrom(input, _repeated_allTransactions_codec);
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
            allTransactions_.AddEntriesFrom(ref input, _repeated_allTransactions_codec);
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
