using System.Xml.Linq;
using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    public class Data
    {
        [XmlElement]
        public XElement Any { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("dataHandleUnknown")]
        public DataHandleUnknown DataHandleUnknown { get; set; }
    }
}
