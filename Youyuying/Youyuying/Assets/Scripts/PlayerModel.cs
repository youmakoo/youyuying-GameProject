using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum ValueType
{
    Emotion,
    Energy,
    Major,
    Money
}

public static class PlayerModel 
{
    private static Dictionary<ValueType, int> PlayerData = new Dictionary<ValueType, int>();

    private static Dictionary<ValueType, int> PlayerDataMax = new Dictionary<ValueType, int>();


    /// <summary>
    /// 值修改的委托-》改变的值类型是什么 ，—》旧的值 ， -》新的值 ，——》改变了多少
    /// </summary>
    public static event Action<ValueType, int,int,int> ChangedVEvent;
    


    public static void ChangedV(ValueType type, int v)
    {
        if (!PlayerData.ContainsKey(type))
        {
            PlayerData.Add(type, 0);
        }

        int old = PlayerData[type];

        PlayerData[type] = PlayerData[type] + v;
        //Debug.LogError(PlayerData[type]);
        ChangedVEvent?.Invoke(type, old, PlayerData[type], v);

    }

    public static int GetV(ValueType type)
    {
        if (!PlayerData.ContainsKey(type))
        {
            PlayerData.Add(type, 0);
        }

        return PlayerData[type];
    }

    public static void DebugData()
    {
        foreach (var item in PlayerData.Keys)
        {
            Debug.Log(item + "类型：的值为" + PlayerData[item]);
        }
    }
}
