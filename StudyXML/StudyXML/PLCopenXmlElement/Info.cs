using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    public class Info
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("version")]
        public decimal Version { get; set; }
        
        [XmlAttribute("vendor", DataType ="anyURI")]
        public string Vendor { get; set; }

        [XmlElement]
        public FormattedText Description { get; set; }
    }
}
