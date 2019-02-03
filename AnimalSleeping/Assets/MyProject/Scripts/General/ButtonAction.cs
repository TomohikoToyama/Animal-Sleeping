using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonAction : MonoBehaviour
{
    private Image img;

    // Use this for initialization
    void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    //ボタンの効果音
    public enum SE
    {
        HIT = 0
    }

    // カーソルが当たった時は色を変える
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cursor")
        {
            img.color = new Color(125f / 255f, 150f / 255f, 255f / 255f);
            SoundManager.Instance.PlaySE((int)SE.HIT);
        }
    }

    // カーソルが離れたら通常の色に戻す
    private void OnTriggerExit(Collider other)
    {

        img.color = new Color(1, 1, 1);
       

    }
}
