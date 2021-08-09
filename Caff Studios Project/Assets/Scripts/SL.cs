using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
// as i ever
/*
public class SL : MonoBehaviour
{
    [XmlElement]
    public int state { get; set; } // Integer representing players progress

    void Save() //funky
    {
        XmlSerializer xmls = new XmlSerializer(typeof(SL));

        StringWriter sw = new StringWriter();
        xmls.Serialize(sw, new Progress { state = 1 });
        string xml = sw.ToString();

    }
    void Load()
    {
        SL Progress = xmls.Deserialize(new StringReader(xml)) as Progress;
    }
} */ //cannot get to work, stinky
