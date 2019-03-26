using strange.extensions.dispatcher.eventdispatcher.api;
using UnityEngine;

public class ScoreService : IScoreService
{
    [Inject]
    public IEventDispatcher dispatcher
    {
        get;set;
    }

    public void OnReceiveScore()
    {
        int score = Random.Range(0,100);
        dispatcher.Dispatch(Demo1ServiceEvent.RequestScore,score);  //
    }

    public void RequestScore(string url)
    {
        Debug.Log("Request score:" + url);
        OnReceiveScore();
    }

    public void UpdateScore(string url, int score)
    {
        Debug.Log("Update score : " + url + ",new score : "+score);
    }
}
