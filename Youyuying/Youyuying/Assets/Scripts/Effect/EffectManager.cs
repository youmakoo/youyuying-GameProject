using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager : MonoBehaviour
{
    public IEffect AtEffect;

    public GameObject SkipButton;

    public GameObject FadeOutEFF;
   

    

    private void Start()
    {
        GameManager.Instance.EffectManager = this;
        SkipButton?.GetComponent<Button>().onClick.AddListener(SkipEffect);
        SkipButton?.SetActive(false);
    }

    /// <summary>
    /// 播放效果
    /// </summary>
    /// <param name="effect"></param>
    public void PlayEffect(IEffect effect, Action<IEffect> playEndCallBack = null)
    {
        SkipButton?.SetActive(true);
        GameManager.Instance.AtSceneManager.HideEvent();
        GameObject tempObj = GameObject.Instantiate(effect.gameObject);
        AtEffect = tempObj.GetComponent<IEffect>();
        if (playEndCallBack != null)
        {
            AtEffect.EffentEndEvent += playEndCallBack;
        }
        AtEffect.EffentEndEvent += EffectEnd;
        AtEffect.OnPlay();
        AtEffect.transform.SetParent(transform);
    }


    /// <summary>
    /// 播放效果结束
    /// </summary>
    /// <param name="effect"></param>
    public void EffectEnd(IEffect effect)
    {
        SkipButton?.SetActive(false);
        GameManager.Instance.AtSceneManager.ShowEvent();
        Destroy(effect.gameObject);
    }


    /// <summary>
    /// 跳过该效果
    /// </summary>
    private void SkipEffect()
    {
        EffectEnd(AtEffect);
    }




    
}

