using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralButton : MonoBehaviour {

    public GameObject PanelObj;
    protected static GeneralButton instance;
    public static GeneralButton Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (GeneralButton)FindObjectOfType(typeof(GeneralButton));

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //メニューを閉じる
    public void CloseMenu()
    {
       
        PanelObj = transform.parent.gameObject;
        PanelObj.SetActive(false);

        GameStateManager.Instance.currentMenu = 0;

       
    }
}
