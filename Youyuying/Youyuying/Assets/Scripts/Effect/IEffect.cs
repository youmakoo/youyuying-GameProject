using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class IEffect : MonoBehaviour
{

    public event Action<IEffect> EffentEndEvent;

    public List<string> TextString = new List<string>();

    

    private DialogBox m_DialogBox;
    private OptionBox m_OptionBox;

    protected int NextTextIndex = 0;
    public abstract void OnPlay();

    protected void EffentEnd()
    {
        EffentEndEvent?.Invoke(this);
    }

    #region 文本框操作方法
    private void ShowText(string str )
    {
        if (m_DialogBox == null)
        {
             var BoxObj = Resources.Load<GameObject>("TemplateObj/DialoBox_Below");
             m_DialogBox = GameObject.Instantiate(BoxObj, transform,false).GetComponent<DialogBox>();
             m_DialogBox.NextButton.onClick.AddListener(NextText);
        }
        ShowTextUI();
        m_DialogBox.ShowText(str) ;
    }

    protected void NextText()
    {
        if (TextString.Count == NextTextIndex)
        {
            TextEnd();
            return;
        }

        ShowText(TextString[NextTextIndex]);
        NextTextIndex++;
    }

    protected abstract void TextEnd();

    protected void ShowTextUI()
    {
        m_DialogBox.ShowUI();
    }

    protected void HideTextUI()
    {
        m_DialogBox.HideUI();
    }

    #endregion



    #region 选项框操作方法

    protected void ShowOption(string str, UnityAction tCallBack, UnityAction fCallBack = null, bool showf = false)
    {
        if (m_OptionBox == null)
        {
            var BoxObj = Resources.Load<GameObject>("TemplateObj/OptionBox");
            m_OptionBox = GameObject.Instantiate(BoxObj, transform, false).GetComponent<OptionBox>();
        }

        tCallBack += OptionEnd;
        fCallBack += OptionEnd;

        m_OptionBox.ShowOption(str, tCallBack, fCallBack, showf);
    }

    protected abstract void OptionEnd();

    #endregion


}
