using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalCommand : MonoBehaviour {

    public string commandName;
    public int id;
    private Image panelImg;
    public enum COMMAND{
        Call    = 0,
        Hangout = 1,
        Eat     = 2,
        Change  = 3,
        Sleep   = 4,
        Close   = 5

    }
    void Start()
    {
        panelImg = gameObject.GetComponent<Image>();
    }

    public void Onclick()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        if (id == (int)COMMAND.Close)
        {            
            Close();
        }else
        {
            Close();
            AnimalManager.Instance.Command(id);
        }

    }

 
    // カーソルを閉じる
    public void Close()
    {
        ControllerManager.Instance.CloseMenu();
    }

}
