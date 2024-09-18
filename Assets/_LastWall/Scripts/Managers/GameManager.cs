using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        #region Event Subscribe
        // 스테이지 변경 이벤트 구독
        StageManager.Event.StageEntered += StageEnterd_EventHandler;

        // 라운드 엔터 이벤트 구독
        StageManager.Event.RoundEntered += RoundEntered_EventHandler;

        // 상태 변경 이벤트 구독
        StateManager.Event.StateChanged += StateChanged_EventHandler;
        #endregion
    }

    private void OnDisable()
    {
        #region Event UnSubscribe
        // 스테이지 변경 이벤트 구독 해제
        StageManager.Event.StageEntered -= StageEnterd_EventHandler;

        // 라운드 엔터 이벤트 구독 해제
        StageManager.Event.RoundEntered += RoundEntered_EventHandler;

        // 상태 변경 이벤트 구독 해제
        StateManager.Event.StateChanged -= StateChanged_EventHandler;
        #endregion
    }

    // 스테이지 변경 이벤트 헨들러
    private void StageEnterd_EventHandler(StageData stage)
    {

    }

    // State 변경 이벤트 헨들러
    private void StateChanged_EventHandler(GameState state)
    {
        switch (state)
        {
            case GameState.Battle:
                StartBattle();
                break;
            default:
                break;
        }
    }

    private void StartBattle()
    {
        StageManager.Instance.StartRound();
    }

    private void RoundEntered_EventHandler(RoundData data)
    {
        IMonsterSpawnManager spawnManager = MonsterSpawnManager.Instance;
        spawnManager.SpawnRound(data);
    }

    private void Update()
    {
        
    }

    #region State Test Code
    public void TestReady()
    {
        StateManager.Instance.ChangeState(GameState.Ready);
    }

    public void TestBattle()
    {
        StateManager.Instance.ChangeState(GameState.Battle);
    }

    public void TestnMaintance()
    {
        StateManager.Instance.ChangeState(GameState.Maintenance);
    }
    #endregion

}