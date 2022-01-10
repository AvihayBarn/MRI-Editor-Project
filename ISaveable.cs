using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRI_Editor_Project
{

    /// <summary>
    /// ISavable is an interface that represent object or data that can be saved from DataGridView into file
    /// or uploaded to the DataGridView   /// </summary>
    interface ISaveable
    {
        void save(DataGridView dataGridView);
        void open(DataGridView dataGridView);
    }
}
