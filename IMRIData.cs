using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRI_Editor_Project
{
    interface IMRIData
    {
         IMRIData init(DataGridViewRow row);
        
    }
}
