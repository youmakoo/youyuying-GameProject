using System.Collections;
using UnityEngine;


    public abstract class EventConfines : ScriptableObject
    {
    public EventConfig.EventDataItem[] ConfineData;
    public abstract EventConfig.EventDataItem[] Trigger(EventConfig.EventDataItem[] data);
        
    }
