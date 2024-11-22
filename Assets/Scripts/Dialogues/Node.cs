using System;
using System.Xml.Serialization;

[Serializable]
public class Node
{
    [XmlElement("npctext")]
    public string NpcText;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}

