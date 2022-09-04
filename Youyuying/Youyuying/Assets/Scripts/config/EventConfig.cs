using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EventItem",menuName ="Event/New")]
public class EventConfig : ScriptableObject
{
    [System.Serializable]
    public struct EventDataItem
    {
        public ValueType type;
        public int Value;
    }

    [Header("�¼�����")]
    public string Name;

    [Header("��������")]
    public int TriggerCount = 1;

    [Header("��ѧ�ڻ�����")]
    public bool AtReset;

    [Header("�������")]
    public EventDataItem[] EventData;

    public EventConfines[] EventConfines;

    public IEffect Effect;

    public Sprite newSprite;

    public void Trigger()
    {
       
        if (TriggerCount == 0) return;
        Debug.Log($"������{Name}�¼�");

        foreach (var item in EventData)
        {
            if(item.type == ValueType.Energy && Mathf.Abs(item.Value) > PlayerModel.GetV(ValueType.Energy))
            {
                GameManager.Instance.ShowEnergyNotEnough();
               Debug.Log("No Energy");
                return;
            }
        }

        foreach (var item in EventConfines)
        {
            EventData = item.Trigger(EventData);
        }

        foreach (var item in EventData)
        {
            PlayerModel.ChangedV(item.type, item.Value);
        }

        //����Ŀǰʣ�������ѡ��
     

        if (Effect==null)
        {
            GameManager.Instance.AtSceneManager.ShowEvent();
        }
        else
        {
            GameManager.Instance.EffectManager.PlayEffect(Effect);
        }

        if(newSprite != null)
        {
            GameManager.Instance.ChangeCurrentSceneSprite(newSprite);
        }
      
        PlayerModel.DebugData();
       
    }

    
}

