using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("dialogue")]
public class Dialogue
{
    [XmlElement("node")]
    public Node[] nodes;

    public static Dialogue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue dialogue = serializer.Deserialize(reader) as Dialogue;
        return dialogue;
    }    
    
}
