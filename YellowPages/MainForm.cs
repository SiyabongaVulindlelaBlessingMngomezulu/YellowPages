using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YellowPages
{
    public partial class MainForm : Form
    {
       
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Equals("hot mess"))
            {
                AddEntry entry = new AddEntry();
                entry.Show();
               
            }
            else
            {
                MessageBox.Show("Sorry but that password is not correct");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            if (System.IO.File.Exists(Properties.Settings.Default.url))
            {
                if (new System.IO.FileInfo(Properties.Settings.Default.url).Length > 0)
                {
                    using (PhoneBook p = new PhoneBook())
                    {
                        p.UnScramble();
                    }
                }
            }
            else {
                MessageBox.Show("In order for this app to work\nAn empty text  file needs to be created at this location:\n" + Properties.Settings.Default.url);
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        


    }
}
