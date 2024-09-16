using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ready = �غ�
/// Battle = ����
/// Maintenance = ����
/// </summary>
public enum GameState
{
    Ready,
    Battle,
    Maintenance
}

public interface IStateManager
{
    public GameState CurrentState { get; }
    public void ChangeState(GameState newState);
    public void Ready() => ChangeState(GameState.Ready);
    public void Battle() => ChangeState(GameState.Battle);
    public void Maintenance() => ChangeState(GameState.Maintenance);
}
public class StateManager : Manager<StateManager>, IStateManager
{
    // ���� ���� ���¸� �����ϴ� �ʵ�
    public GameState CurrentState { get; private set; }

    public static class Event
    {
        // ���°� ����� �� �߻��ϴ� �̺�Ʈ
        public static event System.Action<GameState> StateChanged;

        // ���� ���� �� �̺�Ʈ ȣ��
        public static void OnStateChangedTrigger(GameState newState)
        {
            StateChanged?.Invoke(newState);
        }
    }
    private void Start()
    {
        // �ʱ� ���¸� Ready�� ����
        ChangeState(GameState.Ready);
    }

    /// <summary>
    /// ���� ���� �޼���
    /// </summary>
    /// <param name="newState">����� ����</param>
    public void ChangeState(GameState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;

            // ���°� ����� �� �̺�Ʈ ȣ��
            Event.OnStateChangedTrigger(newState);
        }
    }
}
