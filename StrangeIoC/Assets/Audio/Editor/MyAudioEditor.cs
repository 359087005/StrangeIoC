using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class MyAudioEditor : EditorWindow
{

    private void Awake()
    {
        savePath = Application.dataPath + "\\Audio\\Resources\\AudioList.txt";

        Debug.Log(Application.dataPath);

        LoadAudioList();
    }

    [MenuItem("AudioEditor/AudioEditor")]
    static void CreatWindow()
    {
        Debug.Log("CreatWindow successful.......");
        //Rect rect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
        //AudioEditor window = EditorWindow.GetWindowWithRect(typeof(AudioEditor), rect) as AudioEditor;
        MyAudioEditor window = EditorWindow.GetWindow<MyAudioEditor>("音效管理....");
        
        window.Show();
        Debug.Log(window.name);
    }

    private string _name;
    private string _path;

    private Dictionary<string, string> audioDic = new Dictionary<string, string>();

    private void OnGUI()
    {
        Debug.Log("AudioEditor OnGUI");

        if (audioDic.Count!= 0)
        {
            ShowAudioTitle();
        }
        ShowAudioList();

        _name = EditorGUILayout.TextField("名字", _name);
        _path = EditorGUILayout.TextField("路径", _path);

        if (GUILayout.Button("添加音效"))
        {
            //object o = (Resources.Load(_path));
            //if (o == null)
            //{
            //    Debug.LogError("音效不存在:" + _path);
            //    _path = "";
            //    return;
            //}
            if (audioDic.ContainsKey(_name))
            {
                Debug.LogWarning("音效已存在..." + _name);
                return;
            }
            audioDic.Add(_name, _path);
            SaveAudioList();
        }
        AssetDatabase.Refresh();
    }
    /// <summary>
    /// 添加成功之后在最上方显示的信息菜单
    /// </summary>
    private void ShowAudioTitle()
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label("名称");
        GUILayout.Label("路径");
        GUILayout.Label("操作");
        GUILayout.EndHorizontal();
    }

    /// <summary>
    /// 显示的具体信息菜单
    /// </summary>
    private void ShowAudioList()
    {
        foreach (var key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key, out value);
            
            GUILayout.BeginHorizontal();
            
            GUILayout.Label(key, GUILayout.Width(100));
            GUILayout.FlexibleSpace();
            GUILayout.Label(value, GUILayout.Width(100));
            
            if (GUILayout.Button("删除", GUILayout.Width(100)))
            {
                DeleteAudioInfo(key);
                return;
                //TODO
            }
            GUILayout.EndHorizontal();
        }
    }

    private void DeleteAudioInfo(string key)
    {
        if (audioDic.ContainsKey(key))
        {
            audioDic.Remove(key);
        }
    }


    private string savePath = "";


    /// <summary>
    /// 音效列表信息保存
    /// </summary>
    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key,out value);

            sb.Append(key + ","+value + "\n");
        }
       
        File.WriteAllText(savePath, sb.ToString());
    }


    private void LoadAudioList()
    {
        if (!File.Exists(savePath))
            return;
        audioDic = new Dictionary<string, string>();
        string[] allLines = File.ReadAllLines(savePath);

        foreach (string line in allLines)
        {
            if (string.IsNullOrEmpty(line)) continue;

            string[] keyValue = line.Split(',');

            audioDic.Add(keyValue[0],keyValue[1]);
        }
    }
}
