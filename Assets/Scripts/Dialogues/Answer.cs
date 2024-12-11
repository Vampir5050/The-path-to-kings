using System;
using System.Xml.Serialization;

[Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("title")]
    public string title;
    [XmlElement("description")]
    public string description;
    [XmlElement("dialend")]
    public string end;


    [XmlAttribute("questvalue")]
    public  int QuestValue;
    [XmlAttribute("needquestvalue")]
    public  int NeedQuestValue;
    [XmlAttribute("questname")]
    public  string QuestName;
    [XmlAttribute("questdescription")]
    public string QuestDescription;
    
}
