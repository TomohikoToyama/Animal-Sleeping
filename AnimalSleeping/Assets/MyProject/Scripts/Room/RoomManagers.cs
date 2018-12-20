using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagers : MonoBehaviour {
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    //シングルトン化のおまじない
    protected static RoomManagers instance;
    public static RoomManagers Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (RoomManagers)FindObjectOfType(typeof(RoomManagers));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    // Use this for initialization
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
        setObj = GameObject.FindGameObjectWithTag("OptionSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
        setMenu   = setCanvas.transform.Find("Panel").gameObject;
    }

    //決定
    public void Decision()
    {

        OpenCloseMenu();
    }
    //キャンセル
    public void Cancel()
    {
        OpenCloseMenu();
    }

    public void OpenCloseMenu()
    {
        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.SetActive(true);

        if (GameStateManager.Instance.currentMenu != 0)
        {
            GameStateManager.Instance.currentMenu = 0;
            setMenu.SetActive(false);
        }
    }
}
