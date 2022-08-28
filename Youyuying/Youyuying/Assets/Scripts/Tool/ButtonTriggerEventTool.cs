using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTriggerEventTool : MonoBehaviour
{
   public EventConfig _Event;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {

            _Event.Trigger();
        });
    }

   
}
