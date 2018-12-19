using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameStateManager : MonoBehaviour
    {
            //一度に複数のメニューが出ないよう制御
            public enum SELECTMENU
            {   
                NONE    = 0,
                ANIMAL  = 1,
                OPTION  = 2,
                PLAY    = 3,
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

        public int playerID = 1;
        public enum SCENE
        {
            TITLE = 0,
            MENU  = 1,
            PLAY = 2
        }
        private int currentScene;
        public  int CurrentScene
        {
            get { return currentScene ; }
            set { currentScene = value; }
        }
        private void Awake()
        {

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
            currentScene = 1;
            SoundManager.Instance.PlayBGM(0);
        }

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

                //すぐ入る
                //
                /*
                if ()
                */

            }

            //メニューシーン
            if (currentScene == (int)SCENE.MENU)
            {

            }

            //おでかけシーン
            if(currentScene == (int)SCENE.PLAY)
            {

            }

        }
    }
