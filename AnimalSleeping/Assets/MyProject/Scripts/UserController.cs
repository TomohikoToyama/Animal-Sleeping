using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour {

    // Use this for initialization

    private void Awake()
    {

        GameObject[] obj = GameObject.FindGameObjectsWithTag("Player");
        if (obj.Length > 1)
        {
            // 既に存在しているなら削除
            Destroy(gameObject);
        }
        else
        {
            // 音管理はシーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
