using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.O))
            ControllerManager.Instance.FadeOut();
        if (Input.GetKeyDown(KeyCode.I))
            ControllerManager.Instance.FadeIn();

        if (Input.GetKey(KeyCode.R))
            transform.Rotate(new Vector3(1f, 0f, 0f));
        if (Input.GetKey(KeyCode.F))
            transform.Rotate(new Vector3(-1f, 0f, 0f));
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(new Vector3(0f, 1f, 0f));
        if (Input.GetKey(KeyCode.E))
            transform.Rotate(new Vector3(0f, -1f, 0f));
    }
}
