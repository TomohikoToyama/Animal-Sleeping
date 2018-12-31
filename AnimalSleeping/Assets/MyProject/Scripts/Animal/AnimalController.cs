using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {


    private Vector3 targetPosition;
    private float stopTime;
    private float moveTime;
    private float speed = 1f;
    private Animator animator;
    // Use this for initialization
    void Start () {
        stopTime = Random.Range(3f,7f);
        moveTime = Random.Range(3f, 5f);
        animator = GetComponent<Animator>();
    }
	

	// Update is called once per frame
	void Update () {

        if(stopTime > 0)
        stopTime -= Time.deltaTime;

        if ( stopTime <= 0)
        {
            //正面に進む
           // animator.SetBool("metariglWalk", true);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / 2);
            moveTime -= Time.deltaTime;
        }
        if(moveTime <= 0)
        {
            stopTime = Random.Range(3f, 7f);
            moveTime = MoveTime();
            targetPosition = GetRandomPosition();
        }
    
	}
    public Vector3 GetRandomPosition()
    {
            float levelSize = 10f;
            return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }
    public float MoveTime()
    {
        return Random.Range(1f, 5f);
    }
    public void RandomMove()
    {


    }
    //動物メニューを開く
    public void OpenAnimalMenu(){
        
    }

 


}
