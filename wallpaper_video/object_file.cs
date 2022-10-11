﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallpaper_video
{
    class object_file
    {
        public string description { get; set; }
        public string file { get; set; }
        public string preview { get; set; }
        public string title { get; set; }
        public string type { get { return _type ?? "Undefined"; }
                set{ _type = value; } }
        private string _type;
        public string filePath { get; set; }
        public List<string> tags { get; set; }
    }
}
