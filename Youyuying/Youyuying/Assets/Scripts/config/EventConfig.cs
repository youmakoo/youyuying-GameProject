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

    [Header("事件名字")]
    public string Name;

    [Header("触发次数")]
    public int TriggerCount = 1;

    [Header("新学期会重置")]
    public bool AtReset;

    [Header("触发结果")]
    public EventDataItem[] EventData;

    public EventConfines[] EventConfines;

    public IEffect Effect;

    public Sprite newSprite;

    public void Trigger()
    {
       
        if (TriggerCount == 0) return;
        Debug.Log($"触发了{Name}事件");

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

        //隐藏目前剩余的其他选项
     

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

