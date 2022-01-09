using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRI_Editor_Project
{
    class MRI 
    {


        private string vendor;
        private string power;
        private string version;
        private string os;
        private string comments; 
        private Boolean vnc_supported;

        
        
        public MRI(DataGridViewRow row)
        {

            
            this.vendor = (string)row.Cells[0].Value != "" ? Convert.ToString((row.Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "";
            this.power = (string)row.Cells[1].Value != "" ? Convert.ToString((row.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "";
            this.version = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "";
            this.os = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "null";
            this.comments = row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "null";
            this.vnc_supported = Convert.ToBoolean(row.Cells[4].Value);

            
        }

        public override string ToString()
        {
            return vendor + "," + power + "," + version + "," + os + "," + vnc_supported.ToString() +","+comments;
        }

    }
}

