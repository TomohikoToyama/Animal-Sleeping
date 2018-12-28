using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldManager : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public List<WorldData> DataList = new List<WorldData>();
    public WorldData SelectedData;
    public WorldData ChooseData;

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
    void Start()
    {

        InitManager();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("WorldSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu = setCanvas.transform.Find("Panel").gameObject;
    }



    public void SetSelect()
    {
        SelectedData.SetData(ChooseData);
        SelectedData.SetCell(ChooseData.Thumbnail, ChooseData.WorldName);

    }
    public void ChangeWorld()
    {
        GameStateManager.Instance.CurrentScene = 2;
        
        SceneManager.LoadSceneAsync("World");
        if (SceneManager.GetActiveScene().name == "World")
            AnimalManager.Instance.AnimalCreate();
        SoundManager.Instance.PlayBGM(0);
    }

    public void BackRoom()
    {
        GameStateManager.Instance.CurrentScene = 1;
        
        AnimalManager.Instance.AnimalCreate();
        SoundManager.Instance.PlayBGM(0);
        
            SceneManager.LoadSceneAsync("Menu");
    }
    public void OpenCloseMenu()
    {
        //GameStateManager.Instance.CurrentScene = 2;
        //SceneManager.LoadScene("Play");

        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.SetActive(true);

        if (GameStateManager.Instance.currentMenu != 0)
        {
            GameStateManager.Instance.currentMenu = 0;
            setMenu.SetActive(false);
        }
    }
}
