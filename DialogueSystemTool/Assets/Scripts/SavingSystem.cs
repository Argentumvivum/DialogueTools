using System.Xml.Serialization;
using System.IO;

public class SavingSystem
{
    public static void SaveDialogue(string path, DialogueSystemContainer dsContainer)
    {
        var serializer = new XmlSerializer(typeof(DialogueSystemContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, dsContainer);
        }
    }

    public static DialogueSystemContainer LoadDialogue(string path)
    {
        var serializer = new XmlSerializer(typeof(DialogueSystemContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as DialogueSystemContainer;
        }
    }
}
