using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class meter
    {
       
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string extid { get; set; }
        [XmlAttribute]
        public string time { get; set; }
       
    }
}
