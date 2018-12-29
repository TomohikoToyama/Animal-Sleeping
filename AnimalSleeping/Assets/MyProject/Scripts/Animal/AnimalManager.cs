using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AnimalManager : MonoBehaviour {

    private AnimalCreator ACreator;
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
        if (GameStateManager.Instance.CurrentScene == 2)
            ACreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<AnimalCreator>();

    }

    public void SetSelect()
    {

        ASetting.SelectedData.SetCell(UseData.Thumbnail, UseData.AnimalName);
        
    } 
	
    public void Create()
    {
        ACreator.Create(UseData.Category.ToString(), UseData.ID.ToString());
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
    
}
