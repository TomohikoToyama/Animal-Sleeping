using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayManager : MonoBehaviour
{
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    //シングルトン化のおまじない
    protected static PlayManager instance;
    public static PlayManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (PlayManager)FindObjectOfType(typeof(PlayManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

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
        setObj = GameObject.FindGameObjectWithTag("PlaySetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu = setCanvas.transform.Find("Panel").gameObject;
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