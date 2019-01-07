using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameStateManager : MonoBehaviour
    {
            GameObject Animal;
            GameObject World;
            //一度に複数のメニューが出ないよう制御
            public enum SELECTMENU
            {   
                NONE    = 0,
                ANIMAL  = 1,
                OPTION  = 2,
                WORLD   = 3,
                ROOM    = 4

            }
        
            public int currentMenu;
            //シングルトン化のおまじない
            protected static GameStateManager instance;
            public static GameStateManager Instance
            {

                get
                {
                    if (instance == null)
                    {
                        instance = (GameStateManager)FindObjectOfType(typeof(GameStateManager));

                        if (instance == null)
                        {
                            Debug.LogError("SoundManager Instance Error");

                        }
                    }

                    return instance;
                }

            }

        public int playerID;
        public enum SCENE
        {
            Title = 0,
            Menu  = 1,
            World = 2
        }
    [SerializeField]
    private int currentScene;
        public  int CurrentScene
        {
            get { return currentScene ; }
            set { currentScene = value; }
        }
        private void Awake()
        {
        if (SceneManager.GetActiveScene().name == "Menu")
            CurrentScene = (int)SCENE.Menu;
        if (SceneManager.GetActiveScene().name == "World")
            CurrentScene = (int)SCENE.World;
        GameObject[] obj = GameObject.FindGameObjectsWithTag("GameStateManager");
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

        // Use this for initialization
        void Start()
        {
        if (SceneManager.GetActiveScene().name == "Menu")
            CurrentScene = (int)SCENE.Menu;
        if (SceneManager.GetActiveScene().name == "World")
            CurrentScene = (int)SCENE.World;

            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;

            SoundManager.Instance.PlayBGM(0);
        }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        ControllerManager.Instance.Init();
        if (CurrentScene == 1)
        {
            AnimalManager.Instance.Init();
            WorldManager.Instance.Init();
        }else if (CurrentScene == 2)
        {
            WorldManager.Instance.Init();
            AnimalManager.Instance.Init();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // ControllerManager.Instance.FadeOut();
        Debug.Log(scene.name + " scene loaded");
    }

    void OnSceneUnloaded(Scene scene)
    {
       // ControllerManager.Instance.FadeIn();
        Debug.Log(scene.name + " scene unloaded");
    }
    /*
   // Update is called once per frame
   void Update()
       {

       //タイトルシーン
       if (currentScene == (int)SCENE.TITLE) {

           //メニューに入る
           if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
           {
               currentScene = (int)SCENE.MENU;
               SceneManager.LoadScene("Menu");
           }
/

       }


       //メニューシーン
       if (currentScene == (int)SCENE.Menu)
       {
           //if(WorldManager.Instance

       }

       //おでかけシーン
       if(currentScene == (int)SCENE.World)
       {

       }
        
    }
    */
}
