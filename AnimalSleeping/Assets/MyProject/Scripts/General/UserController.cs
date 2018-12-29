using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserController : MonoBehaviour {


    public enum SCENE
    {
        TITLE = 0,
        MENU = 1,
        WORLD = 2
    }


    //一度に複数のメニューが出ないよう制御
    public enum SELECTMENU
    {
        NONE    = 0,
        ANIMAL  = 1,
        GENERAL = 2,
        OPTION  = 3,
        WORLD   = 4,
        ROOM    = 5
    }
    private int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
    public Renderer rnd;
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
        rnd = cursor.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        if(GameStateManager.Instance.CurrentScene == (int)SCENE.MENU)
        EyePoint();

        if(GameStateManager.Instance.CurrentScene == (int)SCENE.WORLD)
        {
            InputWorld();
        }
        
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
            rnd.enabled = true;
            //Debug.Log(cursor.transform.position);
            InputMenu();
        }
        else
        {
            rnd.enabled = false;
            target = null;
        }
    }
    private void InputWorld()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Space))
        {
            WorldManager.Instance.BackRoom();
        }

    }
    private void InputMenu(){
      
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
                if (target.tag == "WorldSetting")
                {
                    //ルーム設定用メニューを開く
                    WorldManager.Instance.OpenCloseMenu();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.WORLD;
                }

                if (target.tag == "Animal")
                {
                    //動物用メニューを開く
                    target.GetComponent<AnimalController>();
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.ANIMAL;
                }
                
                if (GameStateManager.Instance.CurrentScene == (int)SCENE.WORLD)
                {
                    //プレイルーム用メニューを開く
                    GameStateManager.Instance.currentMenu = (int)SELECTMENU.GENERAL;

                }

            }else if (GameStateManager.Instance.currentMenu != (int)SELECTMENU.NONE)
            {
                //Debug.Log("hhh");
                if (target.tag == "Button")
                {
                    //Debug.Log("ccc");
                    target.GetComponent<GeneralButton>().Onclick();
                    rnd.enabled = false;
                    target = null;
                }else if(target.tag == "AnimalButton")
                {
                    target.GetComponent<AnimalData>().GetCell();
                    target = null;
                }
                else if (target.tag == "WorldButton")
                {
                    target.GetComponent<WorldData>().GetCell();
                    target = null;
                }


            }

        }
    }
}
