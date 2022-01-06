using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_as = new SaveFileDialog();
            save_as.Filter = "Text Documents (*.txt)|*.txt|CSV Documents (*.csv)|*.csv";
            save_as.FileName = "default";
            save_as.Title = "Save MRI File";
            if (save_as.ShowDialog() == DialogResult.OK)

            {
                
                StreamWriter writer = new StreamWriter(save_as.OpenFile());
                mri_list.Clear();
                foreach (DataGridViewRow row in MRISData.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null) 
                    { 
                        
                        mri_list.Add(new MRI(row.Cells[0].Value!= null ? Convert.ToString((row.Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "", row.Cells[1].Value != null ? Convert.ToString((row.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "null", row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "null", row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "null", row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "null", Convert.ToBoolean(row.Cells[4].Value)));
                        
                    }
                }
                Console.WriteLine(mri_list.readyToSave());
                writer.Write(mri_list.readyToSave());

                writer.Dispose();

                writer.Close();

            }



        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            
        }
    }
}
