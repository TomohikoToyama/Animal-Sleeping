using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.W))
            transform.Translate(transform.forward);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-0.1f, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(0,0,0);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(transform.right);
        if (Input.GetKey(KeyCode.R))
            transform.Translate(0, 0.1f, 0);
        if (Input.GetKey(KeyCode.F))
            transform.Translate(0, -0.1f, 0);
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(new Vector3(0f, 1f, 0f));
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(new Vector3(0f, -1f, 0f));
    }
}
