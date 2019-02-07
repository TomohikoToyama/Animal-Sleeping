using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    
    private Color selected = new Color(125, 150, 255,255);
    private int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
    public Renderer rnd;
    private float closeTime;
    void Start()
    {
        Init();
    }
    public void Init()
    {
       
        transform.position = new Vector3(0, 1, 0);
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
            cursor.transform.rotation = Quaternion.LookRotation(cursor.transform.position - Camera.main.transform.position);
            rnd.enabled = true;
            InputMenu();
        }
        else
        {
            rnd.enabled = false;
            target = null;
        }
    }

    private bool InputEye()
    {
        //  return InputEyeClosed.GetCloseRightDown() || InputEyeClosed.GetCloseLeftDown();
        return false;
    }

    private bool InputBackEye()
    {
        /*
        if (InputEyeClosed.GetCloseBothDown())
        {
            closeTime += Time.deltaTime;
            if (closeTime >= 1f)
                return true;
        }
        else
        {
            closeTime = 0;
        }
        */
        return false;
    }

    private void InputMenu()
    {
 //       Fove.Managed.EFVR_Eye.Right

        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0) || InputEye())
        {
            

                //Debug.Log("クリック");
                if (target.tag == "AnimalSetting" )
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
                rnd.enabled =  false;
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

        // 英語対応
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Space))
        {
            

        }
    }
}
