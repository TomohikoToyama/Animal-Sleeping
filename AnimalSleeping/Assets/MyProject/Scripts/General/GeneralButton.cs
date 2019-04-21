using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GeneralButton : MonoBehaviour {

    public GameObject PanelObj;
    public GameObject RootObj;
    public enum NAME
    {
        Close,
        Dicision,            
    }
    public enum ROOT
    {
        AnimalSetting,
        WorldSetting,
        OptionSetting
    }
    public enum SE
    {
        HIT = 0
    }

    private void Start()
    {
        PanelObj = transform.parent.gameObject;

        RootObj = transform.root.gameObject;
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
    }
    //メニューを閉じる
    public void CloseMenu()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        if (RootObj.tag == ROOT.AnimalSetting.ToString())
            AnimalManager.Instance.OpenCloseMenu();
        else if (RootObj.tag == ROOT.WorldSetting.ToString())
            WorldManager.Instance.OpenCloseMenu();
        else if (RootObj.tag == ROOT.OptionSetting.ToString())
            OptionManager.Instance.OpenCloseMenu();

    }

    public void Dicision()
    {
        if (RootObj.tag == ROOT.WorldSetting.ToString())
        {
            GameStateManager.Instance.currentMenu = 0;
            WorldManager.Instance.ChangeWorld();
        }
        
    }

    public void OnEnable()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);

    }

    public void SetSelect()
    {

    }

    public void Onclick()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
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
        gameObject.GetComponent<Image>().color = new Color(125f / 255f, 150f / 255f, 255f / 255f);
    }


    private void OnTriggerExit(Collider other)
    {
       
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
       
    }




}
