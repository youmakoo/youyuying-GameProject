using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public Text emotion;
    public Text energy;
    public Text major;
    public Text money;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        PlayerModel.ChangedVEvent += OnChangedVEvent;
        ResetStats();
    }

    void OnChangedVEvent(ValueType type, int oldValue, int newValue, int changeAmount)
    {
        switch (type)
        {
            case ValueType.Emotion:
                emotion.text = "Emotion: " + newValue.ToString();
                break;
            case ValueType.Energy:
                energy.text = "Energy: " + newValue.ToString();
                break;
            case ValueType.Major:
                major.text = "Major: " + newValue.ToString();
                break;
            case ValueType.Money:
                money.text = "Money: " + newValue.ToString();
                break;
        }

        if (type == ValueType.Energy)
        {
            if (newValue <= 0)
            {

                GameManager.Instance.NextRound();
            }
        }
    }

    public void ResetStats()
    {
        emotion.text = "Emotion: " + PlayerModel.GetV(ValueType.Emotion);
        energy.text = "Energy: " + PlayerModel.GetV(ValueType.Energy);
        major.text = "Major: " + PlayerModel.GetV(ValueType.Major);
        money.text = "Money: " + PlayerModel.GetV(ValueType.Money);
    }
}
