using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimalCommand : MonoBehaviour {

    public AnimalCommand com;   //動物命令
    public Text commandName;    //命令名
    public int id;              //ID

    //コマンド一覧
    public enum COMMAND{
        Call    = 0,    //呼ぶ
        Hangout = 1,    //遊ぶ(未使用)
        Ride    = 2,    //乗る
        Change  = 3,    //大きさ変化
        Stop    = 4,    //止まる
        Close   = 5,    //メニュー閉じる
        Move    = 6,    //動く(止まってる時)
        Pick    = 7     //持つ(大きさが小さい時)

    }
    int count = 0;

    void Start()
    {
        if(id == (int)COMMAND.Change)
        {
            com = GameObject.Find("Comand_3").GetComponent<AnimalCommand>();
        }
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
