using UnityEngine;
using System.Collections;
using System;

namespace GasPowerGeneration.update
{
	///<summary>
	///@ version 1.0 /2017.0504/ :动态update组件
	///@ author gong
	///@ version 1.1 /2017./ :
	///@ author gong
	///@ version 1.2 /2017./ :
	///@ author gong
	///@ version 1.3 /2017./ :
	///@ author gong
	///</summary>
	public abstract class AB_UpdateCom : MonoBehaviour
	{
		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="_call">需要调用的函数</param>
		public abstract void fn_init (Action _call);
		/// <summary>
		/// 初始化时：注册事件始终保持一个链接
		/// </summary>
		public abstract void fn_init (Action _call,bool _only);
		/// <summary>
		/// 销毁此组件
		/// </summary>
		public abstract void fn_kill ();
		/// <summary>
		/// 暂停
		/// </summary>
		/// <param name="_bl">If set to <c>true</c> 暂停</param>
		public abstract void fn_pause (bool _bl);
		/// <summary>
		/// 移除函数接口
		/// </summary>
		/// <param name="_func">Func.</param>
		public abstract void fn_remove(Action _func);
	
	}
}
