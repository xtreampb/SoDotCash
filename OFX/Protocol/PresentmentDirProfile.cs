namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class PresentmentDirProfile {
        
        private DaysEnum[] pROCDAYSOFFField;
        
        private BooleanType cANSUPPORTIMAGESField;
        
        private string pROCENDTMField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PROCDAYSOFF", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DaysEnum[] PROCDAYSOFF {
            get {
                return pROCDAYSOFFField;
            }
            set {
                pROCDAYSOFFField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public BooleanType CANSUPPORTIMAGES {
            get {
                return cANSUPPORTIMAGESField;
            }
            set {
                cANSUPPORTIMAGESField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PROCENDTM {
            get {
                return pROCENDTMField;
            }
            set {
                pROCENDTMField = value;
            }
        }
    }
}