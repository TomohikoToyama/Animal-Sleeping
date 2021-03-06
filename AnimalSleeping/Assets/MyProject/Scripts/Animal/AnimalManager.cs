﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AnimalManager : MonoBehaviour {
    public enum COMMAND
    {
        Call = 0,
        Hangout = 1,
        Eat = 2,
        Change = 3,
        Sleep = 4,
        Close = 5

    }
    private AnimalController ACon;  //動物操作クラス
    private AnimalCreator ACreator; //動物生成クラス
    private FoodCreator FCreator;   //ごはん生成クラス
    private AnimalLoader ALoader;   //動物情報読込クラス
    public AnimalSetting ASetting;  //動物設定クラス
    public AnimalData UseData;      //おでかけする動物クラス
    public AnimalData ChooseData;
    public List<string[]> Datas = new List<string[]>();
    float panelNum = 6.0f;          //パネルの数
    int currentPage;
    int maxPage;
    private string UseCategory;
    private string UseID;
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
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("AnimalManager");
        if (obj.Length > 1)
        {
            // 既に存在しているなら削除
            Destroy(gameObject);
        }
        else
        {
            // 音管理はシーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
    }

    //動物の位置初期化処理
    public void PosReset()
    {
        ACon.PosReset();
    }
    private void Start()
    {
        Init();
    }

    //初期化処理
    public void Init()
    {
        //ルームに遷移したの時の初期化
        if (GameStateManager.Instance.CurrentScene == 1) {
            ASetting = GameObject.FindGameObjectWithTag("AnimalSetting").GetComponent<AnimalSetting>();

            if (ALoader == null)
            {
                ALoader = new AnimalLoader();
                // ALoader = GameObject.FindGameObjectWithTag("AnimalSetting").GetComponent<AnimalLoader>();
                Datas = ALoader.LoadData();
                maxPage = (int)Mathf.Ceil(Datas.Count / panelNum);
                currentPage = 1;
                ASetting.SetDataList(Datas, currentPage);

            }
            UseCategory = "100";
            UseID = "1";
            // UseData = ASetting.ChooseData ;
            // Datatest();
        }
        //おでかけ先に遷移した時の初期化
        else if (GameStateManager.Instance.CurrentScene == 2) {
            ACreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<AnimalCreator>();
            FCreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<FoodCreator>();
            AnimalCreate();
            
        }
    }

    public void ChangeLang()
    {

    }
    //動物の高さを取得
    public Vector3 GetTop()
    {
        return ACon.topSize;
    }

    //動物を乗せる
    public void Pick()
    {
        ACon.StateChange(99);
    }
    
   
    public void LoadData()
    {

    }


    public void SetPage(int num)
    {
        currentPage += num;
    }

    // ページ切替処理
    public void ChangePage()
    {
        ASetting.ChangePage(currentPage, maxPage);
        ASetting.SetDataList(Datas, currentPage);

    }
    // 言語切替処理
    public void ChangeLanguage()
    {
        ASetting.ChangePage(currentPage, maxPage);
        ASetting.SetLanguageName(Datas, currentPage);

    }
    //ルームでの処理
    #region
    //ルームでのメニューを開閉する
    public void OpenCloseMenu()
    {
        ASetting.OpenCloseMenu();
    }

    //選択した動物さんを選択済みパネルに反映する
    public void SetSelect()
    {
        UseCategory = UseData.Category;
        UseID = UseData.ID;
        //言語設定が日本語なら日本語名で表示
        if (GameStateManager.Instance.language == 0)
        {
              ASetting.SelectedData.SetCell(UseData.Thumbnail.sprite, UseData.AnimalName);
        }
        //言語設定が英語なら英語名で表示
        else if (GameStateManager.Instance.language == 1)
        {
            ASetting.SelectedData.SetCell(UseData.Thumbnail.sprite, UseData.EngName);
        }

        GameStateManager.Instance.SelectAnimal();
    }

    //動物選択パネルに戻る
    public void BackSelect()
    {
        GameStateManager.Instance.BackAnimal();
    }

    #endregion


    //おでかけ先での処理
    #region
    //動物を生成する。
    public void AnimalCreate()
    {
        ACreator.Create(UseCategory, UseID);
        ACon = GameObject.FindGameObjectWithTag("Animal").GetComponent<AnimalController>();
    }

    /*
     * 動物コマンド 
     * コマンドがEat以外の場合はAnimalControllerにコマンドに応じたStateにする
     * コマンドがEatの場合は、動物に応じたごはんを生成し動物のStateを食事にする
     */
    public void Command(int com)
    {
            ACon.StateChange(com);
    }

    public void InputUser(int num)
    {
        ACon.InputUser(num);
    }
    #endregion
}
