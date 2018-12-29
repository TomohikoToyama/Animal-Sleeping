using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

    private string folder = "Prefabs/World/";
    //    private string type = ".prefab";
    private string path;
    public GameObject world;
    // Use this for initialization

    public void Create(string id)
    {
        // 拡張子まで書く
        path = folder +  id;
        Debug.Log(path);
        world = Resources.Load<GameObject>(path);
        Debug.Log(world.name);
        Instantiate(world);
        Debug.Log(world.name);
    }
}
