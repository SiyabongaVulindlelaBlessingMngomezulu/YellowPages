using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace YellowPages
{
    partial class EntryList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(PhoneBook p)
        {
            this.SuspendLayout();
            // 
            // EntryList
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "EntryList";
            this.Load += new System.EventHandler(this.EntryList_Load_6);
            this.ResumeLayout(false);

            string[] records = readFromFile();
            listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10,10), new Size(200, 140));
            listView1.View = View.Details;

            listView1.CheckBoxes = true;
            listView1.GridLines = true;

            ListViewItem[] data = new ListViewItem[records.Length];

            for (int i = 0; i < records.Length; i++)
            {
                data[i] = new ListViewItem(records[i], 0);
            }


            listView1.Columns.Add("Contact` Number and Name", -2, HorizontalAlignment.Left);
            listView1.Items.AddRange(data);
            this.Controls.Add(listView1);

        }

        private string[] readFromFile()
        {

            ushort count = 0;
            string line = "";
            using (StreamReader r1 = new StreamReader(Properties.Settings.Default.url))
            {
                while ((line = r1.ReadLine()) != null)
                {
                    count++;
                }
            }

            string[] records = new string[count];
            count = 0;
            line = "";
            using (StreamReader r2 = new StreamReader(Properties.Settings.Default.url))
            {
                while ((line = r2.ReadLine()) != null)
                {

                    records[count] = line;
                    count++;
                }
            }
            return records;
        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
    }
}