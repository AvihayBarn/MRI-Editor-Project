﻿using System;
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
    public partial class MRIEditorInterface : Form
    {
     
        private MRIList mri_list = new MRIList();
       
        public MRIEditorInterface()
        {
            InitializeComponent();
            Column1.DataSource = MRIList.vendors;
            Column2.DataSource = MRIList.powers;
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
            mri_list.save(MRISData);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mri_list.open(MRISData);
        }
    }
}
