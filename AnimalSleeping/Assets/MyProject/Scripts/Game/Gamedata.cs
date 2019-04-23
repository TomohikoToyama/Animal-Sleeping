using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamedata : MonoBehaviour {

    public Image Thumbnail;
    public Text NameText;

    private int difficult;
    public int Difficult { get { return difficult; } set { difficult = value; } }


    //動物のカテゴリ
    private string category;
    public string Category { get { return category; } set { category = value; } }

    //ワールドのID
    private string wid;
    public string WID { get { return wid; } set { wid = value; } }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
