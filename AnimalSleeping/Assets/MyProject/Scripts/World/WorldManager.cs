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
    private GameObject playerObj;
    private GameObject animalObj;
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

    //初期化処理
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


    //選択済みパネルに選択した情報を表示する
    public void SetSelect()
    {  
        WSetting.SelectedData.SetCell(UseData.Thumbnail.sprite, UseData.WorldName);
        worldID = UseData.ID;
    }

    //ワールドを生成する
    public void Create()
    {
        WCreator.Create(worldID.ToString());
    }

    //ワールド遷移時にフェードアウトの演出を入れる
    public void ChangeWorld()
    {
        ControllerManager.Instance.FadeOut();
        StartCoroutine(ChangeWait());
       
    }

    private IEnumerator ChangeWait()
    {
        yield return new WaitForSeconds(0.6f);
        GameStateManager.Instance.CurrentScene = 2;
        SceneManager.LoadSceneAsync("World");
        SoundManager.Instance.PlayBGM(0);
    }

    //ルームに戻る
    public void BackRoom()
    {
        GameStateManager.Instance.CurrentScene = 1;
        SoundManager.Instance.PlayBGM(0);
        SceneManager.LoadSceneAsync("Menu");
    }

    //ワールド設定パネルを開閉する
    public void OpenCloseMenu()
    {
        WSetting.OpenCloseMenu();
    }

    //動物とプレイヤ―の位置をセットする
    public void PositionSet()
    {
        if(playerObj == null)
        playerObj = GameObject.FindGameObjectWithTag("Player");
        if(animalObj == null)
        animalObj = GameObject.FindGameObjectWithTag("Animal");

        playerObj.transform.position = new Vector3(1,1,1);
        animalObj.transform.position = new Vector3(-1, animalObj.transform.position.y, -1);
    }
}
