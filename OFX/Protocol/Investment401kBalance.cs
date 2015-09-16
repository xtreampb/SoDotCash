namespace OFX.Protocol
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute()]
    public partial class Investment401kBalance {
        
        private string cASHBALField;
        
        private string pRETAXField;
        
        private string aFTERTAXField;
        
        private string mATCHField;
        
        private string pROFITSHARINGField;
        
        private string rOLLOVERField;
        
        private string oTHERVESTField;
        
        private string oTHERNONVESTField;
        
        private string tOTALField;
        
        private Balance[] bALLISTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string CASHBAL {
            get {
                return this.cASHBALField;
            }
            set {
                this.cASHBALField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PRETAX {
            get {
                return this.pRETAXField;
            }
            set {
                this.pRETAXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string AFTERTAX {
            get {
                return this.aFTERTAXField;
            }
            set {
                this.aFTERTAXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string MATCH {
            get {
                return this.mATCHField;
            }
            set {
                this.mATCHField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string PROFITSHARING {
            get {
                return this.pROFITSHARINGField;
            }
            set {
                this.pROFITSHARINGField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ROLLOVER {
            get {
                return this.rOLLOVERField;
            }
            set {
                this.rOLLOVERField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OTHERVEST {
            get {
                return this.oTHERVESTField;
            }
            set {
                this.oTHERVESTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OTHERNONVEST {
            get {
                return this.oTHERNONVESTField;
            }
            set {
                this.oTHERNONVESTField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TOTAL {
            get {
                return this.tOTALField;
            }
            set {
                this.tOTALField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("BAL", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Balance[] BALLIST {
            get {
                return this.bALLISTField;
            }
            set {
                this.bALLISTField = value;
            }
        }
    }
}