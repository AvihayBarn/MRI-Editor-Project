using System;
using System.Collections.Generic;
using System.Text;


namespace MRI_Editor_Project
{
    class MRI : ISaveable
    {
        

        private string vendor { get; set; }
        private string power{ get; set; }
        private string version { get; set; }
        private string os { get; set; }
        private string comments { get; set; }
        private Boolean vnc_supported { get; set; }
       

        public MRI(string vendor,string power,string version,string os,string comments,Boolean vnc_supported)
        {
            this.vendor = vendor;
            this.power = power;
            this.version = version;
            this.os = os;
            this.comments = comments;
            this.vnc_supported = vnc_supported;
        }
        
        public override string ToString()
        {
            return vendor + "," + power + "," + version + "," + os + "," + vnc_supported.ToString() +","+comments;
        }

    }
}

