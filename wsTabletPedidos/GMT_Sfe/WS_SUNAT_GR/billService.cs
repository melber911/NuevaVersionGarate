using System.CodeDom.Compiler;
using System.ServiceModel;

namespace GMT_Sfe.WS_SUNAT_GR
{
  [GeneratedCode("System.ServiceModel", "4.0.0.0")]
  [ServiceContract(ConfigurationName = "WS_SUNAT_GR.billService", Namespace = "http://service.sunat.gob.pe")]
  public interface billService
  {
    [XmlSerializerFormat(SupportFaults = true)]
    [OperationContract(Action = "urn:getStatus", ReplyAction = "*")]
    [return: MessageParameter(Name = "status")]
    getStatusResponse getStatus(getStatusRequest _param1);

    [XmlSerializerFormat(SupportFaults = true)]
    [OperationContract(Action = "urn:sendBill", ReplyAction = "*")]
    [return: MessageParameter(Name = "applicationResponse")]
    sendBillResponse sendBill(sendBillRequest _param1);

    [XmlSerializerFormat(SupportFaults = true)]
    [OperationContract(Action = "urn:sendPack", ReplyAction = "*")]
    [return: MessageParameter(Name = "ticket")]
    sendPackResponse sendPack(sendPackRequest _param1);

    [XmlSerializerFormat(SupportFaults = true)]
    [OperationContract(Action = "urn:sendSummary", ReplyAction = "*")]
    [return: MessageParameter(Name = "ticket")]
    sendSummaryResponse sendSummary(sendSummaryRequest _param1);
  }
}
