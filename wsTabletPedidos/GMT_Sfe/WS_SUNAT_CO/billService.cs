using System.CodeDom.Compiler;
using System.ServiceModel;

namespace GMT_Sfe.WS_SUNAT_CO
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "WS_SUNAT_CO.billService", Namespace = "http://service.sunat.gob.pe")]
  public interface billService
  {
    [OperationContract(Action = "urn:getStatus", ReplyAction = "*")]
    [XmlSerializerFormat(SupportFaults = true)]
    [return: MessageParameter(Name = "status")]
    getStatusResponse getStatus(getStatusRequest _param1);

    [XmlSerializerFormat(SupportFaults = true)]
    [OperationContract(Action = "urn:getStatusCdr", ReplyAction = "*")]
    [return: MessageParameter(Name = "statusCdr")]
    getStatusCdrResponse getStatusCdr(getStatusCdrRequest _param1);
  }
}
