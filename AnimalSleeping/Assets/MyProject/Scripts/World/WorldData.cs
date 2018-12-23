using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldData : MonoBehaviour {
    private int id;
    public int ID
    {
        get { return id; }
        set { id = value; }
    }
    private Sprite thumbnail;
    public  Sprite Thumbnail
    {
        get { return thumbnail; }
        set { thumbnail = value; }
    }
    private Text   worldName;
    public Text    WorldName
    {
        get { return WorldName; }
        set { WorldName = value; }
    }

    public void Init()
    {
    
    }
}
