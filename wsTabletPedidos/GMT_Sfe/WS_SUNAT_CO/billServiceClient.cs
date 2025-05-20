using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GMT_Sfe.WS_SUNAT_CO
{
  [DebuggerStepThrough]
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  public class billServiceClient : ClientBase<billService>, billService
  {
    public billServiceClient()
    {
    }

    public billServiceClient(string _param1)
      : base(_param1)
    {
    }

    public billServiceClient(string _param1, string _param2)
      : base(_param1, _param2)
    {
    }

    public billServiceClient(string _param1, EndpointAddress _param2)
      : base(_param1, _param2)
    {
    }

    public billServiceClient(Binding _param1, EndpointAddress _param2)
      : base(_param1, _param2)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    getStatusResponse billService.getStatus(getStatusRequest _param1)
    {
      return this.Channel.getStatus(_param1);
    }

    public statusResponse getStatus(
      string _param1,
      string _param2,
      string _param3,
      int _param4)
    {
      return ((billService) this).getStatus(new getStatusRequest()
      {
        rucComprobante = _param1,
        tipoComprobante = _param2,
        serieComprobante = _param3,
        numeroComprobante = _param4
      }).status;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    getStatusCdrResponse billService.getStatusCdr(
      getStatusCdrRequest _param1)
    {
      return this.Channel.getStatusCdr(_param1);
    }

    public statusResponse getStatusCdr(
      string _param1,
      string _param2,
      string _param3,
      int _param4)
    {
      return ((billService) this).getStatusCdr(new getStatusCdrRequest()
      {
        rucComprobante = _param1,
        tipoComprobante = _param2,
        serieComprobante = _param3,
        numeroComprobante = _param4
      }).statusCdr;
    }
  }
}
