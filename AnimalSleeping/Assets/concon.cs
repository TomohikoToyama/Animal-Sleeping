using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class concon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
            transform.Translate(1, 0, 0);

        if (Input.GetKeyDown(KeyCode.D))
            transform.Translate(-1, 0, 0);


    }
}
