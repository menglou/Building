using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
     //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class root
    {
        public string code { get; set; }
        public string msg { get; set; }

        public string uuid { get; set; }

        public string pw { get; set; }

        public string heartbeattime { get; set; }

        public   building building { get; set; }
    }
}
