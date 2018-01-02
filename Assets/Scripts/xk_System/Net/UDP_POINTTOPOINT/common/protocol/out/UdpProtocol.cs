// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: udp_protocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace UdpPointtopointProtocols {

  /// <summary>Holder for reflection information generated from udp_protocol.proto</summary>
  public static partial class UdpProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for udp_protocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UdpProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChJ1ZHBfcHJvdG9jb2wucHJvdG8SGnVkcF9wb2ludHRvcG9pbnRfcHJvdG9j",
            "b2xzIikKElBhY2thZ2VDaGVja1Jlc3VsdBITCgtuV2hvT3JkZXJJZBgCIAEo",
            "ByIgCglIZWFydEJlYXQSEwoLblNlcnZlclRpbWUYASABKAciKQoKY3NDaGF0",
            "RGF0YRIKCgJpZBgBIAEoBxIPCgd0YWxrTXNnGAIgASgJYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::UdpPointtopointProtocols.PackageCheckResult), global::UdpPointtopointProtocols.PackageCheckResult.Parser, new[]{ "NWhoOrderId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::UdpPointtopointProtocols.HeartBeat), global::UdpPointtopointProtocols.HeartBeat.Parser, new[]{ "NServerTime" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::UdpPointtopointProtocols.csChatData), global::UdpPointtopointProtocols.csChatData.Parser, new[]{ "Id", "TalkMsg" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///检查 包的序列，以及是否丢包
  /// </summary>
  public sealed partial class PackageCheckResult : pb::IMessage<PackageCheckResult> {
    private static readonly pb::MessageParser<PackageCheckResult> _parser = new pb::MessageParser<PackageCheckResult>(() => new PackageCheckResult());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PackageCheckResult> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UdpPointtopointProtocols.UdpProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PackageCheckResult() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PackageCheckResult(PackageCheckResult other) : this() {
      nWhoOrderId_ = other.nWhoOrderId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PackageCheckResult Clone() {
      return new PackageCheckResult(this);
    }

    /// <summary>Field number for the "nWhoOrderId" field.</summary>
    public const int NWhoOrderIdFieldNumber = 2;
    private uint nWhoOrderId_;
    /// <summary>
    ///前Uint16 ：1：客户端，2：服务器， 后16位： 发包的序号ID
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint NWhoOrderId {
      get { return nWhoOrderId_; }
      set {
        nWhoOrderId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PackageCheckResult);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PackageCheckResult other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NWhoOrderId != other.NWhoOrderId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (NWhoOrderId != 0) hash ^= NWhoOrderId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (NWhoOrderId != 0) {
        output.WriteRawTag(21);
        output.WriteFixed32(NWhoOrderId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (NWhoOrderId != 0) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PackageCheckResult other) {
      if (other == null) {
        return;
      }
      if (other.NWhoOrderId != 0) {
        NWhoOrderId = other.NWhoOrderId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 21: {
            NWhoOrderId = input.ReadFixed32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// 一切以心跳为准，有心跳就加进来，心跳超时就断开
  /// </summary>
  public sealed partial class HeartBeat : pb::IMessage<HeartBeat> {
    private static readonly pb::MessageParser<HeartBeat> _parser = new pb::MessageParser<HeartBeat>(() => new HeartBeat());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<HeartBeat> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UdpPointtopointProtocols.UdpProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeartBeat() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeartBeat(HeartBeat other) : this() {
      nServerTime_ = other.nServerTime_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public HeartBeat Clone() {
      return new HeartBeat(this);
    }

    /// <summary>Field number for the "nServerTime" field.</summary>
    public const int NServerTimeFieldNumber = 1;
    private uint nServerTime_;
    /// <summary>
    ///心跳包，每次发送服务器时间
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint NServerTime {
      get { return nServerTime_; }
      set {
        nServerTime_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as HeartBeat);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(HeartBeat other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (NServerTime != other.NServerTime) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (NServerTime != 0) hash ^= NServerTime.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (NServerTime != 0) {
        output.WriteRawTag(13);
        output.WriteFixed32(NServerTime);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (NServerTime != 0) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(HeartBeat other) {
      if (other == null) {
        return;
      }
      if (other.NServerTime != 0) {
        NServerTime = other.NServerTime;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            NServerTime = input.ReadFixed32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///TEST 客户端 发送聊天
  /// </summary>
  public sealed partial class csChatData : pb::IMessage<csChatData> {
    private static readonly pb::MessageParser<csChatData> _parser = new pb::MessageParser<csChatData>(() => new csChatData());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<csChatData> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::UdpPointtopointProtocols.UdpProtocolReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public csChatData() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public csChatData(csChatData other) : this() {
      id_ = other.id_;
      talkMsg_ = other.talkMsg_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public csChatData Clone() {
      return new csChatData(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private uint id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "talkMsg" field.</summary>
    public const int TalkMsgFieldNumber = 2;
    private string talkMsg_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string TalkMsg {
      get { return talkMsg_; }
      set {
        talkMsg_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as csChatData);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(csChatData other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (TalkMsg != other.TalkMsg) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (TalkMsg.Length != 0) hash ^= TalkMsg.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(13);
        output.WriteFixed32(Id);
      }
      if (TalkMsg.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(TalkMsg);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + 4;
      }
      if (TalkMsg.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TalkMsg);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(csChatData other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.TalkMsg.Length != 0) {
        TalkMsg = other.TalkMsg;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            Id = input.ReadFixed32();
            break;
          }
          case 18: {
            TalkMsg = input.ReadString();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
