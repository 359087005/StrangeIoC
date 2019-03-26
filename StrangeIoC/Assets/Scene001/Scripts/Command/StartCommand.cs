using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCommand : Command
{
    /// <summary>
    /// 当这个命令呗执行绑定之后，默认调用execute方法
    /// </summary>
    public override void Execute()
    {
        Debug.Log("我被绑定了...");
    }
}
