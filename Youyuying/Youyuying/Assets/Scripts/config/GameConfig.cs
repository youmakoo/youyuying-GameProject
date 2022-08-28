using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSetting", menuName = "Game/GameSetting")]
public class GameConfig : ScriptableObject
{
    public int PlayerInitEnergy;
    public int TotalRounds;
}
