using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SleepingAnimal
{
    public class GameStateManager : MonoBehaviour
    {
        enum SCENE
        {
            TITLE = 0,
            MENU  = 1,
            ROOM  = 2
        }
        private int currentScene;
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
            currentScene = 0;
            SoundManager.Instance.PlayBGM(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                
                    SceneManager.LoadScene("Menu");
                
            }
        }
    }
}