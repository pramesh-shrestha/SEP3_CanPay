// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/bill_transaction.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SEP3_DataTier {

  /// <summary>Holder for reflection information generated from Protos/bill_transaction.proto</summary>
  public static partial class BillTransactionReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/bill_transaction.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BillTransactionReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch1Qcm90b3MvYmlsbF90cmFuc2FjdGlvbi5wcm90bxoeZ29vZ2xlL3Byb3Rv",
            "YnVmL3dyYXBwZXJzLnByb3RvGhFQcm90b3MvdXNlci5wcm90bxobZ29vZ2xl",
            "L3Byb3RvYnVmL2VtcHR5LnByb3RvItwCChNCaWxsUGF5bWVudFByb3RvT2Jq",
            "EjMKDkJpbGxQYXltZW50X2lkGAEgASgLMhsuZ29vZ2xlLnByb3RvYnVmLklu",
            "dDY0VmFsdWUSIQoKc2VuZGVyVXNlchgCIAEoCzINLlVzZXJQcm90b09iahIv",
            "CglwYXllZU5hbWUYAyABKAsyHC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFs",
            "dWUSKwoGYW1vdW50GAQgASgLMhsuZ29vZ2xlLnByb3RvYnVmLkludDMyVmFs",
            "dWUSMgoNYWNjb3VudE51bWJlchgFIAEoCzIbLmdvb2dsZS5wcm90b2J1Zi5J",
            "bnQ2NFZhbHVlEioKBGRhdGUYBiABKAsyHC5nb29nbGUucHJvdG9idWYuU3Ry",
            "aW5nVmFsdWUSLwoJcmVmZXJlbmNlGAcgASgLMhwuZ29vZ2xlLnByb3RvYnVm",
            "LlN0cmluZ1ZhbHVlIkgKF0JpbGxQYXltZW50UHJvdG9PYmpMaXN0Ei0KD2Fs",
            "bEJpbGxQYXltZW50cxgBIAMoCzIULkJpbGxQYXltZW50UHJvdG9PYmoy+AQK",
            "F0JpbGxQYXltZW50UHJvdG9TZXJ2aWNlEkQKFkNyZWF0ZUJpbGxQYXltZW50",
            "QXN5bmMSFC5CaWxsUGF5bWVudFByb3RvT2JqGhQuQmlsbFBheW1lbnRQcm90",
            "b09iahJOChlGZXRjaEJpbGxQYXltZW50QnlJZEFzeW5jEhsuZ29vZ2xlLnBy",
            "b3RvYnVmLkludDY0VmFsdWUaFC5CaWxsUGF5bWVudFByb3RvT2JqElsKIUZl",
            "dGNoQWxMQmlsbFBheW1lbnRzQnlTZW5kZXJBc3luYxIcLmdvb2dsZS5wcm90",
            "b2J1Zi5TdHJpbmdWYWx1ZRoYLkJpbGxQYXltZW50UHJvdG9PYmpMaXN0El0K",
            "I0ZldGNoQWxsQmlsbFBheW1lbnRzQnlSZWNlaXZlckFzeW5jEhwuZ29vZ2xl",
            "LnByb3RvYnVmLlN0cmluZ1ZhbHVlGhguQmlsbFBheW1lbnRQcm90b09iakxp",
            "c3QSYAomRmV0Y2hBbExCaWxsUGF5bWVudHNJbnZvbHZpbmdVc2VyQXN5bmMS",
            "HC5nb29nbGUucHJvdG9idWYuU3RyaW5nVmFsdWUaGC5CaWxsUGF5bWVudFBy",
            "b3RvT2JqTGlzdBJWChxGZXRjaEJpbGxQYXltZW50c0J5RGF0ZUFzeW5jEhwu",
            "Z29vZ2xlLnByb3RvYnVmLlN0cmluZ1ZhbHVlGhguQmlsbFBheW1lbnRQcm90",
            "b09iakxpc3QSUQoWRGVsZXRlQmlsbFBheW1lbnRBc3luYxIbLmdvb2dsZS5w",
            "cm90b2J1Zi5JbnQ2NFZhbHVlGhouZ29vZ2xlLnByb3RvYnVmLkJvb2xWYWx1",
            "ZUIQqgINU0VQM19EYXRhVGllcmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, global::SEP3_DataTier.UserReflection.Descriptor, global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.BillPaymentProtoObj), global::SEP3_DataTier.BillPaymentProtoObj.Parser, new[]{ "BillPaymentId", "SenderUser", "PayeeName", "Amount", "AccountNumber", "Date", "Reference" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SEP3_DataTier.BillPaymentProtoObjList), global::SEP3_DataTier.BillPaymentProtoObjList.Parser, new[]{ "AllBillPayments" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class BillPaymentProtoObj : pb::IMessage<BillPaymentProtoObj>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<BillPaymentProtoObj> _parser = new pb::MessageParser<BillPaymentProtoObj>(() => new BillPaymentProtoObj());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<BillPaymentProtoObj> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.BillTransactionReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObj() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObj(BillPaymentProtoObj other) : this() {
      BillPaymentId = other.BillPaymentId;
      senderUser_ = other.senderUser_ != null ? other.senderUser_.Clone() : null;
      PayeeName = other.PayeeName;
      Amount = other.Amount;
      AccountNumber = other.AccountNumber;
      Date = other.Date;
      Reference = other.Reference;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObj Clone() {
      return new BillPaymentProtoObj(this);
    }

    /// <summary>Field number for the "BillPayment_id" field.</summary>
    public const int BillPaymentIdFieldNumber = 1;
    private static readonly pb::FieldCodec<long?> _single_billPaymentId_codec = pb::FieldCodec.ForStructWrapper<long>(10);
    private long? billPaymentId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long? BillPaymentId {
      get { return billPaymentId_; }
      set {
        billPaymentId_ = value;
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

    /// <summary>Field number for the "payeeName" field.</summary>
    public const int PayeeNameFieldNumber = 3;
    private static readonly pb::FieldCodec<string> _single_payeeName_codec = pb::FieldCodec.ForClassWrapper<string>(26);
    private string payeeName_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string PayeeName {
      get { return payeeName_; }
      set {
        payeeName_ = value;
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


    /// <summary>Field number for the "accountNumber" field.</summary>
    public const int AccountNumberFieldNumber = 5;
    private static readonly pb::FieldCodec<long?> _single_accountNumber_codec = pb::FieldCodec.ForStructWrapper<long>(42);
    private long? accountNumber_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public long? AccountNumber {
      get { return accountNumber_; }
      set {
        accountNumber_ = value;
      }
    }


    /// <summary>Field number for the "date" field.</summary>
    public const int DateFieldNumber = 6;
    private static readonly pb::FieldCodec<string> _single_date_codec = pb::FieldCodec.ForClassWrapper<string>(50);
    private string date_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Date {
      get { return date_; }
      set {
        date_ = value;
      }
    }


    /// <summary>Field number for the "reference" field.</summary>
    public const int ReferenceFieldNumber = 7;
    private static readonly pb::FieldCodec<string> _single_reference_codec = pb::FieldCodec.ForClassWrapper<string>(58);
    private string reference_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string Reference {
      get { return reference_; }
      set {
        reference_ = value;
      }
    }


    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as BillPaymentProtoObj);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(BillPaymentProtoObj other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (BillPaymentId != other.BillPaymentId) return false;
      if (!object.Equals(SenderUser, other.SenderUser)) return false;
      if (PayeeName != other.PayeeName) return false;
      if (Amount != other.Amount) return false;
      if (AccountNumber != other.AccountNumber) return false;
      if (Date != other.Date) return false;
      if (Reference != other.Reference) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (billPaymentId_ != null) hash ^= BillPaymentId.GetHashCode();
      if (senderUser_ != null) hash ^= SenderUser.GetHashCode();
      if (payeeName_ != null) hash ^= PayeeName.GetHashCode();
      if (amount_ != null) hash ^= Amount.GetHashCode();
      if (accountNumber_ != null) hash ^= AccountNumber.GetHashCode();
      if (date_ != null) hash ^= Date.GetHashCode();
      if (reference_ != null) hash ^= Reference.GetHashCode();
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
      if (billPaymentId_ != null) {
        _single_billPaymentId_codec.WriteTagAndValue(output, BillPaymentId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (payeeName_ != null) {
        _single_payeeName_codec.WriteTagAndValue(output, PayeeName);
      }
      if (amount_ != null) {
        _single_amount_codec.WriteTagAndValue(output, Amount);
      }
      if (accountNumber_ != null) {
        _single_accountNumber_codec.WriteTagAndValue(output, AccountNumber);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(output, Date);
      }
      if (reference_ != null) {
        _single_reference_codec.WriteTagAndValue(output, Reference);
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
      if (billPaymentId_ != null) {
        _single_billPaymentId_codec.WriteTagAndValue(ref output, BillPaymentId);
      }
      if (senderUser_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(SenderUser);
      }
      if (payeeName_ != null) {
        _single_payeeName_codec.WriteTagAndValue(ref output, PayeeName);
      }
      if (amount_ != null) {
        _single_amount_codec.WriteTagAndValue(ref output, Amount);
      }
      if (accountNumber_ != null) {
        _single_accountNumber_codec.WriteTagAndValue(ref output, AccountNumber);
      }
      if (date_ != null) {
        _single_date_codec.WriteTagAndValue(ref output, Date);
      }
      if (reference_ != null) {
        _single_reference_codec.WriteTagAndValue(ref output, Reference);
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
      if (billPaymentId_ != null) {
        size += _single_billPaymentId_codec.CalculateSizeWithTag(BillPaymentId);
      }
      if (senderUser_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(SenderUser);
      }
      if (payeeName_ != null) {
        size += _single_payeeName_codec.CalculateSizeWithTag(PayeeName);
      }
      if (amount_ != null) {
        size += _single_amount_codec.CalculateSizeWithTag(Amount);
      }
      if (accountNumber_ != null) {
        size += _single_accountNumber_codec.CalculateSizeWithTag(AccountNumber);
      }
      if (date_ != null) {
        size += _single_date_codec.CalculateSizeWithTag(Date);
      }
      if (reference_ != null) {
        size += _single_reference_codec.CalculateSizeWithTag(Reference);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(BillPaymentProtoObj other) {
      if (other == null) {
        return;
      }
      if (other.billPaymentId_ != null) {
        if (billPaymentId_ == null || other.BillPaymentId != 0L) {
          BillPaymentId = other.BillPaymentId;
        }
      }
      if (other.senderUser_ != null) {
        if (senderUser_ == null) {
          SenderUser = new global::SEP3_DataTier.UserProtoObj();
        }
        SenderUser.MergeFrom(other.SenderUser);
      }
      if (other.payeeName_ != null) {
        if (payeeName_ == null || other.PayeeName != "") {
          PayeeName = other.PayeeName;
        }
      }
      if (other.amount_ != null) {
        if (amount_ == null || other.Amount != 0) {
          Amount = other.Amount;
        }
      }
      if (other.accountNumber_ != null) {
        if (accountNumber_ == null || other.AccountNumber != 0L) {
          AccountNumber = other.AccountNumber;
        }
      }
      if (other.date_ != null) {
        if (date_ == null || other.Date != "") {
          Date = other.Date;
        }
      }
      if (other.reference_ != null) {
        if (reference_ == null || other.Reference != "") {
          Reference = other.Reference;
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
            long? value = _single_billPaymentId_codec.Read(input);
            if (billPaymentId_ == null || value != 0L) {
              BillPaymentId = value;
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
            string value = _single_payeeName_codec.Read(input);
            if (payeeName_ == null || value != "") {
              PayeeName = value;
            }
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
            long? value = _single_accountNumber_codec.Read(input);
            if (accountNumber_ == null || value != 0L) {
              AccountNumber = value;
            }
            break;
          }
          case 50: {
            string value = _single_date_codec.Read(input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
          case 58: {
            string value = _single_reference_codec.Read(input);
            if (reference_ == null || value != "") {
              Reference = value;
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
            long? value = _single_billPaymentId_codec.Read(ref input);
            if (billPaymentId_ == null || value != 0L) {
              BillPaymentId = value;
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
            string value = _single_payeeName_codec.Read(ref input);
            if (payeeName_ == null || value != "") {
              PayeeName = value;
            }
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
            long? value = _single_accountNumber_codec.Read(ref input);
            if (accountNumber_ == null || value != 0L) {
              AccountNumber = value;
            }
            break;
          }
          case 50: {
            string value = _single_date_codec.Read(ref input);
            if (date_ == null || value != "") {
              Date = value;
            }
            break;
          }
          case 58: {
            string value = _single_reference_codec.Read(ref input);
            if (reference_ == null || value != "") {
              Reference = value;
            }
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class BillPaymentProtoObjList : pb::IMessage<BillPaymentProtoObjList>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<BillPaymentProtoObjList> _parser = new pb::MessageParser<BillPaymentProtoObjList>(() => new BillPaymentProtoObjList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<BillPaymentProtoObjList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SEP3_DataTier.BillTransactionReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObjList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObjList(BillPaymentProtoObjList other) : this() {
      allBillPayments_ = other.allBillPayments_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public BillPaymentProtoObjList Clone() {
      return new BillPaymentProtoObjList(this);
    }

    /// <summary>Field number for the "allBillPayments" field.</summary>
    public const int AllBillPaymentsFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SEP3_DataTier.BillPaymentProtoObj> _repeated_allBillPayments_codec
        = pb::FieldCodec.ForMessage(10, global::SEP3_DataTier.BillPaymentProtoObj.Parser);
    private readonly pbc::RepeatedField<global::SEP3_DataTier.BillPaymentProtoObj> allBillPayments_ = new pbc::RepeatedField<global::SEP3_DataTier.BillPaymentProtoObj>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public pbc::RepeatedField<global::SEP3_DataTier.BillPaymentProtoObj> AllBillPayments {
      get { return allBillPayments_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as BillPaymentProtoObjList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(BillPaymentProtoObjList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!allBillPayments_.Equals(other.allBillPayments_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= allBillPayments_.GetHashCode();
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
      allBillPayments_.WriteTo(output, _repeated_allBillPayments_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      allBillPayments_.WriteTo(ref output, _repeated_allBillPayments_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      size += allBillPayments_.CalculateSize(_repeated_allBillPayments_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(BillPaymentProtoObjList other) {
      if (other == null) {
        return;
      }
      allBillPayments_.Add(other.allBillPayments_);
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
            allBillPayments_.AddEntriesFrom(input, _repeated_allBillPayments_codec);
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
            allBillPayments_.AddEntriesFrom(ref input, _repeated_allBillPayments_codec);
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