using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = true, WrapperName = "sendPack", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  public class sendPackRequest
  {
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string fileName;
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
    [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
    public byte[] contentFile;

    public sendPackRequest()
    {
    }

    public sendPackRequest(string _param1, byte[] _param2)
    {
      this.fileName = _param1;
      this.contentFile = _param2;
    }
  }
}
