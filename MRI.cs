using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MRI_Editor_Project
{
    /// <summary>
    /// The MRI Class helps to store the data from the DataGridView into objects,
    /// that it would be easier to save it in a file.
    /// </summary>
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

            
            vendor = (string)row.Cells[0].Value != "" ? Convert.ToString((row.Cells[0] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "";
            power = (string)row.Cells[1].Value != "" ? Convert.ToString((row.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString()) : "";
            version = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : "";
            os = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : "null";
            comments = row.Cells[5].Value != null ? row.Cells[5].Value.ToString() : "null";
            DataGridViewCheckBoxCell vnc = row.Cells["Vnc"] as DataGridViewCheckBoxCell;
            bool isChecked = (bool)vnc.EditingCellFormattedValue;
            vnc_supported = isChecked ? true : false;

            
        }

        public override string ToString()
        {
            return vendor + "," + power + "," + version + "," + os + "," + vnc_supported.ToString() +","+comments;
        }

    }
}

