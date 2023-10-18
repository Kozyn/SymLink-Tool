using System.Diagnostics;
using System.IO;

namespace SymLink_Tool
{
    public partial class Form1 : Form
    {

        static Chilkat.FileAccess? fac;
        static Modes mode = Modes.FILE;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fac = new Chilkat.FileAccess();
            label2.Text = "Mode: FILE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                label3.Text = fbd.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (mode)
            {
                case Modes.FILE:
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Title = "Select File";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        label4.Text = ofd.FileName;
                    }
                    break;

                case Modes.FOLDER:
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        label4.Text = fbd.SelectedPath;
                    }
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string
                location = label3.Text,
                target = label4.Text,
                name = textBox3.Text;


            location += "\\" + name;

            MessageBox.Show(location);

            if (!fac.SymlinkCreate(target, location))
            {
                MessageBox.Show(fac.LastErrorText);
            } else
            {
                MessageBox.Show("Success");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mode = Modes.FILE;
            label2.Text = "Mode: FILE";
            label4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mode = Modes.FOLDER;
            label2.Text = "Mode: FOLDER";
            label4.Text = "";
        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }
    }
}