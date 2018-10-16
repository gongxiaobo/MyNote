using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// mvc模式下的任务处理
/// </summary>
public abstract class AB_mvcTask : MonoBehaviour {

	// Use this for initialization
	protected virtual void Start () {
		
	}
     /// <summary>
     /// 处理消息的任务的名称
     /// </summary>
     public string m_taskName = "";
     /// <summary>
     /// 处理收到消息
     /// </summary>
     /// <param name="_msg"></param>
     public abstract void fn_handle(UIMsg _msg);
     /// <summary>
     /// 任务进行
     /// </summary>
     protected abstract void fnp_doTask();

	
}
