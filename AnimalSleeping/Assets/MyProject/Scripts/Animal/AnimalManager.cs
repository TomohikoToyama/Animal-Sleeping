﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    //シングルトン化のおまじない
    protected static AnimalManager instance;
    public static AnimalManager Instance
    {

        get
        {
            if (instance == null)
            {
                instance = (AnimalManager)FindObjectOfType(typeof(AnimalManager));

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
