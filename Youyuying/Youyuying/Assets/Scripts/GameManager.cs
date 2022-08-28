using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainCanvasPrefab;

    public static GameManager Instance;

    public int CurrRound;

    /// <summary>
    /// 显示的是当前的章节
    /// </summary>
    public int AtC=0;

    public Dictionary<int, List<LocationType>> PlayerFootmark = new Dictionary<int, List<LocationType>>();

    public ISceneManager AtSceneManager;
    public EffectManager EffectManager;

    public GameConfig gameConfig;

    private MainCanvas mainCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }    
    }

    private void Start()
    {
        PlayerModel.ChangedVEvent += OnChangedVEvent;
    }

    public void StartGame()
    {
        CurrRound = 0;

        SceneManager.LoadScene("Dorm");

        GameObject obj = Instantiate(mainCanvasPrefab);
        mainCanvas = obj.GetComponent<MainCanvas>();

        PlayerModel.ChangedV(ValueType.Energy, gameConfig.PlayerInitEnergy);
    }

    public void NextRound()
    {
        CurrRound++;

        PlayerModel.ChangedV(ValueType.Energy, gameConfig.PlayerInitEnergy);

        if (CurrRound > gameConfig.TotalRounds)
        {
            Debug.Log("GameEnd");
        }
    }

    void OnChangedVEvent(ValueType type, int oldValue, int newValue, int changeAmount)
    {

    }

    /// <summary>
    /// 更新玩家足迹
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
    /// 去过某个地方
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
        if (GUILayout.Button("切换场景"))
        {
            AtSceneManager.ChangeScene("Dorm");
        }
    }


}
