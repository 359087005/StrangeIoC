using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioEditor : EditorWindow
{
    [MenuItem("Tools/AudioEditor")]
    static void CreatWindow()
    {
        //Rect rect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);
        //AudioEditor window = EditorWindow.GetWindowWithRect(typeof(AudioEditor), rect) as AudioEditor;
        AudioEditor window = EditorWindow.GetWindow<AudioEditor>("音效管理");

        window.Show();
    }

    private string _name;
    private string _path;

    private Dictionary<string, string> audioDic = new Dictionary<string, string>();
    private void OnGUI()
    {
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
        }
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
                //DeleteAudioInfo(key);
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
            AssetDatabase.Refresh();
        }
    }
}
