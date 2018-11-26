using System.Xml.Serialization;
using System.IO;
using System.Text;

public class SavingSystem
{
    public static void SaveDialogue(string path, DialogueSystemContainer dsContainer)
    {
        var serializer = new XmlSerializer(typeof(DialogueSystemContainer));
        var encoding = Encoding.GetEncoding("UTF-8");

        using (var stream = new StreamWriter(path, false, encoding))
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
