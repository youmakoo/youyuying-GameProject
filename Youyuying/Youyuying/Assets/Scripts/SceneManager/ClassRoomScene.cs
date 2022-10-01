using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;


public class ClassRoomScene : ISceneManager
{
    static bool firstIn;
    public EventConfig _FirstInEvent;
    public Sprite _FirstInSprite;

    protected override LocationType GetSceneName()
    {
        return LocationType.ClassRoom;
    }

    protected override void QOnDestroy()
    {
     
    }

    protected override void QStart()
    {

        StartCoroutine(FirstInEvent());
    }

    IEnumerator FirstInEvent()
    {
        yield return null;

        if (!firstIn)
        {
            sceneSprite.sprite = _FirstInSprite;
            _FirstInEvent.Trigger();
            firstIn = true;
        }
    }

    protected override void VCallBack(ValueType type, int old, int _new, int v)
    {
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Energy:
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
