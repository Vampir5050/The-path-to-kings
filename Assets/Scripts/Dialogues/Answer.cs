using System;
using System.Xml.Serialization;

[Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("dialend")]
    public string end;
}
