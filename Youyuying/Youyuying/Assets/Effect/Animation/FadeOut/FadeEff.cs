using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEff : IEffect
{
    public override void OnPlay()
    {
        Debug.Log("播放了新的效果");
        NextText();
    }

    protected override void OptionEnd()
    {
      
    }

    protected override void TextEnd()
    {
       
    }
}
