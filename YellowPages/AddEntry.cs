using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace YellowPages
{
    public partial class AddEntry : Form
    {

        public AddEntry()
        {
            if (new FileInfo(Properties.Settings.Default.url).Length > 0)
            {
                phoneBook.readFromFile();
            }

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string phoneNumber = textBox2.Text;

            string pattern = "^0";
            MatchCollection check = Regex.Matches(pattern, phoneNumber);

            if (check.Count > 0 || (name == "" || phoneNumber == ""))
            {
                MessageBox.Show("Sorry but the phone number that you have entered\n is not in the correct format");

            }
            phoneBook.Store.Add(phoneNumber, name);
            phoneBook.writeToFile();

           


               


        }
        private void AddEntry_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        #region
        {
            List<string> holder = new List<string>();
           /* var fetcher = File.ReadAllLines(Properties.Settings.Default.url); 
                foreach (var s in fetcher)
                {
                    holder.Add(s);
                }*/
                string[] parts = new string[2];
             phoneBook.readFromFile();
            using (StreamReader readFile = new StreamReader(Properties.Settings.Default.url))
                #region
                {

                    

                    string line = "";
                while ((line = readFile.ReadLine()) != null)
                #region
                {
                        parts = line.Split();

                        if (parts.Length == 2)
                        {
                        try {
                            phoneBook.Store.Add(parts[0], parts[1]);
                        } catch (ArgumentException ae) { 
                        }
                        (new EntryList(phoneBook)).Show();    
                        return;
                        }
                        else
                        {
                            //MessageBox.Show("Sorry, the data appears to still be in an encrypted format");
                            //return;
                        }


                    }
                #endregion


            }
            #endregion
            // EntryList list = new EntryList(phoneBook);

            /*if (!list.Visible) {
                list.Show();
            }*/
            (new EntryList(phoneBook)).Show();






        }
        #endregion
    }
}

        

