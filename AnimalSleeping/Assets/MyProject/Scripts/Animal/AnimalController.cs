using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {

    public enum STATE
    {
        CALL = 0,
        EAT = 1,
        NONE = 99
    }
    private GameObject Player;
    private Vector3 targetPosition;
    private float stopTime;
    private float moveTime;
    private float speed = 1f;
    private Animator animator;
    private AnimalData AData;
    // Use this for initialization
    void Start () {
        stopTime = Random.Range(3f,7f);
        moveTime = Random.Range(1f, 3f);
        AData = GetComponent<AnimalData>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	

	// Update is called once per frame
	void Update () {

       if(AData.State == (int)STATE.NONE)
        {
            RandomWalk();
        }else if(AData.State == (int)STATE.CALL)
        {
            Call();
        }
    
	}

    public void StateChange(int num)
    {
        Debug.Log(num + "の支持がでたよ");
        AData.State = num;
    }

    public void Call()
    {
        Debug.Log("向かってます");
        //呼ばれているよ
        targetPosition = Player.transform.position;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);

    }
    public void RandomWalk()
    {
        if (stopTime > 0)
            stopTime -= Time.deltaTime;

        if (stopTime <= 0)
        {
            //正面に進む
            // animator.SetBool("metariglWalk", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
            moveTime -= Time.deltaTime;
        }
        if (moveTime <= 0)
        {
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
