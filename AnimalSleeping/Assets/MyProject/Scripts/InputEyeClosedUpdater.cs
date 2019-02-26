using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEyeClosedUpdater : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {

        /*
        InputEyeClosed.ClosedStateUpdate(FoveInterface.CheckEyesClosed());
        InputEyeClosed.ClosedDataUpdate(Fove.Managed.EFVR_Eye.Neither);
        InputEyeClosed.ClosedDataUpdate(Fove.Managed.EFVR_Eye.Left);
        InputEyeClosed.ClosedDataUpdate(Fove.Managed.EFVR_Eye.Right);
        InputEyeClosed.ClosedDataUpdate(Fove.Managed.EFVR_Eye.Both);
        */
       
    }
}
