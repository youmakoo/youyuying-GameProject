using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    /// <summary>
    /// ��ʾ���ǵ�ǰ���½�
    /// </summary>
    public int AtC=0;

    public Dictionary<int, List<LocationType>> PlayerFootmark = new Dictionary<int, List<LocationType>>();

    public ISceneManager AtSceneManager;
    public EffectManager EffectManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
  

    /// <summary>
    /// ��������㼣
    /// </summary>
    /// <param name="name"></param>
    public void UpdatePlayerFootMark(LocationType name)
    { 
        if (!PlayerFootmark.ContainsKey(AtC))
        {
            PlayerFootmark.Add(AtC, new List<LocationType>());
        }
        PlayerFootmark[AtC].Add(name);
    }

    
    /// <summary>
    /// ȥ��ĳ���ط�
    /// </summary>
    public bool BeenLocation(LocationType locat,int chap =-1)
    {
        if (chap == -1) chap = AtC;
        return PlayerFootmark[chap].Contains(locat);
    } 
    
    public bool OnLocation(LocationType locat)
    {
        return PlayerFootmark[AtC][PlayerFootmark[AtC].Count-1]==locat;
    }


    private void OnGUI()
    {
        if (GUILayout.Button("�л�����"))
        {
            AtSceneManager.ChangeScene("Dorm");
        }
    }


}
