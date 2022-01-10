﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRI_Editor_Project 
{
    class MRIList : List<MRI>, ISaveable
    {
        public static readonly List<string> powers = new List<string> { "1.5T", "3.0T" };
        public static readonly List<string> vendors = new List<string> { "Siemens", "Phillips", "GE" };
        List<MRI> mri_data_list = new List<MRI>();


        private string readyToSave()
        {
            string ready_to_save = "";
            foreach (MRI mri in mri_data_list)
            {
                Console.WriteLine(mri.ToString());
                ready_to_save += mri.ToString() + "\n";
            }
            return ready_to_save;
        }

        public void open(DataGridView dataGridView)
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
                    StreamReader reader = new System.IO.StreamReader(open.FileName);
                    dataGridView.Rows.Clear();

                    string line = "";
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] mri_data = line.Split(',');
                        int index = dataGridView.Rows.Add();
                        DataGridViewRow row = dataGridView.Rows[index];
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
                        DataGridViewCheckBoxCell vnc = row.Cells[4] as DataGridViewCheckBoxCell;
                        if (mri_data[4].Equals("True"))
                        {
                            vnc.Value = true;
                        }
                        else vnc.Value = false;


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
        public void save(DataGridView dataGridView)
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


                    if (File.Exists(save_as.FileName))
                    {
                        
                        Console.WriteLine(save_as.FileName);
                        File.Delete(save_as.FileName);
                    }
                    StreamWriter writer = new StreamWriter(save_as.OpenFile());


                    mri_data_list.Clear();
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        if ((string)row.Cells[0].Value != "" && (string)row.Cells[1].Value != "")
                        {

                         
                            mri_data_list.Add(new MRI(row));
                            
                        }
                    }

                    
                    
                    
                    writer.Write(readyToSave());

                    writer.Dispose();

                    writer.Close();
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
