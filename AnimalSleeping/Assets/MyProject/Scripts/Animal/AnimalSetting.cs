using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSetting : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public List<AnimalData> DataList = new List<AnimalData>();
    public AnimalData SelectedData;
    public AnimalData ChooseData;
    // Use this for initialization
    void Start () {
        TestSet();
        ChooseData = DataList[0];
        AnimalManager.Instance.UseData = SelectedData;
    }
	
	private void TestSet()
    {
        DataList[0].Category = 100;
        DataList[0].ID = 1;
        DataList[0].AnimalName = "ぞう";
        DataList[1].Category = 100;
        DataList[1].ID = 3;
        DataList[1].AnimalName = "ひつじ";
        DataList[2].Category = 200;
        DataList[2].ID = 1;
        DataList[2].AnimalName = "にわとり";
        DataList[3].Category = 300;
        DataList[3].ID = 1;
        DataList[3].AnimalName = "さけ";
        DataList[4].Category = 500;
        DataList[4].ID = 1;
        DataList[4].AnimalName = "ワニ";
        DataList[5].Category = 700;
        DataList[5].ID = 1;
        DataList[5].AnimalName = "ワイバーン";

        SelectedData.Category = 100;
        SelectedData.ID = 1;
        SelectedData.AnimalName = "ぞう";
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
