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
        FOOD    = 5,
        SLEEP   = 6,
        RIDE    = 7
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
    public Renderer rnd;
    public Transform animalPos;
    public GameObject food;
    private Transform dir;
    public GameObject cameraDir;
    private float footTimer;
    float transTIme;
    Vector3 topPos;
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(currentMenu);
        if (Input.GetKeyDown(KeyCode.T))
        {
            InputRide();


        }
        //バックキー入力で部屋に戻る
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyDown(KeyCode.Space))
        {
            ControllerManager.Instance.FadeOut();
            StartCoroutine(ChangeWait());
            
        }
        if (currentMenu == (int)SELECTMENU.NONE)
        {
            InputWorld();
        }
        else if (currentMenu == (int)SELECTMENU.ANIMAL)
        {
            InputAnimal();

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
    }
    
    public void ChangeState()
    {
        //Debug.Log("チェンジ");
        currentMenu = 7;
    }
    private IEnumerator ChangeWait()
    {
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector3(0, 1, 0);
        WorldManager.Instance.BackRoom();
    }

    //コントローラ入力時
    public void TouchImput()
    {
        Vector2 touchPadPt = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);


        if (Input.GetKey(KeyCode.X) || (touchPadPt.y > 0.5 && -0.5 < touchPadPt.x && touchPadPt.x < 0.5))
        {
            footTimer += Time.deltaTime;
            var moveDir = directionObj.transform.rotation.eulerAngles.y;
            var moveQ = Quaternion.Euler(0, moveDir, 0);
            transform.position += (moveQ * Vector3.forward).normalized * forwardSpeed * Time.deltaTime;
            //上方向
            if(footTimer >= 1f)
            {
                //SoundManager.Instance.PlaySE(1);
                footTimer = 0;
            }
        }
        else
        {
            footTimer = 0;
        }
      
    }
    public void Init()
    {
        rnd = cursor.GetComponent<Renderer>();
        rnd.enabled = false;
        Menu = GameObject.FindGameObjectWithTag("Menu");
        AnimalMenu = GameObject.FindGameObjectWithTag("AnimalMenu");
        AnimalMenu.SetActive(false);
        dir = transform;
        currentMenu = (int)SELECTMENU.NONE;
        target = null;
    }
    private void InputWorld()
    {
            TouchImput();
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
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

    private void InputRide()
    {
        
        topPos = AnimalManager.Instance.GetTop();
        if(animalPos == null)
            animalPos = GameObject.FindGameObjectWithTag("Animal").transform;

        var size = animalPos.localScale.y;
        var ridePos = new Vector3(animalPos.position.x, topPos.y * size  + 0.3f * size, animalPos.position.z);
        transform.position = ridePos;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
        {
            currentMenu = (int)SELECTMENU.NONE;
            transform.position = animalPos.position + new Vector3(0,1,0);
        }
    }
    private void InputSleep()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
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
                transTIme += Time.deltaTime;
            //Rayが当たるオブジェクトがあった場合はそのオブジェクト名をログに表示
            ////Debug.Log(hit.collider.gameObject.name);
            
            cursor.transform.position = hit.point;
            Quaternion targetRotation = Quaternion.LookRotation(cursor.transform.position - transform.position);
            rnd.enabled = true;
            InputMenu();

        }
        else
        {
            rnd.enabled = false;
            target = null;
            transTIme += Time.deltaTime;
        }
    }

    //メニュー用の入力
    private void InputMenu()
    {
        //トリガー入力時の処理
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetMouseButtonDown(0))
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

}
