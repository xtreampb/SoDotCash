namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class InterSyncRequest : AbstractSyncRequest {
        
        private AbstractAccount item1Field;
        
        private InterTransactionRequest[] iNTERTRNRQField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BANKACCTFROM", typeof(BankAccount), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("CCACCTFROM", typeof(CreditCardAccount), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlElementAttribute("LOANACCTFROM", typeof(LoanAccount), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AbstractAccount Item1 {
            get {
                return this.item1Field;
            }
            set {
                this.item1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("INTERTRNRQ", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public InterTransactionRequest[] INTERTRNRQ {
            get {
                return this.iNTERTRNRQField;
            }
            set {
                this.iNTERTRNRQField = value;
            }
        }
    }
}