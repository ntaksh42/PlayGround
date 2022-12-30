
using StudyDesignPattern.Objects;

namespace StudyDesignPattern
{
    public partial class Form1 : Form
    {
        private enum CharaIdx
        {
            Mario = 0,
            Luigi,
        }

        private List<CharaBase> _charas = new List<CharaBase>();
        public Form1()
        {
            InitializeComponent();
            _charas.Add(new Mario(new Point(10, 10)));
            _charas.Add(new Luigi(new Point(10, 50)));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var chara in _charas)
            {
                e.Graphics.FillRectangle(new SolidBrush(chara.Color), chara.Pos.X, chara.Pos.Y, 30, 30);

            }
        }

        private void _btnRight_Click(object sender, EventArgs e)
        {
            if (_radioBtnMario.Checked)
            {
            }
            else if (_radioBtnLuigi.Checked)
            {

            }
            _panelDrw.Refresh();
        }

        private void _radioBtnMario_CheckedChanged(object sender, EventArgs e)
        {
            if (_radioBtnMario.Checked)
            {
                _radioBtnMario.Checked = false;
            }
        }
    }
}