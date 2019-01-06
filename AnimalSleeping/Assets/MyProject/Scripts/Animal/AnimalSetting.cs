using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalSetting : MonoBehaviour {

    private string folder = "Images/Animal/";
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public Text pageNum;
    public GameObject prevButton;
    public GameObject nextButton;
    public Sprite[] thumbnail = new Sprite[6];
    public List<AnimalData> DataList = new List<AnimalData>();
    public AnimalData SelectedData;
    public AnimalData ChooseData;
    public int dataNum  = 6;
    private int cellNum = 6;
    public Sprite clear;
    // Use this for initialization
    void Start () {
        TestSet();
        ChooseData = DataList[0];
        AnimalManager.Instance.UseData = SelectedData;
        prevButton.SetActive(false);
    }
	
    public void SetDataList(List<string[]> datas,int page)
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
        
        for(int i = 0; i < dataNum; i++)
        {
            DataList[i].Category    = datas[i + (page - 1) * cellNum][0];
            DataList[i].ID          = datas[i + (page - 1) * cellNum][1];
            DataList[i].AnimalName  = datas[i + (page - 1) * cellNum][2];
            DataList[i].MoveType    = int.Parse(datas[i + (page - 1) * cellNum][3]);
            // DataList[i].Fa = datas[i + (page - 1) * cellNum][2];
            string path = folder + DataList[i].Category + "/" + DataList[i].ID;
            thumbnail[i] = Resources.Load<Sprite>(path);
            DataList[i].Apear();
            DataList[i].SetCell(thumbnail[i], DataList[i].AnimalName);
        }
        //もし該当ページにデータが6個なかった場合は、ないデータ分のパネルを非表示にする
        if(dataNum < cellNum)
        {
            for(int i = dataNum; i < cellNum; i++)
            {
                DataList[i].DisApear();
            }
        }

    }


	private void TestSet()
    {
      
        SelectedData.Category = "100";
        SelectedData.ID = "1";
        SelectedData.AnimalName = "ぞう";
    }
    public void ChangePage(int num,int max)
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
    public void OpenCloseMenu()
    {
        if (!setMenu.activeSelf)
            setMenu.SetActive(true);

        else if (setMenu.activeSelf)
            setMenu.SetActive(false);
    }

 }
