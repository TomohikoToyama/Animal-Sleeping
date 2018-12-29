using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalData : MonoBehaviour {

    public Image Thumbnail;
    public Text  NameText;
    //動物の状態
    private int state;
    public int State { get { return state; } set { state = value ; } }
    //動物が選択済みメニュー開き用
    private bool selected;
    public bool Selected { get { return selected; } set { selected = value; } }
    //動物の選択コマンド
    public Hashtable Command { get; private set; }
    //動物のカテゴリ
    private int category;
    public int Category { get { return category; } set { category = value; } }
    //種族のID
    public int AID { get; private set; }
    //個体のID
    public int id { get; private set; }
    public int ID { get { return id; } set { id = value; } }
    //動物種族名
    private string animalName;
    public string AnimalName { get { return animalName; } set { animalName = value; } }
    //ニックネーム
    public string NickName { get; private set; }
    //水陸空移動
    public int moveType { get; private set; }
    public int MoveType { get { return moveType; } set { moveType = value; } }

    public void SetData(AnimalData data)
    {
        Category   = data.Category;
        AID        = data.AID;
        ID         = data.ID;
        AnimalName = data.AnimalName;
        MoveType   = data.MoveType;
    }

    public void SetCell(Image img ,string str)
    {
        Thumbnail.sprite = img.sprite;
        NameText.text    = str;
        Debug.Log(NameText.text);
    }

    public void GetCell()
    {
       
        AnimalManager.Instance.UseData = this;
        AnimalManager.Instance.SetSelect();
    }


}
