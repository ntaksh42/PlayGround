using System.Xml.Serialization;

namespace StudyXML.PLCopenXmlElement
{
    [XmlInclude(typeof(fbdSymbol))]
    [XmlInclude(typeof(fbdObject))]
    [XmlInclude(typeof(block))]
    [XmlInclude(typeof(@return))]
    [XmlInclude(typeof(jump))]
    [XmlInclude(typeof(label))]
    [XmlInclude(typeof(inOutVariable))]
    [XmlInclude(typeof(outVariable))]
    [XmlInclude(typeof(inVariable))]
    [XmlInclude(typeof(commonObject))]
    [XmlInclude(typeof(vendorElement))]
    [XmlInclude(typeof(actionBlock))]
    [XmlInclude(typeof(continuation))]
    [XmlInclude(typeof(connector))]
    [XmlInclude(typeof(error))]
    [XmlInclude(typeof(comment))]
    [XmlInclude(typeof(ldObject))]
    [XmlInclude(typeof(leftPowerRail))]
    [XmlInclude(typeof(contact))]
    [XmlInclude(typeof(coil))]
    [XmlInclude(typeof(rightPowerRail))]
    public abstract class LdSymbol
    {

    }
}
