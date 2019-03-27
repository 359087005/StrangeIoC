using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     继承于View  谨慎重写 start 和Awake   父类已经使用
/// </summary>
public class CubeView : View
{
    [Inject]
    public IEventDispatcher dispatcher { get; set; }
    [Inject]
    public AudioManager audioManager { get; set; }

    private Text scoreText;

    public void Init()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    public void Update()
    {
        //transform.Translate(new Vector3(Random.Range(-1,2),Random.Range(-1,2),0) * 0.1f);
    }

    private void OnMouseDown()
    {
        //加分
        Debug.Log("OnMouseDown");
        audioManager.Play("hit");
        dispatcher.Dispatch(Demo1MediatorEvent.ClickDown);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
