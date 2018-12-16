using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    //シングルトン化のおまじない
    protected static AnimalManager instance;
    public static AnimalManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (AnimalManager)FindObjectOfType(typeof(AnimalManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    // Use this for initialization
    void Start () {

        InitManager();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("AnimalSetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
    }

    public void OpenMenu()
    {
        setCanvas.SetActive(true);
    }
}
