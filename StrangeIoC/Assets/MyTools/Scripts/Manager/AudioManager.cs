using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{
    private const string audioTextPathPrefix = "\\MyTools\\Resources\\";
    private const string audioTextPathMiddlefix = "AudioList";
    private const string audioTextPathPostfix = ".txt";
    public static string AudioPath
    {
        get
        {
            return Application.dataPath +
                audioTextPathPrefix +
                audioTextPathMiddlefix +
                audioTextPathPostfix;
        }
    }

    private Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();

    public bool isMute = false;

    //public AudioManager()
    //{
    //    LoadAudioClip();
    //}

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        TextAsset ta = Resources.Load<TextAsset>(audioTextPathMiddlefix);

        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
                continue;
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDic.Add(key, value);
        }
    }

    public void Play(string name)
    {
        Play(name, Vector3.zero);
    }

    public void Play(string name, Vector3 position)
    {
        if (isMute) return;

        AudioClip ac;
        audioClipDic.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, position);
        }
    }

    //public void MuteSet(bool isMute)
    //{
    //    if(isMute)
    //        AudioSource.p
    //}
}
