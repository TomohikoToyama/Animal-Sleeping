using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldData : MonoBehaviour {
    private int id;
    public  int ID { get { return id; } set { id = value; } }
    private Image thumbnail;
    public  Image Thumbnail{ get { return thumbnail; } set { thumbnail = value; }}
    private Text worldText;
    public  Text WorldText{ get { return worldText; }set { worldText = value; }}
    private string worldName;
    public  string WorldName { get { return worldName; } set { worldName = value; } }
    private int moveType;
    public  int MoveType { get { return moveType; } set { moveType = value; } }
    private int favorite;
    public  int Favorite { get { return favorite; } set { favorite = value; } }

    public void SetCell(Image img, string str)
    {
        Thumbnail.sprite = img.sprite;
        WorldText.text = str;
    }

    public void GetCell()
    {

         WorldManager.Instance.ChooseData = this;
         WorldManager.Instance.SetSelect();
    }

    public void SetData(WorldData data)
    {

        ID = data.ID;
        WorldName = data.WorldName;
        MoveType = data.MoveType;
    }
    public void Init()
    {
    
    }
}
