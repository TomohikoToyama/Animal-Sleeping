using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagers : MonoBehaviour {
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public RoomSetting RSetting;
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

        Init();

    }
    
    private void Init()
    {
        if (GameStateManager.Instance.CurrentScene == 1)
            RSetting = GameObject.FindGameObjectWithTag("RoomSetting").GetComponent<RoomSetting>();
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
