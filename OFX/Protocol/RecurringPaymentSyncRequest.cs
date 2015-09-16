namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class RecurringPaymentSyncRequest : AbstractSyncRequest {
        
        private BankAccount bANKACCTFROMField;
        
        private RecurringPaymentTransactionRequest[] rECPMTTRNRQField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BankAccount BANKACCTFROM {
            get {
                return this.bANKACCTFROMField;
            }
            set {
                this.bANKACCTFROMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RECPMTTRNRQ", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public RecurringPaymentTransactionRequest[] RECPMTTRNRQ {
            get {
                return this.rECPMTTRNRQField;
            }
            set {
                this.rECPMTTRNRQField = value;
            }
        }
    }
}