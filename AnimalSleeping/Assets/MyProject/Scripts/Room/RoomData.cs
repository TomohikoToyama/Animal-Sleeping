using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour {

    //部屋の状態
    private int state;
    public int State
    {
        get { return state; }
        set { state = value; }
    }
    //コマンドメニュー開き用
    private bool selected;
    public bool Selected
    {
        set { selected = value; }
        get { return selected; }
    }

    //部屋の選択コマンド
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

    //部屋のID
    private int roomID;
    public  int RoomID
    {
        set { roomID = value; }
        get { return roomID; }
    }

    //部屋名
    private string roomName;
    public string RoomName
    {
        set { roomName = value; }
        get { return roomName; }
    }

  
}
