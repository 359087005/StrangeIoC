using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestScoreCommand : EventCommand
{
    [Inject]
    public IScoreService scoreService { get; set; }

    [Inject]
    public ScoreModel scoreModel { get; set;}
    public override void Execute()
    {
        Retain();
        scoreService.dispatcher.AddListener(Demo1ServiceEvent.RequestScore,OnComplete);
        scoreService.RequestScore("xxx.xxx.xx.xxx");
    }

    public void OnComplete(IEvent evt) //
    {
        scoreService.dispatcher.RemoveListener(Demo1ServiceEvent.RequestScore, OnComplete);

        scoreModel.Score = (int)evt.data;
        Debug.Log("RequestScoreCommand/OnComplete:" + scoreModel.Score);
        dispatcher.Dispatch(Demo1MediatorEvent.ScoreChange,evt);
        
        Release();
    }
}
