using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MRI_Editor_Project
{
    public partial class Form1 : Form
    {
        public readonly List<string> powers = new List<string> { "1.5T", "3.0T" };
        public readonly List<string> vendors = new List<string> { "Siemens", "Phillips", "GE" };
        private MRIList<ISaveable> mri_list = new MRIList<ISaveable>();
        StreamWriter writer;
        StreamReader reader;
        public Form1()
        {
            InitializeComponent();
            Column1.DataSource = vendors;
            Column2.DataSource = powers;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }



        private void NewLine_Click(object sender, EventArgs e)
        {
            MRISData.Rows.Add();
        }

        private void DeleteLine_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in MRISData.SelectedRows)
            {
                MRISData.Rows.RemoveAt(row.Index);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            MRISData.Rows.Clear(); 
        }



        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_as = new SaveFileDialog();
            save_as.Filter = "Text Documents (*.txt)|*.txt|CSV Documents (*.csv)|*.csv";
            save_as.FileName = "default";
            save_as.Title = "Save MRI File";
            save_as.OverwritePrompt = true;
            if (save_as.ShowDialog() == DialogResult.OK)

            {
                try

                {
                    if(reader != null)
                    {
                        reader.Close();
                    }
                    
                    if (File.Exists(save_as.FileName))
                    {
                        File.Delete(save_as.FileName);
                    }
                    writer = new StreamWriter(save_as.OpenFile());
                   

                    mri_list.Clear();
                    foreach (DataGridViewRow row in MRISData.Rows)
                    {
                        if (row.Cells[0].Value != "" && row.Cells[1].Value != "")
                        {

                            mri_list.Add(new MRI((string)row.Cells[0].Value != "" ? Convert.ToString((row.Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "", (string)row.Cells[1].Value != "" ? Convert.ToString((row.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "null", row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "null", row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "null", row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "null", Convert.ToBoolean(row.Cells[4].Value)));

                        }
                    }
                    Console.WriteLine(mri_list.readyToSave());
                    writer.Write(mri_list.readyToSave());

                    writer.Dispose();

                    writer.Close();
                }
                catch(SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }



        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "to select image";
  
            open.Filter = "All files(*.*)|*.*|All files(*.*)|*.*";
            open.FilterIndex = 100;
            open.RestoreDirectory = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    reader = new StreamReader(open.FileName);
                    MRISData.Rows.Clear();

                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] mri_data = line.Split(',');
                        int index = MRISData.Rows.Add();
                        DataGridViewRow row = MRISData.Rows[index];
                        if (vendors.Contains(mri_data[0]))
                        {
                            row.Cells[0].Value = mri_data[0];
                        }
                        if (powers.Contains(mri_data[1]))
                        {
                            row.Cells[1].Value = mri_data[1];
                        }
                        row.Cells[2].Value = mri_data[2];
                        row.Cells[3].Value = mri_data[3];
                        row.Cells[5].Value = mri_data[5];
                        if (mri_data[4].Equals("True"))
                        {
                            row.Cells[4].Selected = true;
                        }


                    }
                    reader.Dispose();

                    reader.Close();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }


            }
        }
    }
}
