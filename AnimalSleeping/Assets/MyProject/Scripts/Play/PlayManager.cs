using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {

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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
