using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSetting : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public List<WorldData> DataList = new List<WorldData>();
    public WorldData SelectedData;
    public WorldData ChooseData;
    // Use this for initialization
    void Start () {
        TestSet();
        WorldManager.Instance.UseData = SelectedData;
    }
    private void TestSet()
    {
        DataList[0].ID = 1;
        DataList[0].WorldName = "サッカースタジアム";
        DataList[1].ID = 2;
        DataList[1].WorldName = "ひつじ";
        DataList[2].ID = 3;
        DataList[2].WorldName = "にわとり";
        DataList[3].ID = 4;
        DataList[3].WorldName = "さけ";
        DataList[4].ID = 5;
        DataList[4].WorldName = "ワニ";
        DataList[5].ID = 6;
        DataList[5].WorldName = "ワイバーン";
        
        SelectedData.ID = 1;
        SelectedData.WorldName = "サッカースタジアム";
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
