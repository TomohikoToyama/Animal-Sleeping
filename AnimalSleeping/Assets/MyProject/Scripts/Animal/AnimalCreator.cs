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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create(string category, string id)
    {
        // 拡張子まで書く
        path = folder + category + "/" + id;
        Debug.Log(path);
        animal = Resources.Load<GameObject>(path);
        Debug.Log(animal.name);
        Instantiate(animal, new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
        animal.SetActive(true);
        animal.transform.position = new Vector3(1, 1, 1);
        Debug.Log(animal.name);
    }
}
