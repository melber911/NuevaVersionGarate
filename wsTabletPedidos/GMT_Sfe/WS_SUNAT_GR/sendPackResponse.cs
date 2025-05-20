using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_GR
{
  [MessageContract(IsWrapped = true, WrapperName = "sendPackResponse", WrapperNamespace = "http://service.sunat.gob.pe")]
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  public class sendPackResponse
  {
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    public string ticket;

    public sendPackResponse()
    {
    }

    public sendPackResponse(string _param1)
    {
      this.ticket = _param1;
    }
  }
}
