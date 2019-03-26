/****************************************************
    文件：ComponentTool.cs
	作者：ICE
    邮箱: 359087005@qq.com
    日期：#CreateTime#
	功能：常见的组件子属性功能修改
*****************************************************/

using UnityEngine;
using UnityEditor;

public class ComponentTool : MonoBehaviour
{
    #region  修改面板中所选择物体下子物体的光照模式
    [MenuItem("Tools/Light/ChangeThisLightChildToBake")]
    public static void ChangeThisLightChildToBake()
    {
        GameObject select = SelectObj();
        ChangeLightMode(select.transform,LightmapBakeType.Baked);
    }
    [MenuItem("Tools/Light/ChangeThisLightChildToMix")]
    public static void ChangeThisLightChildToMix()
    {
        GameObject select = SelectObj();
        ChangeLightMode(select.transform,LightmapBakeType.Mixed);
    }
    [MenuItem("Tools/Light/ChangeThisLightChildToReal")]
    public static void ChangeThisLightChildToReal()
    {
        GameObject select = SelectObj();
        ChangeLightMode(select.transform,LightmapBakeType.Realtime);
    }
    static void ChangeLightMode(Transform trans,LightmapBakeType lbt)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            ChangeLightMode(trans.GetChild(i), lbt);
            if (trans.GetChild(i).GetComponent<Light>() != null)
            {
                trans.GetChild(i).gameObject.GetComponent<Light>().lightmapBakeType = lbt;
            }
        }
    }
    #endregion

    #region  激活/关闭面板中所选择物体下子物体
    [MenuItem("Tools/Active/Open")]
    public static void Open()
    {
        GameObject select = SelectObj();
        CloseOROpen(select.transform,true);
        select.SetActive(true);
    }

    [MenuItem("Tools/Active/Close")]
    public static void Close()
    {
        GameObject select = SelectObj();
        CloseOROpen(select.transform, false);
        select.SetActive(false);
    }

    static void CloseOROpen(Transform trans,bool value)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            CloseOROpen(trans.GetChild(i), value);
            if (trans.GetChild(i) != null)
            {
                trans.GetChild(i).gameObject.SetActive(value);
            }
        }
    }
    #endregion

    #region 面板中所选择物体下子物体collider istrigger
    [MenuItem("Tools/Collider/isTrigger")]
    public static void IsTrigger()
    {
        GameObject select = SelectObj();
        CloseOROpenTrigger(select.transform, true);
    }
    [MenuItem("Tools/Collider/isNotTrigger")]
    public static void IsNotTrigger()
    {
        GameObject select = SelectObj();
        CloseOROpenTrigger(select.transform, false);
    }

    static void CloseOROpenTrigger(Transform trans, bool value)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            CloseOROpen(trans.GetChild(i), value);
            if (trans.GetChild(i) != null)
            {
                trans.GetChild(i).GetComponent<Collider>().isTrigger = value;
            }
        }
    }
    #endregion

    #region 获得面板中选择的物体
    /// <summary>
    /// 获取面板选中的物体
    /// </summary>
    public static GameObject SelectObj()
    {
        GameObject SelectionObj = (GameObject)Selection.activeObject;
        if (SelectionObj != null)
        {
            Debug.Log("当前选择的物体是:" + SelectionObj.name);
            return SelectionObj;
        }
        else

            Debug.LogError("未正确选择物体");
        return null;
    }
    #endregion

    //public void Add()
    //{
    //    AddMeshCollider(this.transform);
    //}

    //public void AddMeshCollider(Transform trans)
    //{
    //    for (int i = 0; i < trans.childCount; i++)
    //    {
    //        AddMeshCollider(trans.GetChild(i));
    //        if (trans.GetChild(i).GetComponent<MeshFilter>() != null)
    //        {
    //            trans.GetChild(i).gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
    //            //trans.GetChild(i).gameObject.AddComponent<MeshCollider>();
    //        }
    //    }
    //}
}

