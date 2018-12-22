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

    //メニューを閉じる
    public void CloseMenu()
    {
       
        PanelObj = transform.parent.gameObject;
        PanelObj.SetActive(false);

        GameStateManager.Instance.currentMenu = 0;

       
    }
}
