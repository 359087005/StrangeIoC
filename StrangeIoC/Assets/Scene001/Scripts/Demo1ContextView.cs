using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Demo1ContextView : ContextView
{
    private void Awake()
    {
        Debug.Log("Demo1ContextView Awake");
        this.context = new Demo1Context(this);
    }
}
