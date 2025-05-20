using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace GMT_Sfe.WS_SUNAT_CO
{
    [GeneratedCode("System.Xml", "4.6.1586.0")]
    [XmlType(Namespace = "http://service.sunat.gob.pe")]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [Serializable]
    public class statusResponse : INotifyPropertyChanged
    {
        private byte[] contentField;
        private string statusCodeField;
        private string statusMessageField;

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

        [XmlElement(Form = XmlSchemaForm.Unqualified, Order = 2)]
        public string statusMessage
        {
            get
            {
                return this.statusMessageField;
            }
            set
            {
                this.statusMessageField = value;
                this.RaisePropertyChanged(nameof(statusMessage));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler changedEventHandler = this.PropertyChanged;
            if (changedEventHandler == null)
                return;
            changedEventHandler((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
