using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
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
        setMenu = setCanvas.transform.Find("Panel").gameObject;
    }

    public void OpenCloseMenu()
    {
        Debug.Log("dd");

        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        if (GameStateManager.Instance.currentMenu != 0)
        {
            Debug.Log("aa");
            setMenu.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
            GameStateManager.Instance.currentMenu = 0;
        }
    }
}
