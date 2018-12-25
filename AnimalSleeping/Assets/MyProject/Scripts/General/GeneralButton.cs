using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralButton : MonoBehaviour {

    public GameObject PanelObj;
    public GameObject RootObj;
    public enum NAME
    {
        
        Close,
        Dicision,
        Left,
        Right
            
    }
    public enum ROOT
    {
        AnimalSetting = 0,
        WorldSetting = 1
    }
    public enum SE
    {
        HIT = 0
    }

    private void Start()
    {
        PanelObj = transform.parent.gameObject;

        RootObj = transform.root.gameObject;
    }
    //メニューを閉じる
    public void CloseMenu()
    {
       
        
        PanelObj.SetActive(false);
        GameStateManager.Instance.currentMenu = 0;
       
    }

    public void Dicision()
    {
        if (RootObj.tag == ROOT.WorldSetting.ToString())
        {
            GameStateManager.Instance.currentMenu = 0;
            WorldManager.Instance.ChangeWorld();
        }
        
    }

    public void SetSelect()
    {

    }

    public void Onclick()
    {
        if (name == NAME.Close.ToString())
        {
            CloseMenu();

        }else if (name == NAME.Dicision.ToString())
        {
            Dicision();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySE((int)SE.HIT);

    }


}
