using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionManager : MonoBehaviour {
    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    public OptionSetting OSetting;
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
        //     InitManager();
        
    }

    private void Init()
    {
        OSetting = GameObject.FindGameObjectWithTag("OptionSetting").GetComponent<OptionSetting>();
    }

    public void OpenCloseMenu()
    {
        OSetting.OpenCloseMenu();
    }
}
