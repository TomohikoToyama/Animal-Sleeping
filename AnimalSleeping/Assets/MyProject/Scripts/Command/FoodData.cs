using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodData : MonoBehaviour {

    public int ID;
    Transform hand;

    private void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Hand").transform;
    }

    private void Update()
    {
        transform.position = hand.position;  
        
    }
}
