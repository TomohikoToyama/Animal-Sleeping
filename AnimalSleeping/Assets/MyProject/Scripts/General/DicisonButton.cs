using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicisonButton : MonoBehaviour {
    public GameObject RootObj;
    // Use this for initialization
    void Start()
    {
        RootObj = transform.root.gameObject;
    }

    public enum ROOT
    {
        AnimalSetting = 0,
        WorldSetting  = 1
    }
    public enum SE
    {
        HIT = 0,
        DICISION = 1,
        CLOES = 2
    }

    //メニューを閉じる
    public void Onclick()
    {
        if(RootObj.tag == ROOT.WorldSetting.ToString())
        {
            WorldManager.Instance.ChangeWorld();
        }
        GameStateManager.Instance.currentMenu = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySE((int)SE.HIT);

    }

}

	

