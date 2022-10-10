using jp.tmzy.cs.tc6;
using System;
using System.IO;
using System.Windows.Forms;
using tc6v2;
using static System.Environment;

namespace StudyXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnCreate_Click(object sender, EventArgs e)
        {
            //var pro = buildSample();
            //try
            //{
            //    var doc = Tc6v2SimpleWriter.getStored(pro);
            //    Tc6v2SimpleWriter.store(Path.Combine(GetFolderPath(SpecialFolder.Desktop), "sample1.xml"), pro);

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private project buildSample()
        //{
        //    var proj = new project();

        //    proj.fileHeader.companyName = "aksh";
        //    proj.fileHeader.productName = "";
        //    proj.fileHeader.productVersion = "";

        //    /**
        //     * <project>要素の子要素<contentHeader name="" /> の子要素，
        //     * <coordinateInfo />
        //     * に対応
        //     */
        //    proj.contentHeader.name = String.Empty;
        //    proj.contentHeader.coordinateInfo = new coordinateInfo();

        //    // <project>要素の子要素，<types> に対応
        //    proj.types = new types();

        //    // <types>要素の子要素，<pous>要素に <pou>要素を追加
        //    var prog = new pou();
        //    prog.pouType = pouType.program;
        //    proj.types.pous.Add(prog);

        //    // <pous>要素の0番目の子要素(<pou>要素)に，属性や子要素を指定
        //    proj.types.pous[0].name = "sampleFunc";

        //    var localVars = new localVars();
        //    var x = new variable();
        //    x.name = "X";
        //    x.type = new BOOL();

        //    var y = new variable();
        //    y.name = "Y";
        //    y.type = new BOOL();

        //    localVars.variable.Add(x);
        //    localVars.variable.Add(y);

        //    proj.types.pous[0].@interface.localVars.Add(localVars);

        //    // <body><LD/></body>要素
        //    BodyLD ld = new BodyLD();

        //    proj.types.pous[0].body.Add(ld); // LDのボディをbodyの子要素として追加．bodyは複数の子要素をもつことができる


        //    // 左母線
        //    {
        //        var left = new leftPowerRail();
        //        var pointOut = new connectionPointOut_2();
        //        pointOut.formalParameter = "none";
        //        left.connectionPointOut.Add(pointOut);
        //        ld.symbol.Add(left);
        //    }

        //    // 接点
        //    {
        //        var block = new block();
        //        contact contact = new contact(); // 接点
        //        contact.variable = "X";          // 接点の変数(信号)名
        //        contact.localId = 1;

        //        var connection = new connection();
        //        connection.refLocalId = 0;

        //        var connectionPointIn = new connectionPointIn();
        //        connectionPointIn.Items.Add(connection);
        //        contact.connectionPointIn = connectionPointIn;
        //        ld.symbol.Add(contact);// LDのボディにシンボル(コイル)を追加
        //    }

        //    // コイル
        //    {
        //        coil coil = new coil();
        //        coil.localId = 2;
        //        var connectionPointIn = new connectionPointIn();
        //        var connection = new connection();
        //        connection.refLocalId = 1;
        //        connectionPointIn.Items.Add(connection);

        //        coil.connectionPointIn = connectionPointIn;
        //        coil.variable = "Y";    // コイルの変数(信号)名
        //        ld.symbol.Add(coil);          // LDのボディにシンボル(コイル)を追加
        //    }

        //    {
        //        var rightpowRail = new rightPowerRail();
        //        rightpowRail.localId = 2147483646;

        //        var riConPointIn = new connectionPointIn();
        //        var riCon = new connection();
        //        riCon.refLocalId = 2;
        //        riConPointIn.Items.Add(riCon);
        //        rightpowRail.connectionPointIn.Add(riConPointIn);
        //        ld.symbol.Add(rightpowRail);
        //    }

        //    proj.instances = new instances();
        //    proj.instances.configurations.Add(new configuration()); // コンフィギュレーションを追加
        //    proj.instances.configurations[0].name = "conf_0";       // コンフィギュレーション名を設定

        //    return proj;
        //}

        private void _btnRead_Click(object sender, EventArgs e)
        {
            PLCopenXmlReader.Read();
        }
    }

}
