using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestEffect : IEffect
{
    public EventConfig TestEvent;

    public string optiontext;

    [Header("�Ƿ���ѡ��")]
    public bool Option;

    public override void OnPlay()
    {
        NextText();
    }

    protected override void OptionEnd()
    {
        EffentEnd();
    }

    protected override void TextEnd()
    {
        if (Option == true)
        {
            ShowOption(optiontext,

                () => { TestEvent.Trigger(); },

                () => { Debug.Log("��һ���ԭ��"); },

                true);
            HideTextUI();
        }

        if (Option == false  )
        {
           
        }
    }

}
