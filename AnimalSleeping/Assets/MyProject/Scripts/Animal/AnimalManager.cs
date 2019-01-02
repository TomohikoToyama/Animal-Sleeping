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
    private AnimalController ACon;
    private AnimalCreator ACreator;
    private FoodCreator FCreator;
    public AnimalSetting ASetting;
    public AnimalData UseData;
    public AnimalData ChooseData;
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
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        if (GameStateManager.Instance.CurrentScene == 1) { 
            
            ASetting = GameObject.FindGameObjectWithTag("AnimalSetting").GetComponent<AnimalSetting>();
           // UseData = ASetting.ChooseData ;
        }
        if (GameStateManager.Instance.CurrentScene == 2) {
            ACreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<AnimalCreator>();
            FCreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<FoodCreator>();
            
        }
    }

    public void SetSelect()
    {

        ASetting.SelectedData.SetCell(UseData.Thumbnail, UseData.AnimalName);
        
    } 
	
    public void AnimalCreate()
    {
        ACreator.Create(UseData.Category.ToString(), UseData.ID.ToString());
        ACon = GameObject.FindGameObjectWithTag("Animal").GetComponent<AnimalController>();
    }

 
    
	/*
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("AnimalSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu   = setCanvas.transform.Find("Panel").gameObject;
        setMenu   = setCanvas.transform.Find("Panel").gameObject;
    }
    */
    public void OpenCloseMenu()
    {
        ASetting.OpenCloseMenu();
    }
    
    public void Command(int com)
    {
        if(com == (int)COMMAND.Call)
        {
            ACon.StateChange(com);
        }

        if(com == (int)COMMAND.Eat)
        {
            FCreator.Create("2");
        }
    }
}
