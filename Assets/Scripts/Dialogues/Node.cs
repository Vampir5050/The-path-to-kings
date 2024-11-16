using System;
using System.Xml.Serialization;

[Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string npcText;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}
