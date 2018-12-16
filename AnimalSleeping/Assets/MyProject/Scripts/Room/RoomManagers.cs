using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagers : MonoBehaviour {

    //シングルトン化のおまじない
    protected static RoomManagers instance;
    public static RoomManagers Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (RoomManagers)FindObjectOfType(typeof(RoomManagers));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");

                }
            }

            return instance;
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
