using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUserController : MonoBehaviour {

 
    //一度に複数のメニューが出ないよう制御
    public enum SELECTMENU
    {
        NONE = 0,
        ANIMAL = 1,
        GENERAL = 2,
        OPTION = 3,
        WORLD = 4,
        ROOM = 5
    }
    private int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
    public Renderer rnd;
 
    void Start()
    {
        
    }
    public void Init()
    {
        rnd = cursor.GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
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

    private void InputMenu()
    {

        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
        {
            

                //Debug.Log("クリック");
                if (target.tag == "AnimalSetting")
                {
                    //動物設定用メニューを開く
                    AnimalManager.Instance.OpenCloseMenu();

                }
                if (target.tag == "OptionSetting")
                {
                    //オプション設定用メニューを開く
                    OptionManager.Instance.OpenCloseMenu();
                }
                if (target.tag == "RoomSetting")
                {
                    //ルーム設定用メニューを開く
                    RoomManagers.Instance.OpenCloseMenu();
                }
                if (target.tag == "WorldSetting")
                {
                    //ルーム設定用メニューを開く
                    WorldManager.Instance.OpenCloseMenu();
                }

                if (target.tag == "Animal")
                {
                    //動物用メニューを開く
                    target.GetComponent<AnimalController>();
                }


            //Debug.Log("hhh");
            if (target.tag == "Button")
            {
                target.GetComponent<GeneralButton>().Onclick();
                rnd.enabled = false;
                target = null;
            }
            else if (target.tag == "AnimalButton")
            {
                target.GetComponent<AnimalData>().GetCell();
                target = null;
            }
            else if (target.tag == "WorldButton")
            {
                target.GetComponent<WorldData>().GetCell();
                target = null;
            }
            else if (target.tag == "PageButton")
            {
                target.GetComponent<PageButton>().OnClick();
                target = null;
            }

        }
    }
}
