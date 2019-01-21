using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    private GameObject animalObj;
    private GameObject playerObj;
    private Vector3 animalPos = new Vector3(2,1,2);
    private Vector3 playerPos = new Vector3(0, 1, 0);

    // Use this for initialization
    void Start () {
        animalObj = GameObject.FindGameObjectWithTag("Animal");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Eat()
    {

    }
    public void SetPosition()
    {
        animalObj = GameObject.FindGameObjectWithTag("Animal");
        playerObj = GameObject.FindGameObjectWithTag("Player");
     
    }


}
