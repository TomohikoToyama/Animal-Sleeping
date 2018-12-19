using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour {
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;

    //一度に複数のメニューが出ないよう制御
    public enum SELECTMENU
    {
        NONE = 0,
        ANIMAL = 1,
        GENERAL = 2,
        OPTION = 3,
        PLAY = 4,
        ROOM = 5
    }
    //シングルトン化のおまじない
    protected static OptionManager instance;
    public static OptionManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (OptionManager)FindObjectOfType(typeof(OptionManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    // Use this for initialization
    void Start () {
        InitManager();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("OptionSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu = setCanvas.transform.Find("Panel").gameObject;
    }

    public void OpenCloseMenu()
    {
        Debug.Log("adasa");
        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.SetActive(true);

        if (GameStateManager.Instance.currentMenu != 0)
        {
            Debug.Log("手sと");
            GameStateManager.Instance.currentMenu = 0;
            setMenu.SetActive(false);

        }
    }
}
