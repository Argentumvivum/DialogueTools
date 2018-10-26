using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("DialogueSystemContainer")]
public class DialogueSystemContainer
{
    [XmlArray("Chapters")]
    [XmlArrayItem("Chapter")]
    public List<Chapter> Chapters { get; set; }
}