using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTest : MonoBehaviour
{
    

    private void OnGUI()
    {
        if (GUILayout.Button("提升Test类型的值到201"))
        {
            PlayerModel.ChangedV(ValueType.Emotion, 20);
        }
    }
}
