using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ready = 준비
/// Battle = 전투
/// Maintenance = 정비
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
    // 현재 게임 상태를 저장하는 필드
    public GameState CurrentState { get; private set; }

    public static class Event
    {
        // 상태가 변경될 때 발생하는 이벤트
        public static event System.Action<GameState> StateChanged;

        // 상태 변경 시 이벤트 호출
        public static void OnStateChangedTrigger(GameState newState)
        {
            StateChanged?.Invoke(newState);
        }
    }
    private void Start()
    {
        // 초기 상태를 Ready로 설정
        ChangeState(GameState.Ready);
    }

    /// <summary>
    /// 상태 변경 메서드
    /// </summary>
    /// <param name="newState">변경될 상태</param>
    public void ChangeState(GameState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;

            // 상태가 변경될 때 이벤트 호출
            Event.OnStateChangedTrigger(newState);
        }
    }
}
