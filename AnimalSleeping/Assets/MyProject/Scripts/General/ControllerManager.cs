using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {

    public GameObject cameraObj;
    public GameObject Menu;
    public RoomUserController RCon;
    public WorldUserController    WCon;
    public Image fade;
    Color color;

   // color.a = 0.5f;
//renderer.material.color = color;
	// Use this for initialization
	void Start () {
        Init();

    }

 
    public void Init()
    {
        color = fade.color;
        if (GameStateManager.Instance.CurrentScene == 1)
        {
            RCon.enabled = true;
            RCon.Init();
            WCon.enabled = false;
        }

        if (GameStateManager.Instance.CurrentScene == 2)
        {
            RCon.enabled = false;
            WCon.enabled = true;
            WCon.Init();
            FadeOut();
        }
    }
    //シングルトン化のおまじない
    protected static ControllerManager instance;
    public static ControllerManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (ControllerManager)FindObjectOfType(typeof(ControllerManager));

                if (instance == null)
                {
                    Debug.LogError("WorldManager Instance Error");

                }
            }

            return instance;
        }

    }
    private void Awake()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
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
    public void FadeOut()
    {
        color.a = 255;

    }

    public void FadeIn()
    {
        color.a = 255;


    }

    public void CloseMenu()
    {
        WCon.Close();
    }
}
