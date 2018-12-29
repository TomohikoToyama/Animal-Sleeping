using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AnimalCreator : MonoBehaviour {

    private string folder = "Prefabs/Animal/";
//    private string type = ".prefab";
    private string path;
    public GameObject animal;
    // Use this for initialization

    public void Create(string category, string id)
    {
        // 拡張子まで書く
        path = folder + category + "/" + id;
        animal = Resources.Load<GameObject>(path);
        Instantiate(animal, new Vector3(1.0f, 0f, 1.0f), Quaternion.identity);
    }
}
