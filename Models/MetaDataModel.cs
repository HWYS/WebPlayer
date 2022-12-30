using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Player.Models
{
    public class MetaDataModel
    {
        public int id { get; set; }
        public string dashSrc { get; set; }
        public string hlsSrc { get; set; }
        public string logoSrc { get; set; }
        public string channelName { get; set; }
        public bool isActive { get; set; }
    }
}