using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public void Onclick()
    {
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        if (id == (int)COMMAND.Call)
        {
            Call();
            Close();
        }
        else if (id == (int)COMMAND.Eat)
        {
            Close();
            Eat();
            
        }
        else if (id == (int)COMMAND.Sleep)
        {
            Close();
            Sleep();
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
            Close();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            gameObject.GetComponent<Image>().color = new Color(125f / 255f, 150f / 255f, 255f / 255f);
            SoundManager.Instance.PlaySE((int)SE.HIT);
        }

    }
    private void OnTriggerExit(Collider other)
    {
       
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        

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
