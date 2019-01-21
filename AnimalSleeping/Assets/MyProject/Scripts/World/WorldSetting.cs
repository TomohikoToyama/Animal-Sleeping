using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSetting : MonoBehaviour {

    private string folder = "Images/World/";
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public List<WorldData> DataList = new List<WorldData>();
    public WorldData SelectedData;
    public WorldData ChooseData;
    public Sprite[] thumbnail = new Sprite[6];
    private BoxCollider col;
    public Text pageNum;
    public GameObject prevButton;
    public GameObject nextButton;
    public int dataNum = 6;
    private int cellNum = 6;
    // Use this for initialization
    void Start () {
        TestSet();
        WorldManager.Instance.UseData = SelectedData;
        col = GetComponent<BoxCollider>();
    }
    public enum SE
    {
        HIT = 0
    }
    private void TestSet()
    {
        DataList[0].ID = "1";
        DataList[0].WorldName = "サッカースタジアム";
        DataList[1].ID = "2";
        DataList[1].WorldName = "うみ";
        DataList[2].ID = "3";
        DataList[2].WorldName = "まち";
        DataList[3].ID = "4";
        DataList[3].WorldName = "チェス";
        DataList[4].ID = "5";
        DataList[4].WorldName = "  わしつ";
        DataList[5].ID = "6";
        DataList[5].WorldName = "おかしのまち";
        
        SelectedData.ID = "1";
        SelectedData.WorldName = "サッカースタジアム";
    }

    public void SetDataList(List<string[]> datas, int page)
    {
        pageNum.text = page.ToString();
        if (page == 1)
        {
            dataNum = cellNum;
        }
        else
        {
            dataNum = datas.Count - ((page - 1) * cellNum);
        }
        Debug.Log("今のページ" + page);

        for (int i = 0; i < dataNum; i++)
        {
            DataList[i].ID = datas[i + (page - 1) * cellNum][1];
            DataList[i].WorldName = datas[i + (page - 1) * cellNum][2];
            DataList[i].MoveType = int.Parse(datas[i + (page - 1) * cellNum][3]);
            // DataList[i].Fa = datas[i + (page - 1) * cellNum][2];
            string path = folder +  DataList[i].ID;
            thumbnail[i] = Resources.Load<Sprite>(path);
            DataList[i].Apear();
            DataList[i].SetCell(thumbnail[i], DataList[i].WorldName);
        }
        //もし該当ページにデータが6個なかった場合は、ないデータ分のパネルを非表示にする
        if (dataNum < cellNum)
        {
            for (int i = dataNum; i < cellNum; i++)
            {
                DataList[i].DisApear();
            }
        }

    }
    public void OpenCloseMenu()
    {
        if (!setMenu.activeSelf)
        {
            setMenu.SetActive(true);
            col.enabled = false;
        }
        else if (setMenu.activeSelf)
        {
            setMenu.SetActive(false);
            col.enabled = true;
        }
    }
    public void ChangePage(int num, int max)
    {
        if (num == 1)
        {
            prevButton.SetActive(false);
        }
        if (num > 1)
        {
            prevButton.SetActive(true);
        }
        if (num < max)
        {
            nextButton.SetActive(true);
        }
        if (num == max)
        {
            nextButton.SetActive(false);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
          //  SoundManager.Instance.PlaySE((int)SE.HIT);
        
    }
}
