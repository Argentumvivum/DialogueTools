using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

public class Chapter
{
    [XmlAttribute]
    public string ID { get; set; }
    [XmlArray("Scenes")]
    [XmlArrayItem("Scene")]
    public List<Scene> Scenes { get; set; }
}