using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace mtrent_FinalProject
{
    public partial class Form1 : Form
    {

        //Project: Final - Basic Text Editor
        //Create By: Micah Trent

        
        public Form1()
        {
            InitializeComponent();
        }

        //Clear Text
        private void Clear()
        {
            txtText.Text = "";
        }

        //New - Menustrip
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you would like to start a new project?", "Confirm New File", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                Clear();
            }
        }

        //Open - Menustrip
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    
                    txtText.Text = "";
                    string line = "";

                    while((line = sr.ReadLine()) != null)
                    {
                        txtText.Text += line + "\n";
                    }

                    sr.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                txtText.Text = ex.Message;
            }
        }

        //Save As... - Menustrip
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(txtText.Text);

                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                txtText.Text = ex.Message;
            }
        }

        //Exit - Menustrip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you would like to exit?", "Confirm Exit", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        //About - Menustrip
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Author: Micah Trent\nReleased: 12-10-2019", "Basic Text Editor v1.0");
        }
    }
}
