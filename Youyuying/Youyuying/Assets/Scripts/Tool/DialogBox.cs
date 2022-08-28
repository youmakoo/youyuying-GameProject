using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    public Text MainText;
    public Button NextButton;

    public void ShowText( string str)
    {
        MainText.text = str;
    }

    public void HideUI()
    {
        gameObject.SetActive(false);
    }


    public void ShowUI()
    {
        gameObject.SetActive(true);
    }
}
