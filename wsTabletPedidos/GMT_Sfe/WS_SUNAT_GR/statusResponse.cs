using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_GR
{
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://service.sunat.gob.pe")]
    [DebuggerStepThrough]
    [GeneratedCode("System.Xml", "4.7.3056.0")]
    [Serializable]
    public class statusResponse : INotifyPropertyChanged
    {
        private byte[] contentField;
        private string statusCodeField;

        [XmlElement(DataType = "base64Binary", Form = XmlSchemaForm.Unqualified, Order = 0)]
        public byte[] content
        {
            get
            {
                return this.contentField;
            }
            set
            {
                this.contentField = value;
                this.RaisePropertyChanged(nameof(content));
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, Order = 1)]
        public string statusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
                this.RaisePropertyChanged(nameof(statusCode));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged == null)
                return;
            propertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
