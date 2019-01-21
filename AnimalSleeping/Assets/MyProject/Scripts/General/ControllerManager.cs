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
    float alpha;
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
        StartCoroutine(OutEffect());
        //fade.color = new Color(0, 0, 0, 1);

    }

    public void FadeIn()
    {
        StartCoroutine(InEffect());
//        fade.color = new Color(0, 0, 0, 0);


    }
    private IEnumerator OutEffect()
    {
        while (alpha < 1f)
        {
            fade.color = new Color(0, 0, 0, alpha);
            alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        alpha = 1;
    }

    private IEnumerator InEffect()
    {

        while (alpha > 0)
        {
            fade.color = new Color(0, 0, 0, alpha);
            alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        alpha = 0;
    }


    public void CloseMenu()
    {
        WCon.Close();
    }
}
