using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalSetting : MonoBehaviour {

    private string folder = "Images/Animal/";   //サムネイル用フォルダパス
    public GameObject setObj;                   //
    public GameObject setCanvas;
    public GameObject setMenu;
    public Text pageNum;
    public GameObject prevButton;               //戻るボタン
    public GameObject nextButton;               //次へボタン
    public Sprite[] thumbnail = new Sprite[6];  //動物サムネイル格納、1度に6体分
    public List<AnimalData> DataList = new List<AnimalData>();  //動物データ
    public AnimalData SelectedData;             //選択した動物データ
    public int dataNum  = 6;                    //動物のデータ数
    private int cellNum = 6;                    //セルの数
    public Sprite clear;                        //ページ余り分の非表示用画像
    private BoxCollider col;                    //
    // Use this for initialization
    void Start () {
        DefaultSet();
        AnimalManager.Instance.UseData = SelectedData;
        prevButton.SetActive(false);
        col = GetComponent<BoxCollider>();
    }
    public enum SE
    {
        HIT = 0
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
        
        for(int i = 0; i < dataNum; i++)
        {
            DataList[i].Category    = datas[i + (page - 1) * cellNum][0];
            DataList[i].ID          = datas[i + (page - 1) * cellNum][1];
            DataList[i].AnimalName  = datas[i + (page - 1) * cellNum][2];
            DataList[i].EngName     = datas[i + (page - 1) * cellNum][3];
            DataList[i].MoveType    = int.Parse(datas[i + (page - 1) * cellNum][4]);
            // DataList[i].Fa = datas[i + (page - 1) * cellNum][2];
            string path = folder + DataList[i].Category + "/" + DataList[i].ID;
            thumbnail[i] = Resources.Load<Sprite>(path);
            DataList[i].Apear();
            if (GameStateManager.Instance.language == 0)
            {
                DataList[i].SetCell(thumbnail[i], DataList[i].AnimalName);
            }
            else if (GameStateManager.Instance.language == 1)
            {
                DataList[i].SetCell(thumbnail[i], DataList[i].EngName);
            }
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
    public void SetLanguageName(List<string[]> datas, int page)
    {
        pageNum.text = page.ToString();

        for (int i = 0; i < dataNum; i++)
        {
            DataList[i].AnimalName = datas[i + (page - 1) * cellNum][2];
            DataList[i].EngName = datas[i + (page - 1) * cellNum][3];
            if (GameStateManager.Instance.language == 0)
                DataList[i].SetCell(thumbnail[i], DataList[i].AnimalName);
            else if (GameStateManager.Instance.language == 1)
                DataList[i].SetCell(thumbnail[i], DataList[i].EngName);
        }

    }

    private void DefaultSet()
    {
        SelectedData.Category = "100";
        SelectedData.ID = "1";
        SelectedData.AnimalName = "ぞう";
    }

    //ページを変更時に必要に応じてボタンを表示非表示にする
    public void ChangePage(int num,int max)
    {
        //1ページ目なら前ボタンを消す
        if (num == 1)
        {
            prevButton.SetActive(false);
        }
        //1ページ超過のページ数なら前ボタン表示
        else if (num > 1)
        {
            prevButton.SetActive(true);
        }
        //最大ページ数未満なら次ボタン表示
        if (num < max)
        {
            nextButton.SetActive(true);
        }
        //最大ページ数なら次ボタン非表示
        else if (num == max)
        {
            nextButton.SetActive(false);
        }

    }

    //パネルの表示非表示
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
}
