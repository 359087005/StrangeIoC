using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来 处理view与外界的交互
/// </summary>
public class CubeMediator : Mediator
{
    /// <summary>
    ///加入 inject属性  cubeView会自动获取值
    /// </summary>
    [Inject]
    public CubeView cubeView { get; set; }

    [Inject(ContextKeys.CONTEXT_DISPATCHER)]  //全局的派发器
    public IEventDispatcher dispatcher { get; set; }

   


    public override void OnRegister()
    {
        Debug.Log("CubeMediator OnRegister");
        cubeView.Init();
        dispatcher.AddListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);

        cubeView.dispatcher.AddListener(Demo1MediatorEvent.ClickDown,OnClickDown);

        dispatcher.Dispatch(Demo1CommandEvent.RequestCommand);
    }

    public override void OnRemove()
    {
        dispatcher.RemoveListener(Demo1MediatorEvent.ScoreChange, OnScoreChange);
        cubeView.dispatcher.RemoveListener(Demo1MediatorEvent.ClickDown, OnClickDown);
    }

    public void OnScoreChange(IEvent evt)
    {
        cubeView.UpdateScore((int)evt.data);
    }

    public void OnClickDown()
    {
        dispatcher.Dispatch(Demo1CommandEvent.UpdateScoreCommand);
    }
}
