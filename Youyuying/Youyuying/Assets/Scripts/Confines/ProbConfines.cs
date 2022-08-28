using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Prob", menuName = "Confines/Prob")]
public class ProbConfines : EventConfines
{
    public float ProV = 0;

  

    public override EventConfig.EventDataItem[] Trigger(EventConfig.EventDataItem[] data)
    {
       if (GetProV(ProV))
        {
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
        return data;
    }

    private bool GetProV(float p)
    {

        if (PlayerModel.GetV(ValueType.Emotion) > 20)
        {
            p += 5;
        }




        bool state = false;

        int ranData= UnityEngine.Random.Range(0, 100);

        if(ranData < p)
        {
            state = true;
        }
        return state;
    }
}
