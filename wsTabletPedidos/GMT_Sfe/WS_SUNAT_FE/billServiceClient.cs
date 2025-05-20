using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GMT_Sfe.WS_SUNAT_FE
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [DebuggerStepThrough]
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

    public statusResponse getStatus(string _param1)
    {
      return ((billService) this).getStatus(new getStatusRequest()
      {
        ticket = _param1
      }).status;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    sendBillResponse billService.sendBill(sendBillRequest _param1)
    {
      return this.Channel.sendBill(_param1);
    }

    public byte[] sendBill(string _param1, byte[] _param2)
    {
      return ((billService) this).sendBill(new sendBillRequest()
      {
        fileName = _param1,
        contentFile = _param2
      }).applicationResponse;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    sendPackResponse billService.sendPack(sendPackRequest _param1)
    {
      return this.Channel.sendPack(_param1);
    }

    public string sendPack(string _param1, byte[] _param2)
    {
      return ((billService) this).sendPack(new sendPackRequest()
      {
        fileName = _param1,
        contentFile = _param2
      }).ticket;
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    sendSummaryResponse billService.sendSummary(
      sendSummaryRequest _param1)
    {
      return this.Channel.sendSummary(_param1);
    }

    public string sendSummary(string _param1, byte[] _param2)
    {
      return ((billService) this).sendSummary(new sendSummaryRequest()
      {
        fileName = _param1,
        contentFile = _param2
      }).ticket;
    }
  }
}
