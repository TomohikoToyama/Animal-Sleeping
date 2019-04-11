using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    public enum STATE
    {
        CALL    = 0,
        STOP = 1,
        RIDE    = 2,
        CHANGE  = 3,
        SLEEP   = 4,
        HANGOUT    = 5,
        MOVE = 6,
        EAT = 100,
        PICK = 7,
        FLY  = 8,
        EATING  = 90,
        NONE    = 99
    }

    private Transform HandPos;
    private GameObject Player;
    private GameObject ridePoint;
    private Vector3 targetPosition;
    private float stopTime;
    private float moveTime;
    private float speed = 1f;
    private float run = 2f;
    private Animator animator;
    private AnimalData AData;
    private Vector3 targetSize;
    private Vector3 normalSize = new Vector3(1f,1f,1f);
    private Vector3 minSize = new Vector3(0.25f, 0.25f, 0.25f);
    private Vector3 maxSize = new Vector3(5f, 5f, 5f);
    private bool isSleep;
    private float nowScale;
    private float targetScale;
    float dis;
    float sleepWait = 0.6f;
    GameObject cameraDir;
    public Vector3 topSize;
    // Use this for initialization
    void Start () {
        stopTime = Random.Range(3f,7f);
        moveTime = Random.Range(1f, 3f);
        AData = GetComponent<AnimalData>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        topSize = GetComponent<BoxCollider>().bounds.size;
        cameraDir = GameObject.FindGameObjectWithTag("MainCamera");
        HandPos = GameObject.FindGameObjectWithTag("Hand").transform;
    }

    Vector3 vel = Vector3.zero;

    // Update is called once per frame
    void Update () {
       if(AData.State == (int)STATE.NONE)
        {
            RandomWalk();
        }else if(AData.State == (int)STATE.CALL)
        {
            Call();
        }else if (AData.State == (int)STATE.STOP)
        {

        }
        else if (AData.State == (int)STATE.RIDE)
        {
            RandomWalk();
        }
        else if (AData.State == (int)STATE.CHANGE)
        {
            Change();
        }
        else if (AData.State == (int)STATE.SLEEP)
        {
            
        }
        else if (AData.State == (int)STATE.MOVE)
        {

            AData.State = (int)STATE.NONE;


        }
        else if (AData.State == (int)STATE.PICK)
        {
            gameObject.transform.position = HandPos.position;
            gameObject.transform.rotation = Quaternion.Euler(0, HandPos.localRotation.y,0);
        }
        else if (AData.State == (int)STATE.FLY)
        {
            
            gameObject.transform.position += new Vector3(0,0.005f,0);
          
            gameObject.transform.rotation = HandPos.rotation;
            gameObject.transform.position += HandPos.transform.forward * 0.05f;

        }
    }
    public void PosReset()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;

        AData.State = 99;
        AnimReset();
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = new Vector3(1, 2, 1);
    }
    /*
    private IEnumerator SizeChange(GameObject target)
    {
        
        int loopCount = 10;
        float waitSec = 0.05f;
        if (AData.Size == 0)
        {
            targetSize = maxSize;
            targetScale = 5f;
            nowScale = 1f;

            AData.Size = 1;
        }
        else if(AData.Size == 1)
        {
            targetSize = minSize;
            targetScale = 0.1f;
            nowScale = 5f;
            AData.Size = -1;
            AData.State = (int)STATE.NONE;
        }
        else if (AData.Size == -1)
        {
            targetSize = normalSize;
            targetScale = 1f;
            nowScale = 0f;
            AData.Size = -1;
            AData.State = (int)STATE.NONE;
        }
        float offsetScale = targetScale / loopCount;
        float updateScale = nowScale;
        for (int loop = 0; loop < loopCount; loop++)
        {
            // スケール更新
            updateScale = updateScale + offsetScale;
            target.transform.localScale = new Vector3(updateScale, updateScale, updateScale);
            yield return new WaitForSeconds(waitSec);
        }
        target.transform.localScale = targetSize;
        AData.State = (int)STATE.NONE;
        
    }   
    */


    public void StateChange(int num)
    {
        AData.State = num;
        if(num == (int)STATE.STOP)
        {
            AnimReset();
        }
        if(num == (int)STATE.RIDE)
        {
            ControllerManager.Instance.FadeAll();
            ridePoint = GameObject.FindGameObjectWithTag("RidePoint");
            if (ridePoint.name == "Fly")
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                AnimReset();
                animator.SetBool("Fly", true);
                AData.State = (int)STATE.FLY;
                ControllerManager.Instance.Fly();
            }
            else
            {
                
                ControllerManager.Instance.Ride();
            }
        }
        if (num == (int)STATE.SLEEP)
        {
            AnimReset();
        }
        if (num == (int)STATE.PICK)
        {
            HandPos = GameObject.FindGameObjectWithTag("Hand").transform;
            ControllerManager.Instance.Pick();
        }if(num == (int)STATE.NONE)
        {
            AData.State = (int)STATE.NONE;
        }
    }

    //アニメーション初期化処理
    private void AnimReset()
    {
        animator.SetBool("Fly", false);
        animator.SetBool("MoveFast", false);
        animator.SetBool("Sleep", false);
        animator.SetBool("Move", false);
        animator.SetBool("Eat", false);
    }

    //動物を呼ぶ
    public void Call()
    {

        AnimReset();
        animator.SetBool("MoveFast", true);
        targetPosition = Player.transform.position;
        dis = Vector3.Distance(transform.position, targetPosition);
        if (dis <= 3f)
        {
            animator.SetBool("MoveFast", false);
            AData.State = (int)STATE.NONE;

        }
        transform.Translate(Vector3.forward * speed * run * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        targetRotation.x = 0;
        targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);

    }
    
    //
    public void Skill()
    {

    }
    //大きさ変化コマンド
    public void Change()
    {
        
        if (AData.Size == 0)
        {
            this.transform.position += new Vector3(0, 2f, 0); 
            this.transform.localScale = maxSize;
            AData.Size = 1;
            AData.State = (int)STATE.NONE;
        }
        else if (AData.Size == 1) {
            this.transform.localScale = minSize;
            AData.Size = -1;
            AData.State = (int)STATE.NONE;
        }
        else if (AData.Size == -1)
        {

            this.transform.localScale = normalSize;
            AData.Size = 0;
            AData.State = (int)STATE.NONE;
        }
        
    }
   

    public void RandomWalk()
    {
        if (stopTime > 0)
            stopTime -= Time.deltaTime;

        if (stopTime <= 0)
        {
            //正面に進む
            animator.SetBool("Move", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
             
            moveTime -= Time.deltaTime;
        }
        if (moveTime <= 0)
        {
            AnimReset();
            stopTime = Random.Range(3f, 7f);
            moveTime = MoveTime();
            targetPosition = GetRandomPosition();
        }

    }
    public Vector3 GetRandomPosition()
    {
            float levelSize = 2f;
            return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
    public float MoveTime()
    {
        return Random.Range(1f, 3f);
    }
    public void RandomMove()
    {


    }


    //食事
    /*
    public void Eat()
    {

        AnimReset();
        animator.SetBool("MoveFast", true);
        targetPosition = GameObject.FindGameObjectWithTag("Food").transform.position;
        transform.Translate(Vector3.forward * speed * run * Time.deltaTime);
        dis = Vector3.Distance(transform.position, targetPosition);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        targetRotation.x = 0;
        targetRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
        if (dis <= 3f)
        {
            AnimReset();
            //Debug.Log("食事待機");
            animator.SetBool("MoveFast", false);
            AData.State = (int)STATE.EATING;

        }
    }

    public void Eating()
    {
        //Debug.Log("食事");
        AnimReset();
        animator.SetBool("Eat", true);
    }
    */

    /*
    //寝る
    public void Sleep()
    {
        if (!isSleep)
        {

            ControllerManager.Instance.Sleep();
            ControllerManager.Instance.FadeAll();
            isSleep = true;
            AnimReset();
            animator.SetBool("Sleep", true);

        }
        else
        {
            isSleep = false;
            AnimReset();
            AData.State = (int)STATE.NONE;
            ControllerManager.Instance.WakeUp();
            ControllerManager.Instance.FadeAll();
        }
    }
    */
}
