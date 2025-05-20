using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_CO
{
  [MessageContract(IsWrapped = true, WrapperName = "getStatusCdr", WrapperNamespace = "http://service.sunat.gob.pe")]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [EditorBrowsable(EditorBrowsableState.Advanced)]
  [DebuggerStepThrough]
  public class getStatusCdrRequest
  {
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 0)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string rucComprobante;
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 1)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string tipoComprobante;
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 2)]
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string serieComprobante;
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    [MessageBodyMember(Namespace = "http://service.sunat.gob.pe", Order = 3)]
    public int numeroComprobante;

    public getStatusCdrRequest()
    {
    }

    public getStatusCdrRequest(string _param1, string _param2, string _param3, int _param4)
    {
      this.rucComprobante = _param1;
      this.tipoComprobante = _param2;
      this.serieComprobante = _param3;
      this.numeroComprobante = _param4;
    }
  }
}
