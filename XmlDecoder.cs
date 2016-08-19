using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalLab
{
    public class XmlDecoder
    {
        public Chain DeserializeChain(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Chain));
                StreamReader reader = new StreamReader(path);
                Chain chain = (Chain)xmlSerializer.Deserialize(reader);
                return chain;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }
    }
}
