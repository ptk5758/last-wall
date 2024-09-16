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
        // �������� ���� �̺�Ʈ ����
        StageManager.Event.StageEnterd += StageEnterd_EventHandler;

        // ���� ���� �̺�Ʈ ����
        StateManager.Event.StateChanged += StateChanged_EventHandler;
    }

    private void OnDisable()
    {
        // �������� ���� �̺�Ʈ ���� ����
        StageManager.Event.StageEnterd -= StageEnterd_EventHandler;

        // ���� ���� �̺�Ʈ ���� ����
        StateManager.Event.StateChanged -= StateChanged_EventHandler;
    }

    // �������� ���� �̺�Ʈ ��鷯
    private void StageEnterd_EventHandler(StageData stage)
    {
        /*Debug.Log("Stage Enterd...");
        Debug.Log(stage);*/
    }

    // State ���� �̺�Ʈ ��鷯
    private void StateChanged_EventHandler(GameState state)
    {
        Debug.Log("���� ����");
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