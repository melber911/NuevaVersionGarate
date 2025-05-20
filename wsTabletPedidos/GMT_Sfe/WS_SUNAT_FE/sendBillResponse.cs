using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [MessageContract(IsWrapped = true, WrapperName = "sendBillResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public class sendBillResponse
  {
    [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public byte[] applicationResponse;

    public sendBillResponse()
    {
    }

    public sendBillResponse(byte[] _param1)
    {
      this.applicationResponse = _param1;
    }
  }
}
