// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/notification.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SEP3_DataTier {

  /// <summary>Holder for reflection information generated from Protos/notification.proto</summary>
  public static partial class NotificationReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/notification.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static NotificationReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlQcm90b3Mvbm90aWZpY2F0aW9uLnByb3RvGh5nb29nbGUvcHJvdG9idWYv",
            "d3JhcHBlcnMucHJvdG8aEVByb3Rvcy91c2VyLnByb3RvGhtnb29nbGUvcHJv",
            "dG9idWYvZW1wdHkucHJvdG8ixwIKFE5vdGlmaWNhdGlvblByb3RvT2JqEjQK",
            "D25vdGlmaWNhdGlvbl9pZBgBIAEoCzIbLmdvb2dsZS5wcm90b2J1Zi5JbnQ2",
            "NFZhbHVlEiEKCnNlbmRlclVzZXIYAiABKAsyDS5Vc2VyUHJvdG9PYmoSIwoM",
            "cmVjZWl2ZXJVc2VyGAMgASgLMg0uVXNlclByb3RvT2JqEioKBGRhdGUYBCAB",
            "KAsyHC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWUSLQoHbWVzc2FnZRgF",
            "IAEoCzIcLmdvb2dsZS5wcm90b2J1Zi5TdHJpbmdWYWx1ZRIqCgR0eXBlGAYg",
            "ASgLMhwuZ29vZ2xlLnByb3RvYnVmLlN0cmluZ1ZhbHVlEioKBmlzUmVhZBgH",
            "IAEoCzIaLmdvb2dsZS5wcm90b2J1Zi5Cb29sVmFsdWUiSwoYTm90aWZpY2F0",
            "aW9uUHJvdG9PYmpMaXN0Ei8KEGFsbE5vdGlmaWNhdGlvbnMYASADKAsyFS5O",
            "b3RpZmljYXRpb25Qcm90b09iajKZAwoYTm90aWZpY2F0aW9uUHJvdG9TZXJ2",
            "aWNlEkcKF0NyZWF0ZU5vdGlmaWNhdGlvbkFzeW5jEhUuTm90aWZpY2F0aW9u",
            "UHJvdG9PYmoaFS5Ob3RpZmljYXRpb25Qcm90b09iahJfCiRGZXRjaEFsbE5v",
            "dGlmaWNhdGlvbnNCeVJlY2VpdmVyQXN5bmMSHC5nb29nbGUucHJvdG9idWYu",
            "U3RyaW5nVmFsdWUaGS5Ob3RpZmljYXRpb25Qcm90b09iakxpc3QSOwoKTWFy",
            "a0FzUmVhZBIVLk5vdGlmaWNhdGlvblByb3RvT2JqGhYuZ29vZ2xlLnByb3Rv",
            "YnVmLkVtcHR5EkIKDU1hcmtBbGxBc1JlYWQSGS5Ob3RpZmljYXRpb25Qcm90",
            "b09iakxpc3QaFi5nb29nbGUucHJvdG9idWYuRW1wdHkSUgoXRGVsZXRlTm90",
            "aWZpY2F0aW9uQXN5bmMSGy5nb29nbGUucHJvdG9idWYuSW50NjRWYWx1ZRoa",
            "Lmdvb2dsZS5wcm90b2J1Zi5Cb29sVmFsdWVCEKoCDVNFUDNfRGF0YVRpZXJi",
            "BnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::SEP3_DataTier.UserReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.NotificationProtoObj), global::SEP3_DataTier.NotificationProtoObj.Parser, new[]{ "NotificationId", "SenderUser", "ReceiverUser", "Date", "Message", "Type", "IsRead" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.NotificationProtoObjList), global::SEP3_DataTier.NotificationProtoObjList.Parser, new[]{ "AllNotifications" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NotificationProtoObj : pb::IMessage<NotificationProtoObj>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<NotificationProtoObj> _parser = new pb::MessageParser<NotificationProtoObj>(() => new NotificationProtoObj());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NotificationProtoObj> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.NotificationReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObj() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObj(NotificationProtoObj other) : this() {
      NotificationId = other.NotificationId;
      senderUser_ = other.senderUser_ != null ? other.senderUser_.Clone() : null;
      receiverUser_ = other.receiverUser_ != null ? other.receiverUser_.Clone() : null;
      Date = other.Date;
      Message = other.Message;
      Type = other.Type;
      IsRead = other.IsRead;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObj Clone() {
      return new NotificationProtoObj(this);
    }

    /// <summary>Field number for the "notification_id" field.</summary>
    public const int NotificationIdFieldNumber = 1;
    private static readonly pb::FieldCodec<long?> _single_notificationId_codec = pb::FieldCodec.ForStructWrapper<long>(10);
    private long? notificationId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long? NotificationId {
      get { return notificationId_; }
      set {
        notificationId_ = value;
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

    /// <summary>Field number for the "date" field.</summary>
    public const int DateFieldNumber = 4;
    private static readonly pb::FieldCodec<string> _single_date_codec = pb::FieldCodec.ForClassWrapper<string>(34);
    private string date_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Date {
      get { return date_; }
      set {
        date_ = value;
      }
    }


    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 5;
    private static readonly pb::FieldCodec<string> _single_message_codec = pb::FieldCodec.ForClassWrapper<string>(42);
    private string message_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Message {
      get { return message_; }
      set {
        message_ = value;
      }
    }


    /// <summary>Field number for the "type" field.</summary>
    public const int TypeFieldNumber = 6;
    private static readonly pb::FieldCodec<string> _single_type_codec = pb::FieldCodec.ForClassWrapper<string>(50);
    private string type_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Type {
      get { return type_; }
      set {
        type_ = value;
      }
    }


    /// <summary>Field number for the "isRead" field.</summary>
    public const int IsReadFieldNumber = 7;
    private static readonly pb::FieldCodec<bool?> _single_isRead_codec = pb::FieldCodec.ForStructWrapper<bool>(58);
    private bool? isRead_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool? IsRead {
      get { return isRead_; }
      set {
        isRead_ = value;
      }
    }


    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as NotificationProtoObj);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NotificationProtoObj other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NotificationId != other.NotificationId) return false;
      if (!object.Equals(SenderUser, other.SenderUser)) return false;
      if (!object.Equals(ReceiverUser, other.ReceiverUser)) return false;
      if (Date != other.Date) return false;
      if (Message != other.Message) return false;
      if (Type != other.Type) return false;
      if (IsRead != other.IsRead) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (notificationId_ != null) hash ^= NotificationId.GetHashCode();
      if (senderUser_ != null) hash ^= SenderUser.GetHashCode();
      if (receiverUser_ != null) hash ^= ReceiverUser.GetHashCode();
      if (date_ != null) hash ^= Date.GetHashCode();
      if (message_ != null) hash ^= Message.GetHashCode();
      if (type_ != null) hash ^= Type.GetHashCode();
      if (isRead_ != null) hash ^= IsRead.GetHashCode();
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
      if (notificationId_ != null) {
        _single_notificationId_codec.WriteTagAndValue(output, NotificationId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (receiverUser_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ReceiverUser);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(output, Date);
      }
      if (message_ != null) {
        _single_message_codec.WriteTagAndValue(output, Message);
      }
      if (type_ != null) {
        _single_type_codec.WriteTagAndValue(output, Type);
      }
      if (isRead_ != null) {
        _single_isRead_codec.WriteTagAndValue(output, IsRead);
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
      if (notificationId_ != null) {
        _single_notificationId_codec.WriteTagAndValue(ref output, NotificationId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (receiverUser_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(ReceiverUser);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(ref output, Date);
      }
      if (message_ != null) {
        _single_message_codec.WriteTagAndValue(ref output, Message);
      }
      if (type_ != null) {
        _single_type_codec.WriteTagAndValue(ref output, Type);
      }
      if (isRead_ != null) {
        _single_isRead_codec.WriteTagAndValue(ref output, IsRead);
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
      if (notificationId_ != null) {
        size += _single_notificationId_codec.CalculateSizeWithTag(NotificationId);
      }
      if (senderUser_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SenderUser);
      }
      if (receiverUser_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ReceiverUser);
      }
      if (date_ != null) {
        size += _single_date_codec.CalculateSizeWithTag(Date);
      }
      if (message_ != null) {
        size += _single_message_codec.CalculateSizeWithTag(Message);
      }
      if (type_ != null) {
        size += _single_type_codec.CalculateSizeWithTag(Type);
      }
      if (isRead_ != null) {
        size += _single_isRead_codec.CalculateSizeWithTag(IsRead);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NotificationProtoObj other) {
      if (other == null) {
        return;
      }
      if (other.notificationId_ != null) {
        if (notificationId_ == null || other.NotificationId != 0L) {
          NotificationId = other.NotificationId;
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
      if (other.date_ != null) {
        if (date_ == null || other.Date != "") {
          Date = other.Date;
        }
      }
      if (other.message_ != null) {
        if (message_ == null || other.Message != "") {
          Message = other.Message;
        }
      }
      if (other.type_ != null) {
        if (type_ == null || other.Type != "") {
          Type = other.Type;
        }
      }
      if (other.isRead_ != null) {
        if (isRead_ == null || other.IsRead != false) {
          IsRead = other.IsRead;
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
            long? value = _single_notificationId_codec.Read(input);
            if (notificationId_ == null || value != 0L) {
              NotificationId = value;
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
            string value = _single_date_codec.Read(input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
          case 42: {
            string value = _single_message_codec.Read(input);
            if (message_ == null || value != "") {
              Message = value;
            }
            break;
          }
          case 50: {
            string value = _single_type_codec.Read(input);
            if (type_ == null || value != "") {
              Type = value;
            }
            break;
          }
          case 58: {
            bool? value = _single_isRead_codec.Read(input);
            if (isRead_ == null || value != false) {
              IsRead = value;
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
            long? value = _single_notificationId_codec.Read(ref input);
            if (notificationId_ == null || value != 0L) {
              NotificationId = value;
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
            string value = _single_date_codec.Read(ref input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
          case 42: {
            string value = _single_message_codec.Read(ref input);
            if (message_ == null || value != "") {
              Message = value;
            }
            break;
          }
          case 50: {
            string value = _single_type_codec.Read(ref input);
            if (type_ == null || value != "") {
              Type = value;
            }
            break;
          }
          case 58: {
            bool? value = _single_isRead_codec.Read(ref input);
            if (isRead_ == null || value != false) {
              IsRead = value;
            }
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class NotificationProtoObjList : pb::IMessage<NotificationProtoObjList>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<NotificationProtoObjList> _parser = new pb::MessageParser<NotificationProtoObjList>(() => new NotificationProtoObjList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<NotificationProtoObjList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.NotificationReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObjList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObjList(NotificationProtoObjList other) : this() {
      allNotifications_ = other.allNotifications_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public NotificationProtoObjList Clone() {
      return new NotificationProtoObjList(this);
    }

    /// <summary>Field number for the "allNotifications" field.</summary>
    public const int AllNotificationsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SEP3_DataTier.NotificationProtoObj> _repeated_allNotifications_codec
        = pb::FieldCodec.ForMessage(10, global::SEP3_DataTier.NotificationProtoObj.Parser);
    private readonly pbc::RepeatedField<global::SEP3_DataTier.NotificationProtoObj> allNotifications_ = new pbc::RepeatedField<global::SEP3_DataTier.NotificationProtoObj>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::SEP3_DataTier.NotificationProtoObj> AllNotifications {
      get { return allNotifications_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as NotificationProtoObjList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(NotificationProtoObjList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!allNotifications_.Equals(other.allNotifications_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= allNotifications_.GetHashCode();
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
      allNotifications_.WriteTo(output, _repeated_allNotifications_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      allNotifications_.WriteTo(ref output, _repeated_allNotifications_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += allNotifications_.CalculateSize(_repeated_allNotifications_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(NotificationProtoObjList other) {
      if (other == null) {
        return;
      }
      allNotifications_.Add(other.allNotifications_);
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
            allNotifications_.AddEntriesFrom(input, _repeated_allNotifications_codec);
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
            allNotifications_.AddEntriesFrom(ref input, _repeated_allNotifications_codec);
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