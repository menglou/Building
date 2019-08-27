using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Xml.Serialization;
using System.IO;
using Model;
using System.Xml;

namespace BuildingDemo
{
    public partial class Form1 : Form
    {
        private WebServiceHelper helper = new WebServiceHelper();
        private string clientname = System.Configuration.ConfigurationManager.AppSettings["clientname"].ToString();//客户端名称
        private string clientcode = System.Configuration.ConfigurationManager.AppSettings["clientcode"].ToString();//客户端身份代码
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //helper.GetUUID(clientname, clientcode);
            //root root = new root();

            //root.code = "0000";
            //root.msg = "sdsada";
            //root.pw = "wdasd";
            //root.heartbeattime = "132626";
            //root.uuid = "4516";


            //meter meter1 = new meter { id = "sd", extid = "5656", time = "20198815" };
            //meter meter2 = new meter { id = "vsa", extid = "434", time = "2018956"};
            //meter meter3 = new meter { id = "jrthr", extid = "644542", time = "20192659" };
            //List<meter> meters = new List<Model.meter>();
            //meters.Add(meter1);
            //meters.Add(meter2);
            //meters.Add(meter3);


            ////root.building

            //XmlSerializer serializer = new XmlSerializer(root.GetType());
            //TextWriter writer = new StreamWriter("C:\\Users\\P0127208\\Desktop\\新建文件夹\\root.xml");
            //serializer.Serialize(writer, root);
            //writer.Close();

            //XmlSerializer serializer = new XmlSerializer(typeof(root));
            //FileStream stream = new FileStream("C:\\Users\\P0127208\\Desktop\\新建文件夹\\root.xml", FileMode.Open);
            //root dep = (root)serializer.Deserialize(stream);
            //stream.Close();

            StreamReader sr = new StreamReader("C:\\Users\\P0127208\\Desktop\\新建文件夹\\root.xml");
            string xml = sr.ReadToEnd();
            sr.Close();

            var date= XmlSerializeHelper.DESerializer<root>(xml);
        }


        /// <summary>
        /// XML序列化公共处理类
        /// </summary>
        public static class XmlSerializeHelper
        {
            /// <summary>
            /// 将实体对象转换成XML
            /// </summary>
            /// <typeparam name="T">实体类型</typeparam>
            /// <param name="obj">实体对象</param>
            public static string XmlSerialize<T>(T obj)
            {
                try
                {
                    using (StringWriter sw = new StringWriter())
                    {
                        Type t = obj.GetType();
                        XmlSerializer serializer = new XmlSerializer(obj.GetType());
                        serializer.Serialize(sw, obj);
                        sw.Close();
                        return sw.ToString();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("将实体对象转换成XML异常", ex);
                }
            }

            /// <summary>
            /// 将XML转换成实体对象
            /// </summary>
            /// <typeparam name="T">实体类型</typeparam>
            /// <param name="strXML">XML</param>
            public static T DESerializer<T>(string strXML) where T : class
            {
                try
                {

                   
                    using (StringReader sr = new StringReader(strXML))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        return serializer.Deserialize(sr) as T;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("将XML转换成实体对象异常", ex);
                }
            }
        }

    }
}
