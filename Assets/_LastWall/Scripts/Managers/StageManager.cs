using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStageManager
{
    /// <summary>
    /// Current Stage
    /// </summary>
    public StageData Stage { get; }
    public bool HasNextRound();
    public void StartRound();
}

#region Stage Manager
public class StageManager : Manager<StageManager>, IStageManager
{
    #region Round
    class Round
    {
        Queue<RoundData> rounds;
        public Round(StageData data)
        {
            this.rounds = new Queue<RoundData>(data.rounds);
        }
        public RoundData Next()
        {
            if (rounds.Count == 0)
            {
                throw new System.Exception("No Next Round..");
            }
            return rounds.Dequeue();
        }
        public bool HasNextRound()
        {
            return rounds.Count > 0;
        }
    }
    #endregion

    public StageData Stage { get; private set; }
    [SerializeField]
    private StageData[] stages;

    private Round round;

    protected override void Awake()
    {
        base.Awake();

        
        Stage = stages[0]; // 임시로 Stages[0] 배열 들고온거임..
        round = new Round(Stage);
    }

    private void Start()
    {
        if (Stage != null)
        {
            StageManager.Event.OnStageEnterdTrigger(Stage);
        }
    }

    public void StartRound()
    {
        Debug.Log("StartRound!");
        Event.OnRoundEnterdTrigger(round.Next());
    }

    public bool HasNextRound() => round.HasNextRound();

    #region Event Class
    public static class Event
    {
        /// <summary>
        ///  스테이지 들어왔을때 이벤트
        /// </summary>
        public static event System.Action<StageData> StageEntered;
        public static void OnStageEnterdTrigger(StageData data)
        {
            StageEntered?.Invoke(data);
        }

        /// <summary>
        /// Round 들어왔을때 이벤트
        /// </summary>
        public static event System.Action<RoundData> RoundEntered;
        public static void OnRoundEnterdTrigger(RoundData data)
        {
            RoundEntered?.Invoke(data);
        }
    }
    #endregion
}
#endregion