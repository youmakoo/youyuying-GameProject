using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting", menuName = "Game/GameSetting")]
public class GameConfig : ScriptableObject
{
    public int PlayerInitEnergy;
    public int TotalRounds;
    public List<Ending> endings;
}

[System.Serializable]
public class Ending
{
    public int Major;
    public int Emotion;
    public string text;
}
