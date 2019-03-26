using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 让外部获取调用   接口的目的是  一个接口可以有多个实现
/// </summary>
public interface IScoreService
{
     void RequestScore(string url);
     void OnReceiveScore();
     void UpdateScore(string url,int score);

    IEventDispatcher dispatcher { get; set; }
}
