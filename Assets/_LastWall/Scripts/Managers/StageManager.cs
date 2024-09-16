using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStageManager
{
    public StageData Stage { get; }
}
public class StageManager : Manager<StageManager>, IStageManager
{
    #region Event.OnStageEnterd() ȣ�� �� ��
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
    /// ���� Stage Data�� �������� Method
    /// </summary>
    public StageData Stage { get; private set; }

    [SerializeField]
    private StageData[] stages;

    // Load Stage Datas
    protected override void Awake()
    {
        base.Awake();

        // Stage Datas �� �ʱ�ȭ �ϴ� ����
        // JSON.. ���� �̿��ؼ�
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