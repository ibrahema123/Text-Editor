using System;
using System.Reflection;
using System.Security.Cryptography;

namespace HM5
{
    public partial class frmMain : Form
    {
        public static frmMain form1Instance;

        public void applay_theme(Color ms, Color tbox, Color TextColor)
        {
            msMain.BackColor = ms;
            rtxtUserInput.BackColor = tbox;
            rtxtUserInput.ForeColor = TextColor;
        }

        public Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        public frmMain()
        {
            InitializeComponent();
            form1Instance = this;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt";
            ofd.Title = "Open New File";
            if(ofd.ShowDialog() == DialogResult.OK ) 
            {
                System.IO.StreamReader sr= new System.IO.StreamReader(ofd.FileName);
                rtxtUserInput.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text Files (.txt)|*.txt";
            svf.Title = "Save File";
            if(svf.ShowDialog() == DialogResult.OK ) 
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(svf.FileName);
                sw.Write(rtxtUserInput.Text);
                sw.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to exit this program?", "Exit Dialog.", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtUserInput.SelectAll();
        }

        private void whiteThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.applay_theme(this.zcolor(177, 177, 177), this.zcolor(255, 255, 255), this.zcolor(0, 0, 0));
        }
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.applay_theme(this.zcolor(128, 128, 128), this.zcolor(60, 60, 60), this.zcolor(208, 208, 208));
        }
    }
}