using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PageButton : MonoBehaviour {

    public GameObject left;
    public GameObject right;
    private int pageNum = 1;
    public Text pageText;
    public int maxPage;
    private enum NAME
    {
        Prev,
        Next
    }
    public enum SE
    {
        HIT = 0
    }

    public void prePage()
    {
        if (pageNum == 1)
        {
            left.SetActive(false);
        }
        else if (pageNum < 1)
        {
            left.SetActive(true);
        }
    }

    private void PrevPage()
    {

    }
    private void NextPage()
    {
        pageNum ++;
       // AnimalManager.Instance.SetPanel(pageNum);

       
    }

    public void OnClick()
    {
        if (name == NAME.Prev.ToString())
        {
            AnimalManager.Instance.SetPage(-1);
            AnimalManager.Instance.ChangePage();
        }
        else if (name == NAME.Next.ToString())
        {
            AnimalManager.Instance.SetPage(1);
            AnimalManager.Instance.ChangePage();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.Instance.PlaySE((int)SE.HIT);

    }
}
