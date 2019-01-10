using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldData : MonoBehaviour {
    private int id;
    public  int ID { get { return id; } set { id = value; } }
    public Image Thumbnail;
    public Text WorldText;
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
    public enum SE
    {
        HIT = 0
    }
    public void GetCell()
    {

        Debug.Log("test");
         WorldManager.Instance.UseData = this;
         WorldManager.Instance.SetSelect();
    }

    public void SetData(WorldData data)
    {

        ID = data.ID;
        WorldName = data.WorldName;
        MoveType = data.MoveType;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "WorldButton")
        {
            gameObject.GetComponent<Image>().color = new Color(125f, 150f, 255f, 255f);
            SoundManager.Instance.PlaySE((int)SE.HIT);
        }

    }
}
