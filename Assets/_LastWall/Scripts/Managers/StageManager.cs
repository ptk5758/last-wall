using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStageManager
{
    public StageData Stage { get; }
}
public class StageManager : Manager<StageManager>, IStageManager
{
    #region Event.OnStageEnterd() 호출 할 것
    public static class Event
    {
        public static event System.Action<StageData> StageEnterd;

        public static void OnStageEnterdTrigger(StageData data)
        {
            StageEnterd?.Invoke(data);
        }
    }
    #endregion

    /// <summary>
    /// Current Stage
    /// 현재 Stage Data를 가져오는 Method
    /// </summary>
    public StageData Stage { get; private set; }

    [SerializeField]
    private StageData[] stages;

    // Load Stage Datas
    protected override void Awake()
    {
        base.Awake();

        // Stage Datas 를 초기화 하는 로직
        // JSON.. 등을 이용해서
        // Test Stage Init
        Stage = stages[0];
    }

    private void Start()
    {
        if (Stage != null)
        {
            StageManager.Event.OnStageEnterdTrigger(Stage);
        }
    }
}