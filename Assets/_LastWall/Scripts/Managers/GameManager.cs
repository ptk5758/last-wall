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
        // 스테이지 변경 이벤트 구독
        StageManager.Event.StageEnterd += StageEnterd_EventHandler;

        // 상태 변경 이벤트 구독
        StateManager.Event.StateChanged += StateChanged_EventHandler;
    }

    private void OnDisable()
    {
        // 스테이지 변경 이벤트 구독 해제
        StageManager.Event.StageEnterd -= StageEnterd_EventHandler;

        // 상태 변경 이벤트 구독 해제
        StateManager.Event.StateChanged -= StateChanged_EventHandler;
    }

    // 스테이지 변경 이벤트 헨들러
    private void StageEnterd_EventHandler(StageData stage)
    {
        /*Debug.Log("Stage Enterd...");
        Debug.Log(stage);*/
    }

    // State 변경 이벤트 헨들러
    private void StateChanged_EventHandler(GameState state)
    {
        Debug.Log("상태 변경");
        Debug.Log(state);
    }

    #region State Test Code
    /*public void TestReady()
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
    }*/
    #endregion

}