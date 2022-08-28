using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScene : ISceneManager
{

    protected override LocationType GetSceneName()
    {
        return LocationType.Street;
    }
    protected override void QOnDestroy()
    {

    }

    protected override void QStart()
    {
        foreach (var item in Events)
        {
            ButtonTool.NewEventButton(item);
        }
    }


    protected override void VCallBack(ValueType type, int old, int _new, int v)
    {
        Debug.Log(_new + ":" + v);
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Vig:
                break;

            case ValueType.Major:

                if (_new > 100 )
                {
                    EventConfig temp = GetEvent("�߼��ļ�ְ����", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;

            case ValueType.Money:
                
                break;

            default:
                break;
        }
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Vig:
                break;

            case ValueType.Major:

                if (_new <100&&_new>=50)
                {
                    EventConfig temp = GetEvent("�����㸱ҵ", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;

            case ValueType.Money:

                break;

            default:
                break;
        }
        switch (type)
        {
            case ValueType.Emotion:
                break;

            case ValueType.Vig:
                break;

            case ValueType.Major:
                break;

            case ValueType.Money:
                if (_new>100)
                {
                    EventConfig temp = GetEvent("��������", VEvent);
                    ButtonTool.NewEventButton(temp);
                }
                break;

            default:
                break;
        }

    }
    private void OnGUI()
    {

        if (GUILayout.Button("ֱ��������100"))
        {
            PlayerModel.ChangedV(ValueType.Major, 100);
        }
        if (GUILayout.Button("ֱ��������50"))
        {
            PlayerModel.ChangedV(ValueType.Major, 50);
        }
        if (GUILayout.Button("moneyֱ��������100"))
        {
            PlayerModel.ChangedV(ValueType.Money, 100);
        }


    }

}
