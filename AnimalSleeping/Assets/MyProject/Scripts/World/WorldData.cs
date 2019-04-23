using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldData : MonoBehaviour {
    private string id;
    public  string ID { get { return id; } set { id = value; } }
    public Image Thumbnail;
    public Text WorldText;

    private string worldName;
    public  string WorldName { get { return worldName; } set { worldName = value; } }
    private int moveType;
    public  int MoveType { get { return moveType; } set { moveType = value; } }
    private int favorite;
    public  int Favorite { get { return favorite; } set { favorite = value; } }

    private void Start()
    {
        //水中のワールドの場合、重力を変更
        if(gameObject.tag == "Water")
        {
            GameObject.FindGameObjectWithTag("Animal").GetComponent<Rigidbody>().useGravity = false;
        }
    }
    public void SetCell(Sprite img, string str)
    {
        Thumbnail.sprite = img;
        WorldText.text = str;
    }
 
    public void GetCell()
    {
        WorldManager.Instance.UseData = this;
        WorldManager.Instance.SetSelect();
    }

    /*
     * セルから取得したワールドデータを設定する
     * ワールドのIDとワールド名と移動タイプ
     * 
    */
    public void SetData(WorldData data)
    {
        ID = data.ID;
        WorldName = data.WorldName;
        MoveType = data.MoveType;
    }

    //表示にする処理
    public void Apear()
    {
        gameObject.SetActive(true);

    }

    //非表示にする処理
    public void DisApear()
    {
        gameObject.SetActive(false);
    }
}
