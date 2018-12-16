using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
    public GameObject setObj;
    public GameObject setCanvas;
    //シングルトン化のおまじない
    protected static PlayManager instance;
    public static PlayManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (PlayManager)FindObjectOfType(typeof(PlayManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    void Start()
    {

        InitManager();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitManager()
    {
        setObj = GameObject.FindGameObjectWithTag("PlaySetting");
        setCanvas = setObj.transform.Find("Canvas").gameObject;
    }

    public void OpenMenu()
    {
        setCanvas.SetActive(true);
    }
}
