using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using SystemInterface.IO;
using SystemInterface.XML.Serialization;

namespace SystemWrapper.XML.Serialization
{
    public class XmlSerializerWrapper : IXmlSerializer
    {
        public XmlSerializer XmlSerializerInstance { get; private set; }

        public XmlSerializerWrapper()
        {
            XmlSerializerInstance = null;
        }

        public void NewXMLSerializer(Type type, Type[] otherTypes)
        {
            XmlSerializerInstance = new XmlSerializer(type, otherTypes);
        }

        public object Deserialize(IFileStream stream)
        {
            return XmlSerializerInstance.Deserialize(stream.FileStreamInstance);
        }
    }
}
