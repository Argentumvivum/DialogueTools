using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Conversation
{
    [XmlAttribute]
    public string ID { get; set; }
    public Character Initiator { get; set; }
    [XmlArray("Sentences")]
    [XmlArrayItem("Sentence")]
    public List<Sentence> Sentences { get; set; }
}