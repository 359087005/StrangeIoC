using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源池
/// </summary>
[Serializable]
public class GameObjectPool
{
    private string name;
    private GameObject prefab;
    private int maxAmount;

    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();
}
