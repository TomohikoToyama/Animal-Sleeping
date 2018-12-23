using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldManager : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
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

    
    public void ChangeWorld()
    {
        GameStateManager.Instance.CurrentScene = 2;
        SceneManager.LoadSceneAsync("World");
        SoundManager.Instance.PlayBGM(0);
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
