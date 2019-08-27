using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
   public class building
    {
        [XmlAttribute]
        public string id { get; set; }
        public  meter meter { get; set; }
    }
}
