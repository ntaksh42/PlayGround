using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    public class CoordinateInfo
    {
        [XmlElement("pageSize")]
        public PageSize PageSize { get; set; }

        [XmlElement("fbd")]
        public Scaling Fbd { get; set; }

        [XmlElement("ld")]
        public Scaling Ld { get; set; }

        [XmlElement("sfc")]
        public Scaling Sfc { get; set; }

    }
}
