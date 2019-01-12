using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalData : MonoBehaviour {


    public Image Thumbnail;
    public Text  NameText;
    //足音
    public AudioSource foot;
    //鳴き声
    public AudioSource voice;

    /*
     * ごはん上げる時や触る時の反応具合に影響する
     * 0 = なし 
     * 1 = 臆病
     * 2 = 懐っこい
     * 3 = 気まぐれ
     * 
    */
    //性格
    public int personality;

    //動物の状態
    private int state = 99;
    public int State { get { return state; } set { state = value ; } }
    //動物が選択済みメニュー開き用
    private bool selected;
    public bool Selected { get { return selected; } set { selected = value; } }
    //動物の選択コマンド
    public Hashtable Command { get; private set; }
    //動物のカテゴリ
    private string category;
    public string Category { get { return category; } set { category = value; } }
    //種族のID
    public string AID { get; private set; }
    //個体のID
    public string id;
    public string ID { get { return id; } set { id = value; } }
    //動物種族名
    private string animalName;
    public string AnimalName { get { return animalName; } set { animalName = value; } }
    //ニックネーム
    public string NickName { get; private set; }
    //水陸空移動
    private int moveType;
    public int MoveType { get { return moveType; } set { moveType = value; } }

    //大きさ
    private int size;
    public  int Size { get { return size; } set { size = value; } }

    public void SetData(AnimalData data)
    {
        Category   = data.Category;
        //AID        = data.AID;
        ID         = data.ID;
        AnimalName = data.AnimalName;
        MoveType   = data.MoveType;
    }

    public enum SE
    {
        HIT = 0
    }
    public void SetCellData()
    {

    }
    public void SetCell(Sprite img ,string str)
    {
        Thumbnail.sprite = img;
        NameText.text    = str;
        Debug.Log(NameText.text);
    }

    public void GetCell()
    {
       
        AnimalManager.Instance.UseData = this;
        AnimalManager.Instance.SetSelect();
    }

    public void Apear()
    {
        gameObject.SetActive(true);

    }

    public void DisApear()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "AnimalButton")
        {
            gameObject.GetComponent<Image>().color = new Color(125f/255f,150f/255f,255f/255f);
            SoundManager.Instance.PlaySE((int)SE.HIT);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (this.tag == "AnimalButton")
        {
            gameObject.GetComponent<Image>().color = new Color(1,1,1);
        }

    }
}
