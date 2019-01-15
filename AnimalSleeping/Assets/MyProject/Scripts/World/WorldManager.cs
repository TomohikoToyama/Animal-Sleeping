using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldManager : MonoBehaviour {

    private WorldCreator WCreator;
    public List<WorldData> DataList = new List<WorldData>();
    public WorldData SelectedData;
    public WorldData UseData;
    public WorldSetting WSetting;
    public string worldID;
    //シングルトン化のおまじない
    protected static WorldManager instance;
    public static WorldManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (WorldManager)FindObjectOfType(typeof(WorldManager));

                if (instance == null)
                {
                    Debug.LogError("WorldManager Instance Error");

                }
            }

            return instance;
        }

    }
    private void Awake()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("WorldManager");
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
        if (GameStateManager.Instance.CurrentScene == 1)
        {
            WSetting = GameObject.FindGameObjectWithTag("WorldSetting").GetComponent<WorldSetting>();
            worldID = "1";
        }
        else if (GameStateManager.Instance.CurrentScene == 2)
        {
            WCreator = GameObject.FindGameObjectWithTag("ObjectSpawner").GetComponent<WorldCreator>();
            Create();
        }
    }



    public void SetSelect()
    {
        
        WSetting.SelectedData.SetCell(UseData.Thumbnail.sprite, UseData.WorldName);
        worldID = UseData.ID;
    }

    public void Create()
    {
        WCreator.Create(worldID.ToString());
    }
    public void ChangeWorld()
    {
        ControllerManager.Instance.FadeOut();
        GameStateManager.Instance.CurrentScene = 2;
        
        SceneManager.LoadSceneAsync("World");
        SoundManager.Instance.PlayBGM(0);
    }

    public void BackRoom()
    {
        GameStateManager.Instance.CurrentScene = 1;
        
        SoundManager.Instance.PlayBGM(0);
        
            SceneManager.LoadSceneAsync("Menu");
    }
    public void OpenCloseMenu()
    {
        WSetting.OpenCloseMenu();
    }
}
