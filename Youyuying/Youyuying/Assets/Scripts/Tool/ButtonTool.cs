using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTool : MonoBehaviour
{
    static GameObject templateObj;

    static Transform CanvarRoot;
    public static GameObject NewEventButton(EventConfig _event,Action call =null)
    {

        if (CanvarRoot == null)
        {
            GameObject  CanvarRootObj = Resources.Load<GameObject>("TemplateObj/RootCanvas");
            CanvarRoot= Instantiate(CanvarRootObj).transform.Find("EventButton");
        }

        if (templateObj == null)
        {
           templateObj = Resources.Load<GameObject>("TemplateObj/EventItem");
        }

        CanvarRoot.gameObject.SetActive(true);

        GameObject ButtonObj= Instantiate(templateObj, CanvarRoot, false);

        ButtonObj.name = _event.Name;
        ButtonObj.GetComponentInChildren<Text>().text = _event.Name;
        ButtonObj.GetComponent<Button>().onClick.AddListener(() =>
        {
            call?.Invoke();
            Destroy(ButtonObj);
            _event.Trigger();
            if (CanvarRoot != null)
            {
                if (CanvarRoot.childCount == 0)
                {
                    CanvarRoot.gameObject.SetActive(false);
                }
            }
        });

        return ButtonObj;
    }

   
   
}
