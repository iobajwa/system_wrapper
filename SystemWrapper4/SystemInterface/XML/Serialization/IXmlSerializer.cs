using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using SystemInterface.IO;

namespace SystemInterface.XML.Serialization
{
    public interface IXmlSerializer
    {
        /// <summary>
        /// Creates a new IXmlSerializer object by passing the constructor.
        /// </summary>
        /// <param name="type">The Type which is to be serialized</param>
        /// <param name="otherTypes">Any other types used within the Type</param>
        void NewXMLSerializer(Type type, Type[] otherTypes);

        /// <summary>
        /// Gets the underline XmlSerializer instance.
        /// </summary>
        XmlSerializer XmlSerializerInstance { get; }

        /// <summary>
        /// Deserializes the XML document contained by the specified System.IO.Stream.
        /// </summary>
        /// <param name="stream">The System.IO.Stream that contains the XML Document to deserialize.</param>
        object Deserialize(IFileStream stream);
    }
}
