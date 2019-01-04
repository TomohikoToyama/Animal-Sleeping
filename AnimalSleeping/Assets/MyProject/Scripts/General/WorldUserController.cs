using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUserController : MonoBehaviour {

    public GameObject Menu;
    public GameObject AnimalMenu;
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
        HANGOUT = 2,
        WORLD   = 3,
        OPTION  = 4,
        FOOD    = 5
    }
    private float smoothTime = 0.5f;
    Vector3 velocity = Vector3.zero;
    public int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
    public Renderer rnd;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

        Vector2 touchPadPt = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

        if (touchPadPt.x > 0.5 && -0.5 < touchPadPt.y && touchPadPt.y < 0.5)
        {
            //右方向
        }
        if (touchPadPt.x < -0.5 && -0.5 < touchPadPt.y && touchPadPt.y < 0.5)
        {
            //左方向
        }
        if (touchPadPt.y > 0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5)
        {
            //上方向
            transform.Translate(transform.forward * 0.01f);
        }
        if (touchPadPt.y < -0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5)
        {
            //下方向
            transform.Translate(-transform.forward * 0.01f);
        }

        if (currentMenu == (int)SELECTMENU.NONE)
            InputWorld();

        else if (currentMenu == (int)SELECTMENU.ANIMAL)
            InputAnimal();

        else if (currentMenu == (int)SELECTMENU.FOOD)
            InputFood();

    }

    public void Init()
    {
        rnd = cursor.GetComponent<Renderer>();
        rnd.enabled = false;
        Menu = GameObject.FindGameObjectWithTag("Menu");
        AnimalMenu = GameObject.FindGameObjectWithTag("AnimalMenu");

    }
    private void InputWorld()

    {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
            {
                //プレイルーム用メニューを開く
            AnimalMenu.transform.position =Menu.transform.position + new Vector3(0,0.2f,0) ;
            AnimalMenu.transform.rotation = Menu.transform.rotation;
                currentMenu = (int)SELECTMENU.ANIMAL;
                
                

            }
            
            if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Space))
            {
            
                WorldManager.Instance.BackRoom();
            transform.position = new Vector3(0, 1, 0);
        }
        
    }

    
    private void InputAnimal()
    {
        EyePoint();
    }

    private void InputFood()
    {

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

    //メニュー用の入力
    private void InputMenu()
    {
        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
        {
            //Debug.Log("クリック");
            if (target.tag == "AnimalCommand")
            {
                Debug.Log("コマンド―");
                target.GetComponent<AnimalCommand>().Onclick();
            }
        }
    }

    public void Close()
    {
        currentMenu = (int)SELECTMENU.NONE;
        AnimalMenu.transform.position = new Vector3(100,100,100);
    }

}
