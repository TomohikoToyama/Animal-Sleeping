using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreator : MonoBehaviour {

    private string folder = "Prefabs/Food/";
    //    private string type = ".prefab";
    private string path;
    public GameObject food;
    private GameObject handPos;
    // Use this for initialization

    public void Create(string id)
    {

        // 拡張子まで書く
        handPos = GameObject.FindGameObjectWithTag("Hand");
        path = folder  + id;
        food = Resources.Load<GameObject>(path);
        Instantiate(food, handPos.transform.position, Quaternion.identity);
    }
}
