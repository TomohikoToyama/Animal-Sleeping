using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalCommand : MonoBehaviour {

    public AnimalCommand com;
    public Text commandName;
    public int id;
    private Image panelImg;
    public enum COMMAND{
        Call    = 0,
        Hangout = 1,
        Ride     = 2,
        Change  = 3,
        Stop   = 4,
        Close   = 5,
        Move    = 6,
        Pick    = 7

    }
    int count = 0;
    void Start()
    {
        if(id == (int)COMMAND.Change)
        {
            com = GameObject.Find("Comand_3").GetComponent<AnimalCommand>();
        }
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
            if (id == (int)COMMAND.Stop)
            {
                id = (int)COMMAND.Move;
                commandName.text = "うごく";
                
            }
            else if (id == (int)COMMAND.Move)
            {
                id = (int)COMMAND.Stop;
                commandName.text = "とまる";

            }
            else if (id == (int)COMMAND.Change)
            {
                count++;
                if(count == 2)
                {
                    Pick();
                }
                else if (count == 3)
                {
                    count = 0;
                    Ride();
                }
            }
        }

    }

    public void Pick()
    {


        com.id = (int)COMMAND.Pick;
        com.commandName.text = "もつ";
        
    }

    public void Ride()
    {
        
            com.id = (int)COMMAND.Ride;
            com.commandName.text = "のる";
        
    }


    // カーソルを閉じる
    public void Close()
    {
        ControllerManager.Instance.CloseMenu();
    }

}
