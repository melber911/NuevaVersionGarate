using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_GR
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [MessageContract(IsWrapped = true, WrapperName = "sendBill", WrapperNamespace = "http://service.sunat.gob.pe")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DebuggerStepThrough]
  public class sendBillRequest
  {
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string fileName;
    [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
    public byte[] contentFile;
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 2)]
    public string partyType;

    public sendBillRequest()
    {
    }

    public sendBillRequest(string _param1, byte[] _param2, string _param3)
    {
      this.fileName = _param1;
      this.contentFile = _param2;
      this.partyType = _param3;
    }
  }
}
