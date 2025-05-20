using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[XmlType(Namespace = "urn:un:unece:uncefact:data:specification:CoreComponentTypeSchemaModule:2")]
[XmlInclude(typeof(MarketValueAmountType))]
[DesignerCategory("code")]
[XmlInclude(typeof(ValueAmountType))]
[XmlInclude(typeof(TransactionCurrencyTaxAmountType))]
[XmlInclude(typeof(TotalTaxAmountType))]
[XmlInclude(typeof(TotalTaskAmountType))]
[XmlInclude(typeof(TotalPaymentAmountType))]
[XmlInclude(typeof(TotalInvoiceAmountType))]
[XmlInclude(typeof(TotalDebitAmountType))]
[XmlInclude(typeof(TotalCreditAmountType))]
[XmlInclude(typeof(TotalBalanceAmountType))]
[XmlInclude(typeof(TotalAmountType))]
[XmlInclude(typeof(ThresholdAmountType))]
[XmlInclude(typeof(TaxableAmountType))]
[XmlInclude(typeof(TaxInclusiveAmountType))]
[XmlInclude(typeof(TaxExclusiveAmountType))]
[XmlInclude(typeof(TaxEnergyOnAccountAmountType))]
[XmlInclude(typeof(TaxEnergyBalanceAmountType))]
[XmlInclude(typeof(TaxEnergyAmountType))]
[XmlInclude(typeof(TaxAmountType))]
[XmlInclude(typeof(SettlementDiscountAmountType))]
[XmlInclude(typeof(RoundingAmountType))]
[XmlInclude(typeof(RequiredFeeAmountType))]
[XmlInclude(typeof(PriceAmountType))]
[XmlInclude(typeof(PrepaidAmountType))]
[XmlInclude(typeof(PerUnitAmountType))]
[XmlInclude(typeof(PenaltyAmountType))]
[XmlInclude(typeof(PayableRoundingAmountType))]
[XmlInclude(typeof(PayableAmountType))]
[XmlInclude(typeof(PayableAlternativeAmountType))]
[XmlInclude(typeof(PartyCapacityAmountType))]
[XmlInclude(typeof(PaidAmountType))]
[XmlInclude(typeof(MinimumAmountType))]
[XmlInclude(typeof(MaximumPaidAmountType))]
[XmlInclude(typeof(MaximumAmountType))]
[XmlInclude(typeof(MaximumAdvertisementAmountType))]
[XmlInclude(typeof(AmountType1))]
[XmlInclude(typeof(LowerTenderAmountType))]
[XmlInclude(typeof(LineExtensionAmountType))]
[XmlInclude(typeof(LiabilityAmountType))]
[XmlInclude(typeof(InventoryValueAmountType))]
[XmlInclude(typeof(InsuranceValueAmountType))]
[XmlInclude(typeof(InsurancePremiumAmountType))]
[XmlInclude(typeof(HigherTenderAmountType))]
[XmlInclude(typeof(FreeOnBoardValueAmountType))]
[XmlInclude(typeof(FeeAmountType))]
[XmlInclude(typeof(FaceValueAmountType))]
[XmlInclude(typeof(EstimatedOverallContractAmountType))]
[XmlInclude(typeof(EstimatedAmountType))]
[XmlInclude(typeof(DocumentationFeeAmountType))]
[XmlInclude(typeof(DeclaredStatisticsValueAmountType))]
[XmlInclude(typeof(DeclaredForCarriageValueAmountType))]
[XmlInclude(typeof(DeclaredCustomsValueAmountType))]
[XmlInclude(typeof(DeclaredCarriageValueAmountType))]
[XmlInclude(typeof(DebitLineAmountType))]
[XmlInclude(typeof(CreditLineAmountType))]
[XmlInclude(typeof(CorrectionUnitAmountType))]
[XmlInclude(typeof(CorrectionAmountType))]
[XmlInclude(typeof(CorporateStockAmountType))]
[XmlInclude(typeof(ChargeTotalAmountType))]
[XmlInclude(typeof(CallExtensionAmountType))]
[XmlInclude(typeof(CallBaseAmountType))]
[XmlInclude(typeof(BaseAmountType))]
[XmlInclude(typeof(BalanceAmountType))]
[XmlInclude(typeof(AverageSubsequentContractAmountType))]
[XmlInclude(typeof(AverageAmountType))]
[XmlInclude(typeof(AnnualAverageAmountType))]
[XmlInclude(typeof(AmountType2))]
[XmlInclude(typeof(AllowanceTotalAmountType))]
[XmlInclude(typeof(AdvertisementAmountType))]
[GeneratedCode("xsd", "4.0.30319.33440")]
[DebuggerStepThrough]
[Serializable]
public class AmountType
{
    private string currencyIDField;
    private string currencyCodeListVersionIDField;
    private Decimal valueField;

    [XmlAttribute(DataType = "normalizedString")]
    public string currencyID
    {
        get
        {
            return this.currencyIDField;
        }
        set
        {
            this.currencyIDField = value;
        }
    }

    [XmlAttribute(DataType = "normalizedString")]
    public string currencyCodeListVersionID
    {
        get
        {
            return this.currencyCodeListVersionIDField;
        }
        set
        {
            this.currencyCodeListVersionIDField = value;
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
