using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimalCreator : MonoBehaviour {

    private string folder = "Prefabs/Animal/";
//    private string type = ".prefab";
    private string path;
    public GameObject animal;
    // Use this for initialization
    
    public void Create(string category, string id)
    {
        path = folder + category + "/" + id;
        animal = Resources.Load<GameObject>(path);
        Instantiate(animal);
        var animalPos = animal.transform.position;
        var posX = Random.Range(-5.0f, 5.0f);
        if (-1 <= posX && posX <= 1)
            posX = 2;
        var posY = animalPos.y;
        var posZ = Random.Range(-5.0f, 5.0f);
        if (-1 <= posZ && posZ <= 1)
            posZ = 2;
        animal.transform.position = new Vector3(posX,posY,posZ);
    }
}
