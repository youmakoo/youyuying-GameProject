using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClassRoomScene : ISceneManager
{
    protected override LocationType GetSceneName()
    {
        return LocationType.ClassRoom;
    }

    protected override void QOnDestroy()
    {
     
    }

    protected override void QStart()
    {
     
    }



    protected override void VCallBack(ValueType type, int old, int _new, int v)
    {
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Vig:
                break;

            case ValueType.Major:

                if (_new > 150)
                {
                    EventConfig temp = GetEvent("全神贯注的做一次作业", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;
        }


    }
   
}
