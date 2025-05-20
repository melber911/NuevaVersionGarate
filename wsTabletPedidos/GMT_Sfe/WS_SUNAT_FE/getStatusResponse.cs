using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [MessageContract(IsWrapped = true, WrapperName = "getStatusResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class getStatusResponse
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public statusResponse status;

    public getStatusResponse()
    {
    }

    public getStatusResponse(statusResponse _param1)
    {
      this.status = _param1;
    }
  }
}
