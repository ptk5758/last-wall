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
        StageManager.Event.StageEnterd += StageEnterd_EventHandler;
    }

    private void OnDisable()
    {
        StageManager.Event.StageEnterd -= StageEnterd_EventHandler;
    }

    private void StageEnterd_EventHandler(StageData stage)
    {
        Debug.Log("Stage Enterd...");
        Debug.Log(stage);
    }

}