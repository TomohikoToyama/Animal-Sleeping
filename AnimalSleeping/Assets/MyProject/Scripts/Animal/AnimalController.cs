﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    public enum STATE
    {
        CALL    = 0,
        HANGOUT = 1,
        EAT     = 2,
        CHANGE  = 3,
        SLEEP   = 4,
        EATING  = 90,
        NONE = 99
    }
    private GameObject Player;
    private Vector3 targetPosition;
    private float stopTime;
    private float moveTime;
    private float speed = 1f;
    private Animator animator;
    private AnimalData AData;
    private Vector3 targetSize;
    private Vector3 normalSize = new Vector3(1f,1f,1f);
    private Vector3 minSize = new Vector3(0.25f, 0.25f, 0.25f);
    private Vector3 maxSize = new Vector3(5f, 5f, 5f);
    private bool isSleep;
    private float nowScale;
    private float targetScale;
    // Use this for initialization
    void Start () {
        stopTime = Random.Range(3f,7f);
        moveTime = Random.Range(1f, 3f);
        AData = GetComponent<AnimalData>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
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
        }
        else if (AData.State == (int)STATE.HANGOUT)
        {
           
        }
        else if (AData.State == (int)STATE.EAT)
        {
            Eat();
        }
        else if (AData.State == (int)STATE.CHANGE)
        {
            Change();
        }
        else if (AData.State == (int)STATE.SLEEP)
        {
            Sleep();
        }

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
        Debug.Log(num + "の支持がでたよ");
        AData.State = num;
    }

    public void Call()
    {

        //呼ばれているよ
        animator.SetBool("Run", true);
        targetPosition = Player.transform.position - new Vector3(0,-1f,2f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);

    }
    public void Eat()
    {

        //呼ばれているよ
        animator.SetBool("Run", true);
        targetPosition = GameObject.FindGameObjectWithTag("Food").transform.position;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
    }
    public void Change()
    {
        
        if (AData.Size == 0)
        {
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
    public void Sleep()
    {
        if (!isSleep)
        {
            isSleep = true;
            animator.SetBool("Sleep", true);
        }
    }


    public void RandomWalk()
    {
        if (stopTime > 0)
            stopTime -= Time.deltaTime;

        if (stopTime <= 0)
        {
            //正面に進む
            animator.SetBool("Walk", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
            moveTime -= Time.deltaTime;
        }
        if (moveTime <= 0)
        {
            animator.SetBool("Walk", false);
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
 

 


}