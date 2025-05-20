using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [DebuggerStepThrough]
  [MessageContract(IsWrapped = true, WrapperName = "getStatus", WrapperNamespace = "http://service.sunat.gob.pe")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public class getStatusRequest
  {
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string ticket;

    public getStatusRequest()
    {
    }

    public getStatusRequest(string _param1)
    {
      this.ticket = _param1;
    }
  }
}
