using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Panel的管理类
/// </summary>
public abstract class AB_PanelMgr : MonoBehaviour {

	// Use this for initialization
	protected virtual void Start () {
		
	}
     /// <summary>
     /// 显示
     /// </summary>
     public abstract void fn_show();
     /// <summary>
     /// 隐藏
     /// </summary>
     public abstract void fn_hide();
	
}
