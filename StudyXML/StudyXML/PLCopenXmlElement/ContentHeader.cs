using System.Collections.Generic;
using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    public class ContentHeader
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("coordinateInfo")]
        public CoordinateInfo CoordinateInfo { get; set; }

        [XmlElement("addDataInfo")]
        public List<Info> AddDataInfo { get; set; }

        [XmlElement("addData")]
        public List<Data> AddData { get; set; }
    }
}
