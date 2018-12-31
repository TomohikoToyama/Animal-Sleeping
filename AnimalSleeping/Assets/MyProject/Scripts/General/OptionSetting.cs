using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSetting : MonoBehaviour {

    public GameObject setObj;
    public GameObject setCanvas;
    public GameObject setMenu;

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
