using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreator : MonoBehaviour {

    private string folder = "Prefabs/Food/";
    //    private string type = ".prefab";
    private string path;
    public GameObject food;
    // Use this for initialization

    public void Create(string id)
    {
        // 拡張子まで書く
        path = folder  + id;
        food = Resources.Load<GameObject>(path);
        Instantiate(food, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
    }
}
