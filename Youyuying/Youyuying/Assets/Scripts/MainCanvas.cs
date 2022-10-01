using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class MainCanvas : MonoBehaviour
{
    public Text emotion;
    public Text energy;
    public Text major;
    public Text money;
    public Text round;
    public Text ending;
    public Image endingImage;
    public Text noEnergy;
    public Animator showText;

    public Image energyBar;
    public Image emotionBar;

    public Button NextRoundBtn;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        PlayerModel.ChangedVEvent += OnChangedVEvent;
        round.text = "Round: " + (GameManager.Instance.CurrRound + 1);
        emotionBar.fillAmount = 0;
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
                energyBar.DOFillAmount((float)newValue / GameManager.Instance.gameConfig.PlayerInitEnergy, 0.7f);
                break;
            case ValueType.Major:
                major.text = "Major: " + newValue.ToString();
                emotionBar.DOFillAmount((float)newValue / 400, 0.7f);
                break;
            case ValueType.Money:
                money.text = "Money: " + newValue.ToString();
                break;
        }

        if (type == ValueType.Energy)
        {
            if (newValue <= 0)
            {
                NextRoundBtn.gameObject.SetActive(true);
            }
        }
    }

    public void NextRound()
    {
        GameManager.Instance.NextRound();
        NextRoundBtn.gameObject.SetActive(false);
        round.text = "Round: " + (GameManager.Instance.CurrRound + 1);
    }

    public void ShowEnding(string text, Sprite sprite)
    {
        ending.transform.parent.gameObject.SetActive(true);
        ending.text = text;
        endingImage.sprite = sprite;
    }

    public void ShowEnergyNotEnough()
    {
        noEnergy.gameObject.SetActive(true);
        NextRoundBtn.gameObject.SetActive(true);
        showText.Play("EnergyTextShow");
    }

    public void ResetStats()
    {
        emotion.text = "Emotion: " + PlayerModel.GetV(ValueType.Emotion);
        energy.text = "Energy: " + PlayerModel.GetV(ValueType.Energy);
        major.text = "Major: " + PlayerModel.GetV(ValueType.Major);
        money.text = "Money: " + PlayerModel.GetV(ValueType.Money);
    }
}
