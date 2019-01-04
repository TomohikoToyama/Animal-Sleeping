using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCommand : MonoBehaviour {

    public string commandName;
    public int id;


    public enum COMMAND{
        Call    = 0,
        Hangout = 1,
        Eat     = 2,
        Change  = 3,
        Sleep   = 4,
        Close   = 5

    }
    public enum SE
    {
        HIT = 0
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public  void Onclick()
    {
        if(id == (int)COMMAND.Call)
        {
            Call();
            Close();
        }
        else if (id == (int)COMMAND.Eat)
        {
            Eat();
            Close();
        }
        else if (id == (int)COMMAND.Sleep)
        {
            Sleep();
            Close();
        }
        else if (id == (int)COMMAND.Hangout)
        {

        }
        else if (id == (int)COMMAND.Change)
        {
            Change();
            Close();
        }
        else if (id == (int)COMMAND.Close)
        {
            Debug.Log("とじるんです");
            
            Close();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySE((int)SE.HIT);

    }

    public void Call()
    {
        Debug.Log("呼ぶ");
        AnimalManager.Instance.Command(id);

    }

    public void Eat()
    {
        Debug.Log("めし");
        AnimalManager.Instance.Command(id);
    }

    public void Sleep()
    {
        Debug.Log("ねる");
        AnimalManager.Instance.Command(id);
    }

    public void Hangout()
    {
        
    }

    public void Change()
    {
        Debug.Log("変化");
        AnimalManager.Instance.Command(id);
    }
    public void Close()
    {
        ControllerManager.Instance.CloseMenu();
    }

}
