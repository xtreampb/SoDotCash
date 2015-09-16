namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class LoanStatementEndResponse {
        
        private CurrencyEnum cURDEFField;
        
        private LoanAccount lOANACCTFROMField;
        
        private LoanClosing[] lOANCLOSINGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public CurrencyEnum CURDEF {
            get {
                return this.cURDEFField;
            }
            set {
                this.cURDEFField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LoanAccount LOANACCTFROM {
            get {
                return this.lOANACCTFROMField;
            }
            set {
                this.lOANACCTFROMField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LOANCLOSING", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public LoanClosing[] LOANCLOSING {
            get {
                return this.lOANCLOSINGField;
            }
            set {
                this.lOANCLOSINGField = value;
            }
        }
    }
}