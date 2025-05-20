using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_GR
{
  [DebuggerStepThrough]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [MessageContract(IsWrapped = true, WrapperName = "sendSummaryResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
  public class sendSummaryResponse
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public string ticket;

    public sendSummaryResponse()
    {
    }

    public sendSummaryResponse(string _param1)
    {
      this.ticket = _param1;
    }
  }
}
