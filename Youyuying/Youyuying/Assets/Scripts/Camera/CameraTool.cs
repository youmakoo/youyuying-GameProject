using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraTool : MonoBehaviour
{
    private Action LookAtEndCallBack;

    public void PlayLookAtAnim(Action animEnd)
    {

        GetComponent<Animator>().SetBool("Play", true);
        LookAtEndCallBack = animEnd;
    }


    public void AnimCallLookAtEnd()
    {
        LookAtEndCallBack?.Invoke();
    }
}