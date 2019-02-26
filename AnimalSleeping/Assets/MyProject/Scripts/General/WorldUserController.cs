﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class WorldUserController : MonoBehaviour {

    public GameObject Menu;
    public GameObject AnimalMenu;
    private WristManager wrist;
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
        RIDE    = 2,
        WORLD   = 3,
        OPTION  = 4,
        FOOD    = 5,
        SLEEP   = 6,
        PICK    = 7,
        FLY     = 8
    }
    public GameObject directionObj;
    public GameObject moveObj;
    float forwardSpeed = 1f;
    private float smoothTime = 0.5f;
    Vector3 velocity = Vector3.zero;
    public int currentMenu;
    // Use this for initialization
    private GameObject target;
    public GameObject cursor;
    public Transform animalPos;
    public GameObject food;
    private Transform dir;
    public GameObject cameraDir;
    private float footTimer;
    float transTIme;
    Vector3 topPos;
    public Renderer rnd;
    private Transform ridePos;
    private float closeTime;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (InputEyeClosed.GetCloseBoth())
        {
            closeTime += Time.deltaTime;

        }
        else
        {
            closeTime = 0;
        }
        
        */
        //Debug.Log(currentMenu);
        if (Input.GetKeyDown(KeyCode.T))
        {
            InputRide();


        }
       
        if (currentMenu == (int)SELECTMENU.NONE)
        {
            InputWorld();
            //バックキー入力で部屋に戻る
            if (OVRInput.GetDown(OVRInput.Button.Back) ||Negative())
            {
               
                ControllerManager.Instance.FadeOut();
                StartCoroutine(ChangeWait());

            }
        }
        else if (currentMenu == (int)SELECTMENU.ANIMAL)
        {
            InputAnimal();
            //バックキー入力で部屋に戻る
            if (OVRInput.GetDown(OVRInput.Button.Back) ||Negative())
            {
                
                ControllerManager.Instance.FadeOut();
                StartCoroutine(ChangeWait());

            }

        }
        else if (currentMenu == (int)SELECTMENU.FOOD)
        {
            InputFood();
        }
        else if (currentMenu == (int)SELECTMENU.SLEEP)
        {
            InputSleep();
            TouchImput();
        }else if (currentMenu == (int)SELECTMENU.RIDE)
        {
            InputRide();
        }
        else if (currentMenu == (int)SELECTMENU.PICK)
        {
            InputPick();
        }
        else if (currentMenu == (int)SELECTMENU.FLY)
        {
            InputFly();
        }
    }
    
    public void ChangeState()
    {
        //Debug.Log("チェンジ");
        currentMenu = (int)SELECTMENU.RIDE;
    }
    private IEnumerator ChangeWait()
    {
        yield return new WaitForSeconds(0.6f);
        moveObj.transform.position = new Vector3(0, 1, 0);
        WorldManager.Instance.BackRoom();
    }

    //コントローラ入力時
    public void TouchImput()
    {
        Vector2 touchPadPt = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        
        
        if (moveObj.name == "[CameraRig]")
        {
            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                
                var moveDir = directionObj.transform.rotation.eulerAngles.y;
                var moveQ = Quaternion.Euler(0, moveDir, 0);
                moveObj.transform.position += (moveQ * Vector3.forward).normalized * forwardSpeed * Time.deltaTime;
            }
        }
       
        
        if (Input.GetKey(KeyCode.X) || (touchPadPt.y > 0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5))
        {
            
            var moveDir = directionObj.transform.rotation.eulerAngles.y;
            var moveQ = Quaternion.Euler(0, moveDir, 0);
            transform.position += (moveQ * Vector3.forward).normalized * forwardSpeed * Time.deltaTime;
              
        }
        else
        {
            footTimer = 0;
        }
      
    }
    public void Init()
    {
        rnd.enabled = false;
        Menu = GameObject.FindGameObjectWithTag("Menu");
        AnimalMenu = GameObject.FindGameObjectWithTag("AnimalMenu");
        AnimalMenu.SetActive(false);
        dir = transform;
        currentMenu = (int)SELECTMENU.NONE;
        target = null;
    }

    private bool InputEye()
    {
        //return InputEyeClosed.GetCloseRightDown() || InputEyeClosed.GetCloseLeftDown();
        return false;
    }

    private bool InputBackEye()
    {
        if (closeTime >= 1f)
        {
            closeTime = 0;
            return true;
        }
        else
        {
            return false;
        }


    }
    private void InputWorld()
    {
            TouchImput();
            if (Positive())
            {
                //プレイルーム用メニューを開く
                AnimalMenu.SetActive(true);
                AnimalMenu.transform.position =Menu.transform.position + new Vector3(0,0.2f,0) ;
                AnimalMenu.transform.rotation = Menu.transform.rotation;
                currentMenu = (int)SELECTMENU.ANIMAL;
            
            }


    }

    
    private void InputAnimal()
    {
        EyePoint();
        if(transTIme >= 2f)
        {

            AnimalMenu.transform.position = Menu.transform.position + new Vector3(0, 0.2f, 0);
            AnimalMenu.transform.rotation = Menu.transform.rotation;
            transTIme = 0;
        }

    }

    private void InputFood()
    {
        Vector2 touchPadPt = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        food = GameObject.FindGameObjectWithTag("Food");
        if (touchPadPt.y > 0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5)
        {
            //上方向
            transform.Translate(transform.forward * 0.01f);
        }
        float dis =  Vector3.Distance(transform.position, animalPos.position);
        if (dis <= 1f)
        {
            AnimalManager.Instance.Eating();
            Destroy(food);
        }
    }

    private void InputPick()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) || Negative())
        {
            currentMenu = (int)SELECTMENU.NONE;
//            animalPos.position = new Vector3(moveObj.transform.position.x,0.1f, moveObj.transform.position.z);
            AnimalManager.Instance.Pick();
        }
    }
    private void InputRide()
    {
        
        if(ridePos == null)
            ridePos = GameObject.FindGameObjectWithTag("RidePoint").transform;

       // var size = animalPos.localScale.y;
      //  var ridePos = new Vector3(animalPos.position.x, topPos.y * size  + 0.7f * size, animalPos.position.z);
        moveObj.transform.position = ridePos.position;
        if (OVRInput.GetDown(OVRInput.Button.Back) || Negative())
        {
            currentMenu = (int)SELECTMENU.NONE;
            var posX = animalPos.position.x;
            var posZ = animalPos.position.z;
            moveObj.transform.position = new Vector3(posX,1,posZ);
        }
    }

    private void InputFly()
    {

        if (ridePos == null)
            ridePos = GameObject.FindGameObjectWithTag("RidePoint").transform;

        moveObj.transform.position = ridePos.position;
        if (OVRInput.GetDown(OVRInput.Button.Back) || Negative())
        {
            AnimalManager.Instance.PosReset();
            moveObj.transform.position = new Vector3(1, 1, 1);
            currentMenu = (int)SELECTMENU.NONE;
        }
    }
    private void InputSleep()
    {
        if (OVRInput.GetDown(OVRInput.Button.Back) || Negative())
        {
            AnimalManager.Instance.Command(4);
        }
    }
    private void EyePoint()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            target = hit.collider.gameObject;
            if (target.tag != "AnimalCommand")
            {
                transTIme += Time.deltaTime;
                rnd.enabled = false;
            }
            if(target.tag == "AnimalCommand")
                rnd.enabled = true;

            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
            ////Debug.Log(hit.collider.gameObject.name);

            cursor.transform.position = hit.point;
            cursor.transform.rotation = Quaternion.LookRotation(cursor.transform.position - transform.position);
            
            InputMenu();

        }
        else
        {
            rnd.enabled = false ;
            target = null;
            transTIme += Time.deltaTime;
        }
    }

    //メニュー用の入力
    private void InputMenu()
    {
        //トリガー入力時の処理
        if (Positive())
        {
            
            if (target.tag == "AnimalCommand")
            {
                animalPos = GameObject.FindGameObjectWithTag("Animal").transform;
                target.GetComponent<AnimalCommand>().Onclick();
                rnd.enabled = false;
                target = null;
                AnimalMenu.SetActive(false);
            }
            
        }
    }

    public void Close()
    {
        currentMenu = (int)SELECTMENU.NONE;
        AnimalMenu.transform.position = new Vector3(100,100,100);
    }
    private bool Positive()
    {
        
        if (moveObj.name == "[CameraRig]")
        {

            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                return true;
            }
        }
        
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            return true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else if (InputEye())
        {
            return true;
        }
        
        
        else
        {
            return false;
        }
    }

    private bool Negative()
    {
        
        if (moveObj.name == "[CameraRig]")
        {
            var trackedObject = GetComponent<SteamVR_TrackedObject>();
            var device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                return true;
            }
        }
        
        //Oculus Backキー
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
            return true;
        }
        else if (Input.GetMouseButton(1))
        {
            return true;
        }
        else if (InputBackEye())
        {
            return true;
        }
        else
        {
            return false;
        }

        
        
        
    }
}
