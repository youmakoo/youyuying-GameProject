using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTest : MonoBehaviour
{
    

    private void OnGUI()
    {
        if (GUILayout.Button("����Test���͵�ֵ��201"))
        {
            PlayerModel.ChangedV(ValueType.Emotion, 20);
        }
    }
}
