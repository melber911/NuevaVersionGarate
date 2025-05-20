using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = true, WrapperName = "sendSummary", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class sendSummaryRequest
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public string fileName;
    [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
    public byte[] contentFile;

    public sendSummaryRequest()
    {
    }

    public sendSummaryRequest(string _param1, byte[] _param2)
    {
      this.fileName = _param1;
      this.contentFile = _param2;
    }
  }
}
