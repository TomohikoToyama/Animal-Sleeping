using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetting : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;
    private BoxCollider col;
    public void OpenCloseMenu()
    {

        if (GameStateManager.Instance.currentMenu == 0)
            setMenu.SetActive(true);

        if (GameStateManager.Instance.currentMenu != 0)
        {
            GameStateManager.Instance.currentMenu = 0;
            setMenu.SetActive(false);
        }
    }
}
