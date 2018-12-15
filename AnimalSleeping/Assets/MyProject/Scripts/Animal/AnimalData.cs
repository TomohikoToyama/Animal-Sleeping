using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalData : MonoBehaviour {

    
    //動物の状態
    private int state;
    public int State
    {
        get { return state; }
        set { state = value; }
    }
    //動物が選択済みメニュー開き用
    private bool selected;
    public bool Selected
    {
        set { selected = value; }
        get { return selected; }
    }

    //動物の選択コマンド
    private Hashtable command;
    public Hashtable Command
    {
        set { command = value; }
        get { return command; }
    }

    //動物のカテゴリ
    private int category;
    public int Category
    {
        set { category = value; }
        get { return category; }
    }

    //動物のID
    private int anmID;
    public int AnmID
    {
        set { anmID = value; }
        get { return anmID; }
    }

    //動物種族名
    private string nameJPN;
    public string NameJPN
    {
        set { nameJPN = value; }
        get { return nameJPN; }
    }

    //ニックネーム
    private string nickName;
    public string NickName
    {
        set { nickName = value; }
        get { return nickName; }
    }

    //水陸空移動
    private int moveType;
    public int MoveType
    {
        set { moveType = value; }
        get { return moveType; }
    }

}
