using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Environment;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace StudyExcelAddIn
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            var outlook = GetOutlookInstance();
            var templateFullPath = Path.Combine(GetFolderPath(SpecialFolder.Desktop), "template.oft");

            if (!File.Exists(templateFullPath))
            {
                MessageBox.Show("テンプレートを指定してください。");
            }

            var template = outlook.CreateItemFromTemplate(templateFullPath) as Outlook.MailItem;

            var selectRange = StudyExcelAddIn.Globals.ThisAddIn.Application.Selection as Range;
            var values = new List<string>();
            foreach(Range cell in selectRange)
            {
                if (cell is null) continue;
                values.Add(cell.Text as string);
            }

            if(values.Count() < 3)
            {
                MessageBox.Show("範囲選択が不正");
                return;
            }

            template.HTMLBody += $"<body>\r\n<table border=\"1\">\r\n<tr bgcolor = \"skyblue\">\r\n<td>企画書コード</td>\r\n<td>金額</td>\r\n<td>工数</td>\r\n</tr>\r\n<tr>\r\n<td>{values[0]}</td>\r\n<td>{values[1]}</td>\r\n<td>{values[2]}</td>\r\n</tr>\r\n</table>\r\n</body>";

            template.Display();
        }

        private Outlook.Application GetOutlookInstance()
        {
            Outlook.Application outlook = null;
            if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
            {
                outlook = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
            }
            else
            {
                MessageBox.Show("outlookが起動していません。");
            }
            return outlook;
        }
    }
}
