using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo1Context : MVCSContext
{
    public Demo1Context(MonoBehaviour view) : base(view)
    {

    }

    /// <summary>
    /// 进行绑定映射
    /// </summary>
    protected override void mapBindings()
    {
        Debug.Log("最初开始先执行绑定...");
        //1 model
        Debug.Log("绑定model...");
        injectionBinder.Bind<ScoreModel>().To<ScoreModel>().ToSingleton();
        //2 service
        Debug.Log("绑定service...");
        injectionBinder.Bind<IScoreService>().To<ScoreService>().ToSingleton(); //只会在对象中生成一个
        //3 command
        Debug.Log("绑定command...");
        commandBinder.Bind(Demo1CommandEvent.RequestCommand).To<RequestScoreCommand>();
        commandBinder.Bind(Demo1CommandEvent.UpdateScoreCommand).To<UpdateScoreCommand>();
        //4 mediator
        Debug.Log("绑定mediator...");
        mediationBinder.Bind<CubeView>().To<CubeMediator>();//完成view 和mediator的绑定
        //创建一个开始命令 绑定开始事件 
        //strangeIoc 内部事件  
        //只绑定一次  之后解绑
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
    }
}
