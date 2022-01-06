using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRI_Editor_Project
{
    class MRIList<T> : List<T>
    {
        List<T> mri_list = new List<T>();
        
     
        
        public void Add(T saveable)
        {
            mri_list.Add(saveable);
        }
        public void Clear()
        {
            mri_list.Clear();
        }

        public string readyToSave()
        {
            string ready_to_save ="";
            foreach(T saveable in mri_list)
            {
                Console.WriteLine(saveable.ToString());
                ready_to_save += saveable.ToString() + "\n";
            }
            
            return ready_to_save;
            
        }

    }
}
