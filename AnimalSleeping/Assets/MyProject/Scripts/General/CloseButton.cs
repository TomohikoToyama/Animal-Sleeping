using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour {
    public GameObject PanelObj;
    // Use this for initialization
    void Start () {
        PanelObj = transform.parent.gameObject;
    }

    
    public enum SE
    {
        HIT      = 0,
        DICISION = 1,
        CLOES    = 2
    }
    
    //メニューを閉じる
    public void Onclick()
    {
        PanelObj.SetActive(false);
        GameStateManager.Instance.currentMenu = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySE((int)SE.HIT);
       
    }

}
