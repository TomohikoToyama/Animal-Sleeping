using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public List<AnimalData> DataList = new List<AnimalData>();
    public AnimalData SelectedData;
    public AnimalData ChooseData;
    public Sprite SelThumbnail;
    public string SelName;
    //シングルトン化のおまじない
    protected static AnimalManager instance;
    public static AnimalManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (AnimalManager)FindObjectOfType(typeof(AnimalManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    // Use this for initialization
    void Start () {
        TestSet();
        InitManager();

    }

    public  void SetSelect()
    {
        SelectedData.SetData(ChooseData);
        SelectedData.SetCell(ChooseData.Thumbnail,ChooseData.AnimalName);
   
    } 
	
    private void TestSet()
    {
        DataList[0].Category   = 100;
        DataList[0].ID         = 1;
        DataList[0].AnimalName = "ぞう";
        DataList[1].Category   = 100;
        DataList[1].ID         = 3;
        DataList[1].AnimalName = "ひつじ";
        DataList[2].Category   = 200;
        DataList[2].ID         = 1;
        DataList[2].AnimalName = "にわとり";
        DataList[3].Category   = 300;
        DataList[3].ID         = 1;
        DataList[3].AnimalName = "さけ";
        DataList[4].Category   = 500;
        DataList[4].ID         = 1;
        DataList[4].AnimalName = "ワニ";
        DataList[5].Category   = 700;
        DataList[5].ID         = 1;
        DataList[5].AnimalName = "ワイバーン";

        SelectedData.Category = 100;
        SelectedData.ID = 1;
        SelectedData.AnimalName = "ぞう";
    }
	
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("AnimalSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu   = setCanvas.transform.Find("Panel").gameObject;
        setMenu   = setCanvas.transform.Find("Panel").gameObject;
    }

    public void OpenCloseMenu()
    {
        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.SetActive(true);

        if (GameStateManager.Instance.currentMenu != 0)
        {
            GameStateManager.Instance.currentMenu = 0;
            setMenu.SetActive(false);
        }
    }
}
