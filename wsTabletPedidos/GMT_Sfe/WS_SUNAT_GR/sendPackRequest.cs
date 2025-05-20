using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_GR
{
  [MessageContract(IsWrapped = true, WrapperName = "sendPack", WrapperNamespace = "http://service.sunat.gob.pe")]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DebuggerStepThrough]
  public class sendPackRequest
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public string fileName;
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
    [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
    public byte[] contentFile;
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 2)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string partyType;

    public sendPackRequest()
    {
    }

    public sendPackRequest(string _param1, byte[] _param2, string _param3)
    {
      this.fileName = _param1;
      this.contentFile = _param2;
      this.partyType = _param3;
    }
  }
}
