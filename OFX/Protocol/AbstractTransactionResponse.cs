namespace OFX.Protocol
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(WireTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EnrollTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ChangeUserInfoTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccountTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AccountInfoTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MFAChallengeTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PinChangeTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ChallengeTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SecurityListTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProfileTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LoanMailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LoanStatementEndTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AmortizationTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(LoanStatementTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InvestmentStatementEndTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InvestmentStatementTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InvestmentMailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RecurringInterTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(InterTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GetMimeTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreditCardStatementTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CreditCardStatementEndTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(FindBillerTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PresentmentNotifyTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PresentmentMailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PresentmentListTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PresentmentGroupAccountInfoTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PresentmentDetailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BillTableStructureTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BillStatusModTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RecurringPaymentTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PaymentTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PaymentMailTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PaymentInquiryTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PayeeTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RecurringIntraTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StatementEndTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StatementTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(StopCheckTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IntraTransactionResponse))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(BankMailTransactionResponse))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public abstract partial class AbstractTransactionResponse : AbstractResponse {
        
        private string tRNUIDField;
        
        private Status sTATUSField;
        
        private string cLTCOOKIEField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TRNUID {
            get {
                return this.tRNUIDField;
            }
            set {
                this.tRNUIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Status STATUS {
            get {
                return this.sTATUSField;
            }
            set {
                this.sTATUSField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CLTCOOKIE {
            get {
                return this.cLTCOOKIEField;
            }
            set {
                this.cLTCOOKIEField = value;
            }
        }
    }
}