using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestEffect : IEffect
{
    public EventConfig TestEvent;

    public string optiontext;

    [Header("是否有选项")]
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

                () => { Debug.Log("玩家还在原地"); },

                true);
            HideTextUI();
        }

        if (Option == false  )
        {
           
        }
    }

}
