using Microsoft.Office.Tools.Ribbon;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Outlook = Microsoft.Office.Interop.Outlook;

using static System.Environment;
using System.Xml;

namespace StudyOutlookAddIn
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var outlook = StudyOutlookAddIn.Globals.ThisAddIn.Application;
            var folder = outlook.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            var readerSetting = new XmlReaderSettings()
            {
                CheckCharacters = false,
            };

            using (var sr = new StreamReader(@"C:\Users\user\source\repos\StudyOutlookAddIn\StudyOutlookAddIn\setting.xml"))
            using (var xr = System.Xml.XmlReader.Create(sr, readerSetting))
            {
                var targetCompany = (Settings)xmlSerializer.Deserialize(xr);
            }

            // 宛先が
            foreach (Outlook.MailItem mail in folder.Items)
            {
                
            }
        }
    }
}
