using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OptionBox : MonoBehaviour
{
    public Text MainText;

    public Button TrueButton;

    public Button FButton;



    public void ShowOption(string str,UnityAction tCallBack, UnityAction fCallBack =null,bool showf =  true)
    {
        if (!showf)
        {
            FButton.gameObject.SetActive(false);
        }

        TrueButton.onClick.AddListener(CloseUI);
        FButton.onClick.AddListener(CloseUI);

        MainText.text = str;
        TrueButton.onClick.AddListener(tCallBack);

        if (fCallBack == null) return;
        FButton.onClick.AddListener(fCallBack);
    }
 

    public void CloseUI()
    {
        MainText.text = "";
        TrueButton.onClick.RemoveAllListeners();
        FButton.onClick.RemoveAllListeners();
    }
}
