namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class PinChangeTransactionRequest : AbstractTransactionRequest {
        
        private PinChangeRequest pINCHRQField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PinChangeRequest PINCHRQ {
            get {
                return this.pINCHRQField;
            }
            set {
                this.pINCHRQField = value;
            }
        }
    }
}