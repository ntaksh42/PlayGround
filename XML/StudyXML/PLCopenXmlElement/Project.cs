using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    [XmlRoot("project")]
    public class Project
    {
        [XmlElement("fileHeader")]
        public FileHeader FileHeader { get; set; }

        [XmlElement("contentHeader")]
        public ContentHeader ContentHeader;


    }

    public class Types
    {
        [XmlElement("pou")]
        public POU Pou { get; set; }
    }

    public class POU
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("pouType")]
        public PouType PouType { get; set; }

        [XmlAttribute("globalId")]
        public string GlobalId { get; set; } 


        [XmlElement("addData")]
        public List<Data> AddData { get; set; }

        [XmlElement("documentation")]
        public List<Data> Documentation { get; set; }

    }

    [XmlInclude(typeof(BodyLD))]
    public abstract class Body
    {

    }

    public class BodyLD : Body
    {
        
    }

    public abstract class LdObject
    {

    }

    public enum PouType
    {
        Function,
        FunctionBlock,
        Program,
    }
}
