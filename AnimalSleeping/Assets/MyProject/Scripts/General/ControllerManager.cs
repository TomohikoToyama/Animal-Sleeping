using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerManager : MonoBehaviour {

    public GameObject cameraObj;
    public GameObject Menu;
    public RoomUserController RCon;
    public WorldUserController WCon;
    public Image fade;
    float alpha;
    Color color;
    private enum SCENE
    {
        Menu  = 1,
        World = 2
    }


    //初期化処理群
    #region

    void Start() {
        Init();

    }

    //シーン毎の初期化処理
    public void Init()
    {
        color = fade.color;
        if (GameStateManager.Instance.CurrentScene == (int)SCENE.Menu)
        {
            RCon.enabled = true;
            RCon.Init();
            WCon.enabled = false;
        }


        if (GameStateManager.Instance.CurrentScene == (int)SCENE.World)
        {
            RCon.enabled = false;
            WCon.enabled = true;
            WCon.Init();
        }
    }

    #endregion

    //管理クラス用の仕込み
    #region

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
 
    #endregion


    //フェードインアウト演出
    #region

    //フェードアウト
    public void FadeOut()
    {
        StartCoroutine(OutEffect());
    }

    //フェードイン
    public void FadeIn()
    {
        StartCoroutine(InEffect());
    }

    //フェードアウト⇒フェードイン
    public void FadeAll()
    {
        StartCoroutine(AllEffect());
    }

    #endregion


    // コルーチン広場
    #region

    //フェードアウト演出
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

    //フェードアウト⇒フェードイン
    private IEnumerator AllEffect()
    {
        while (alpha < 1f)
        {
            fade.color = new Color(0, 0, 0, alpha);
            alpha += 0.1f;
            yield return new WaitForSeconds(0.001f);
        }
        alpha = 1;
        yield return new WaitForSeconds(1.5f);
        while (alpha > 0)
        {
            fade.color = new Color(0, 0, 0, alpha);
            alpha -= 0.1f;
            yield return new WaitForSeconds(0.001f);
        }
        alpha = 0;
    }

    #endregion


    public void CloseMenu()
    {
        WCon.Close();
    }
    public void Sleep()
    {
        WCon.currentMenu = 6;
    }
    public void WakeUp()
    {
        WCon.currentMenu = 0;
    }

    public void Ride()
    {
        Debug.Log("いくぞ");
        WCon.currentMenu = 2;
    }

    public void Tunnel(){
        fade.color = new Color(0, 0, 0, 0.2f);
    }

    public void Pick()
    {
        WCon.currentMenu = 7;
    }

    public void Fly()
    {
        WCon.currentMenu = 8;
    }
}

