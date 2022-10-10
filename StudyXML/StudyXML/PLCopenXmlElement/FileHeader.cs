using System;
using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    public class FileHeader
    {
        [XmlAttribute]
        public string CompanyName { get; set; }

        [XmlAttribute(DataType = "anyURI")]
        public string CompanyURL { get; set; }

        [XmlAttribute]
        public string ProductName { get; set; }

        [XmlAttribute]
        public string ProductVersion { get; set; }
        
        [XmlAttribute]
        public string ProductRelease { get; set; }

        [XmlAttribute]
        public DateTime CreationDateTime { get; set; }

        [XmlAttribute]
        public string ContentDescription { get; set; }
    }
}
