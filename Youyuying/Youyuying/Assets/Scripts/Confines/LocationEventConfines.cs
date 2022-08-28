using System.Collections;
using UnityEngine;

public enum LocationType
{
    Dorm,
    ClassRoom,
    Street
}
public enum LocationState
{
    On,
    Beet,
    test
}

[CreateAssetMenu (fileName = "LocationItem" ,menuName ="Confines/Location")]
public class LocationEventConfines : EventConfines
{
    public LocationType location;

    public LocationState conState;

   

    public override EventConfig.EventDataItem[] Trigger(EventConfig.EventDataItem[] data)
    {
        switch (conState)
        {
            case LocationState.On:
                if (!GameManager.Instance.OnLocation(location))
                    return data;
                break;
            case LocationState.Beet:
                if (!GameManager.Instance.BeenLocation(location))
                    return data;
                 break;
            case LocationState.test:

                break;
            default:
                break;
        }
     

        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < ConfineData.Length; j++)
            {
                if (data[i].type == ConfineData[j].type)
                {
                    data[i].Value += ConfineData[j].Value;
                }

            }
        }
        return data;
    }
}
