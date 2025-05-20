using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlInclude(typeof(MinimumInventoryQuantityType))]
[XmlInclude(typeof(MinimumBackorderQuantityType))]
[XmlInclude(typeof(QuantityType1))]
[XmlInclude(typeof(VarianceQuantityType))]
[XmlInclude(typeof(ValueQuantityType))]
[XmlInclude(typeof(TotalTransportHandlingUnitQuantityType))]
[XmlInclude(typeof(TotalPackagesQuantityType))]
[XmlInclude(typeof(TotalPackageQuantityType))]
[XmlInclude(typeof(TotalMeteredQuantityType))]
[XmlInclude(typeof(TotalGoodsItemQuantityType))]
[XmlInclude(typeof(TotalDeliveredQuantityType))]
[XmlInclude(typeof(TotalConsumedQuantityType))]
[XmlInclude(typeof(TimeDeltaDaysQuantityType))]
[XmlInclude(typeof(ThresholdQuantityType))]
[XmlInclude(typeof(TargetInventoryQuantityType))]
[XmlInclude(typeof(ShortQuantityType))]
[XmlInclude(typeof(SharesNumberQuantityType))]
[XmlInclude(typeof(ReturnableQuantityType))]
[XmlInclude(typeof(RejectedQuantityType))]
[XmlInclude(typeof(ReceivedTenderQuantityType))]
[XmlInclude(typeof(ReceivedQuantityType))]
[XmlInclude(typeof(ReceivedForeignTenderQuantityType))]
[XmlInclude(typeof(ReceivedElectronicTenderQuantityType))]
[XmlInclude(typeof(QuantityType2))]
[XmlInclude(typeof(PreviousMeterQuantityType))]
[XmlInclude(typeof(PerformanceValueQuantityType))]
[XmlInclude(typeof(PassengerQuantityType))]
[XmlInclude(typeof(PackQuantityType))]
[XmlInclude(typeof(OversupplyQuantityType))]
[XmlInclude(typeof(OutstandingQuantityType))]
[XmlInclude(typeof(OperatingYearsQuantityType))]
[XmlInclude(typeof(NormalTemperatureReductionQuantityType))]
[XmlInclude(typeof(MultipleOrderQuantityType))]
[XmlInclude(typeof(MinimumQuantityType))]
[XmlInclude(typeof(MinimumOrderQuantityType))]
[XmlInclude(typeof(CustomsTariffQuantityType))]
[XmlInclude(typeof(MaximumVariantQuantityType))]
[XmlInclude(typeof(MaximumQuantityType))]
[XmlInclude(typeof(MaximumOrderQuantityType))]
[XmlInclude(typeof(MaximumOperatorQuantityType))]
[XmlInclude(typeof(MaximumBackorderQuantityType))]
[XmlInclude(typeof(LatestMeterQuantityType))]
[XmlInclude(typeof(InvoicedQuantityType))]
[XmlInclude(typeof(GasPressureQuantityType))]
[XmlInclude(typeof(ExpectedQuantityType))]
[XmlInclude(typeof(ExpectedOperatorQuantityType))]
[XmlInclude(typeof(EstimatedOverallContractQuantityType))]
[XmlInclude(typeof(EstimatedConsumedQuantityType))]
[XmlInclude(typeof(EmployeeQuantityType))]
[XmlInclude(typeof(DifferenceTemperatureReductionQuantityType))]
[XmlInclude(typeof(DeliveredQuantityType))]
[XmlInclude(typeof(DebitedQuantityType))]
[XmlInclude(typeof(ChargeableQuantityType))]
[XmlType(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
[XmlInclude(typeof(CreditedQuantityType))]
[XmlInclude(typeof(ContentUnitQuantityType))]
[XmlInclude(typeof(ConsumptionWaterQuantityType))]
[XmlInclude(typeof(ConsumptionEnergyQuantityType))]
[XmlInclude(typeof(ConsumerUnitQuantityType))]
[XmlInclude(typeof(ConsignmentQuantityType))]
[XmlInclude(typeof(ChildConsignmentQuantityType))]
[XmlInclude(typeof(CrewQuantityType))]
[XmlInclude(typeof(BatchQuantityType))]
[XmlInclude(typeof(BasicConsumedQuantityType))]
[XmlInclude(typeof(BaseQuantityType))]
[XmlInclude(typeof(BackorderQuantityType))]
[XmlInclude(typeof(ActualTemperatureReductionQuantityType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[Serializable]
public class QuantityType
{
    private string unitCodeField;
    private string unitCodeListIDField;
    private string unitCodeListAgencyIDField;
    private string unitCodeListAgencyNameField;
    private Decimal valueField;

    [XmlAttribute(DataType = "normalizedString")]
    public string unitCode
    {
        get
        {
            return this.unitCodeField;
        }
        set
        {
            this.unitCodeField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string unitCodeListID
    {
        get
        {
            return this.unitCodeListIDField;
        }
        set
        {
            this.unitCodeListIDField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string unitCodeListAgencyID
    {
        get
        {
            return this.unitCodeListAgencyIDField;
        }
        set
        {
            this.unitCodeListAgencyIDField = value;
        }
    }

    [XmlAttribute]
    public string unitCodeListAgencyName
    {
        get
        {
            return this.unitCodeListAgencyNameField;
        }
        set
        {
            this.unitCodeListAgencyNameField = value;
        }
    }

    [XmlText]
    public Decimal Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}
