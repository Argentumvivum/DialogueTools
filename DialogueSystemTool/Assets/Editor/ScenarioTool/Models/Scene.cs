using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Scene
{
    [XmlAttribute]
    public string ID { get; set; }
    [XmlArray("Conversations")]
    [XmlArrayItem("Conversation")]
    public List<Conversation> Conversations { get; set; }
}