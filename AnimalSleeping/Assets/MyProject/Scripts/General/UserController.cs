using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {


    public enum SCENE
    {
        TITLE = 0,
        MENU = 1,
        PLAY = 2
    }


    //一度に複数のメニューが出ないよう制御
    public enum SELECTMENU
    {
        NONE    = 0,
        ANIMAL  = 1,
        GENERAL = 2,
        OPTION  = 3,
        PLAY    = 4,
        ROOM    = 5
    }
    private int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
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
            // コントローラーはシーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {
        
        EyePoint();
        
    }

    private void EyePoint()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
            //Debug.Log(hit.collider.gameObject.name);
            target = hit.collider.gameObject;
            cursor.transform.position = hit.point;
            cursor.GetComponent<Renderer>().enabled = true;
            //Debug.Log(cursor.transform.position);
            InputController();
        }
        else
        {
            cursor.GetComponent<Renderer>().enabled = false;
            target = null;
        }
    }

    private void InputController(){
      
        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
        {
            if (GameStateManager.Instance.currentMenu == (int)SELECTMENU.NONE)
            {
                
                //Debug.Log("クリック");
                if (target.tag == "AnimalSetting")
                {
                    //動物設定用メニューを開く
                    AnimalManager.Instance.OpenCloseMenu();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.ANIMAL;

                }
                if (target.tag == "OptionSetting")
                {
                    //オプション設定用メニューを開く
                    OptionManager.Instance.OpenCloseMenu();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.OPTION;
                }
                if (target.tag == "RoomSetting")
                {
                    //ルーム設定用メニューを開く
                    RoomManagers.Instance.OpenCloseMenu();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.ROOM;
                }
                if (target.tag == "PlaySetting")
                {
                    //ルーム設定用メニューを開く
                    PlayManager.Instance.OpenCloseMenu();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.PLAY;
                }

                if (target.tag == "Animal")
                {
                    //動物用メニューを開く
                    target.GetComponent<AnimalController>();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.ANIMAL;
                }
                
                if (GameStateManager.Instance.CurrentScene == (int)SCENE.PLAY)
                {
                    //プレイルーム用メニューを開く
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.GENERAL;

                }

            }else if (GameStateManager.Instance.currentMenu != (int)SELECTMENU.NONE)
            {
                //Debug.Log("hhh");
                if (target.tag == "Close")
                {
                    //Debug.Log("ccc");
                    target.GetComponent<GeneralButton>().CloseMenu();
                    target = null;
                }
                
                
            }

        }
    }
}
