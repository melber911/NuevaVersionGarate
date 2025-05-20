using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_CO
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [MessageContract(IsWrapped = true, WrapperName = "getStatusCdrResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  public class getStatusCdrResponse
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public statusResponse statusCdr;

    public getStatusCdrResponse()
    {
    }

    public getStatusCdrResponse(statusResponse _param1)
    {
      this.statusCdr = _param1;
    }
  }
}
