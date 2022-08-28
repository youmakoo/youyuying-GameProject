using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class ISceneManager : MonoBehaviour
{
   
    public List<EventConfig> Events;
    public List<EventConfig> VEvent;

    public List<GameObject> AllShowButton=new List<GameObject>();

   

    private void Start()
    {
        GameManager.Instance.AtSceneManager = this;
        PlayerModel.ChangedVEvent += VCallBack;
        ShowEvent();
        QStart();
        GameManager.Instance.UpdatePlayerFootMark(GetSceneName());
    }
    private void OnDestroy()
    {
        PlayerModel.ChangedVEvent -= VCallBack;
        QOnDestroy();
    }

   /// <summary>
   /// ��ʾ�����¼����߼�
   /// </summary>
    public virtual  void ShowEvent()
    {
        foreach (var item in Events)
        {
            GameObject buttonObj = AllShowButton.Find(temp => temp.name == item.Name);
            if (buttonObj != null)
            {
                buttonObj.SetActive(true);
                continue;
            }
            buttonObj = ButtonTool.NewEventButton(item, () =>
            {
                AllShowButton.Remove(buttonObj);
            });
            AllShowButton.Add(buttonObj);
           
        }
    }

  /// <summary>
  /// ���������¼��߼�
  /// </summary>
    public virtual void HideEvent()
    {
        foreach (var item in AllShowButton)
        {
            item.SetActive(false);
        }
    }

    protected abstract void QStart();


    protected abstract void QOnDestroy();

    protected abstract void VCallBack(ValueType type, int old, int _new, int v);

    protected abstract LocationType GetSceneName();

    /// <summary>
    /// ͨ���¼����Ʒ����¼�����
    /// </summary>
    /// <param name="name"></param>
    /// <param name="eventList"></param>
    /// <returns></returns>
    protected EventConfig GetEvent(string name ,List<EventConfig> eventList =null)
    {

        EventConfig data=null;

        if (eventList != null)
        {
            foreach (var item in eventList)
            {
                if (name== item.Name)
                {
                    data = item;
                    break;
                }
            }
        }
        else
        {
            data = GetEvent(name, Events);
            if (data != null)
                return data;
            data = GetEvent(name, VEvent);
            if (data != null)
                return data;
        }
        return data;


    }


    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

 
}
