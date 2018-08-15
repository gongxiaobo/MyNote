using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 动态生成模型
/// </summary>
public abstract class AB_BirthMesh : MonoBehaviour {
     /// <summary>
     /// 一些初始化的设置
     /// </summary>
     public abstract void fn_init();
     /// <summary>
     /// 生成路径
     /// </summary>
     protected abstract void fn_birhtPath();
     /// <summary>
     /// 生成基础形状
     /// </summary>
     protected abstract void fn_birthShape();
     /// <summary>
     /// 生成模型
     /// </summary>
     protected abstract void fn_makeMesh();
     /// <summary>
     /// 请求创建模型，反馈给请求者
     /// </summary>
     /// <param name="_callback">回调</param>
     public abstract void fn_BirthMesh(Action _callback);
     /// <summary>
     /// 模型创建后附加在这个物体上
     /// </summary>
     public abstract GameObject M_MeshObj { get; }
     /// <summary>
     /// 销毁生成模型数据
     /// </summary>
     public abstract void fn_kill();
     /// <summary>
     /// 刷新位置，重新生成模型
     /// </summary>
     public abstract void fn_refresh();


}
