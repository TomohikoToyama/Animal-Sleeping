﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class GameStateManager : MonoBehaviour
    {
    public int language;    //0 = 日本語, 1 = English
            GameObject Animal;
            GameObject World;
            //一度に複数のメニューが出ないよう制御
            public enum SELECT
            {   
                NONE    = 0,
                ANIMAL  = 1,
                OPTION  = 2,
                WORLD   = 3,
                ROOM    = 4

            }

            public enum MODE {
                NORMAL = 0,
                GAME   = 1

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
    private GameObject worldSet;
    private GameObject animalSet;
    private GameObject gameSet;

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
        if (SceneManager.GetActiveScene().name == SCENE.Menu.ToString() )
            CurrentScene = (int)SCENE.Menu;
        if (SceneManager.GetActiveScene().name == SCENE.World.ToString())
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
        if (SceneManager.GetActiveScene().name == SCENE.Menu.ToString())
        {
            CurrentScene = (int)SCENE.Menu;
            animalSet = GameObject.FindGameObjectWithTag("AnimalSetting");
            worldSet = GameObject.FindGameObjectWithTag("WorldSetting");
            AnimalManager.Instance.Init();
            WorldManager.Instance.Init();
            animalSet.SetActive(true);
            worldSet.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == SCENE.World.ToString())
            CurrentScene = (int)SCENE.World;

            SceneManager.activeSceneChanged += OnActiveSceneChanged;
            SoundManager.Instance.PlayBGM(0);
        }

    // シーン遷移後に読み込む
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        ControllerManager.Instance.Init();
        if (CurrentScene == (int)SCENE.Menu)
        {
            animalSet = GameObject.FindGameObjectWithTag("AnimalSetting");
            worldSet = GameObject.FindGameObjectWithTag("WorldSetting");
            AnimalManager.Instance.Init();
            WorldManager.Instance.Init();
            animalSet.SetActive(true);
            worldSet.SetActive(false);
            ControllerManager.Instance.FadeIn();
        }
        else if (CurrentScene == (int)SCENE.World)
        {
            WorldManager.Instance.Init();
            AnimalManager.Instance.Init();
            ControllerManager.Instance.FadeIn();
        }
    }

    //動物選択
    public void SelectAnimal()
    {
        animalSet.SetActive(false);
        worldSet.SetActive(true);
    }

    //動物選択に戻る
    public void BackAnimal()
    {
        animalSet.SetActive(true);
        worldSet.SetActive(false);
    }

    //おでかけ先選択
    public void SelectWorld()
    {
        
    }

    //ゲーム選択
    public void SelectGame()
    {

    }
}
