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
    // Use this for initialization
    private GameObject target;
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
        InputController();
    }

    private void EyePoint()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
            Debug.Log(hit.collider.gameObject.name);
            target = hit.collider.gameObject;
            
        }
        else
        {
            target = null;
        }
    }

    private void InputController(){

        
        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (target.tag == "AnimalSetting")
            {
                //動物設定用メニューを開く
                AnimalManager.Instance.OpenMenu();

            }
            if (target.tag == "OptionSetting")
            {
                //オプション設定用メニューを開く
                OptionManager.Instance.OpenMenu();
            }
            if (target.tag == "RoomSetting")
            {
                //ルーム設定用メニューを開く
                RoomManagers.Instance.OpenMenu();
            }
            if (target.tag == "PlaySetting")
            {
                //ルーム設定用メニューを開く
                PlayManager.Instance.OpenMenu();
            }

            if (target.tag == "Animal")
            {
                //動物用メニューを開く
                target.GetComponent<AnimalController>();
            }
            if(GameStateManager.Instance.CurrentScene == (int)SCENE.PLAY)
            {
                //プレイルーム用メニューを開く

            }
            else
            {
                //何もない所なら共通メニューを開く

            }



        }
    }
}
