using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LaptopScene : ISceneManager
{
    protected override void QStart()
    {
        foreach (var item in Events)
        {
            ButtonTool.NewEventButton(item);
        }
    }

    protected override void QOnDestroy()
    {

    }

    protected override void VCallBack(ValueType type, int old, int _new, int v)
    {
        Debug.Log(_new + ":" + v);
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Energy:
                break;

            case ValueType.Major:

                if (_new > 100 && PlayerModel.GetV(ValueType.Money) > 200)
                {
                    EventConfig temp = GetEvent("ÕµÕµ—ßœ∞,’“¿œ ¶≤πøŒ", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;

            case ValueType.Money:
                if (_new > 200 && PlayerModel.GetV(ValueType.Major) > 100)
                {
                    EventConfig temp = GetEvent("ÕµÕµ—ßœ∞,’“¿œ ¶≤πøŒ", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;

            default:
                break;
        }
        /* switch (type)
         {
             case ValueType.Emotion:
                 if (_new >= 5)
                 {
                     EventConfig temp= VEvent.Find(item => item.Name == "ÕµÕµ—ßœ∞,’“¿œ ¶≤πøŒ");
                     ButtonTool.NewEventButton(temp);
                 }

                 break;
             case ValueType.Major:

                 break;
             default:
                 break;
         }*/

    }

    protected override LocationType GetSceneName()
    {
        return LocationType.Laptop;
    }
}
