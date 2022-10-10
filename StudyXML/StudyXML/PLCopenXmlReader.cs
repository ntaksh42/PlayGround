using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using tc6v2;
using static System.Environment;

namespace StudyXML
{
    internal static class PLCopenXmlReader
    {
        private static string _desktopFullPath = GetFolderPath(SpecialFolder.Desktop);

        public static void Read()
        {

            XmlSchema schema = null;
            XmlSchemaSet schemaSet = new XmlSchemaSet();

            var targetXsdFullPath = Path.Combine(_desktopFullPath, "XML調査.xsd");

            schemaSet.Add("http://www.plcopen.org/xml/tc6_0200", targetXsdFullPath);

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                schema = s;
            }
            XmlDocument xmlDocument = new XmlDocument();

            var xs = new XmlSerializer(typeof(project));
            project proj;
            using (var sr = new StreamReader(Path.Combine(_desktopFullPath, "sample1.xml"), Encoding.UTF8))
            using (var xr = System.Xml.XmlReader.Create(sr))
            {
                proj = (project)xs.Deserialize(xr); 
            }
        }
    }
}
