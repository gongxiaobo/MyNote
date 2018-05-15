using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GDGeek{
     /// <summary>
     /// 有事件映射表的状态机
     /// 事件包含：无参，无返事件，有参无返事件，有参有返事件
     /// </summary>
	public class StateWithEventMap:State {
		public delegate void Action();
		public delegate void EvtAction(FSMEvent evt);
		public delegate string StateAction(FSMEvent evt);

		private Dictionary<string, StateAction> actionMap_ = 
               new Dictionary<string,StateAction>();
	
		public event Action onOver;
		public event Action onStart;
		/// <summary>
		/// 添加事件,状态机之间的跳转
		/// </summary>
		/// <param name="evt"></param>
		/// <param name="nextState"></param>
		public void addEvent(string evt, string nextState){
			actionMap_.Add (evt, delegate {
								return nextState;
							});
		}
		
		public void addAction(string evt, StateAction action){
			actionMap_.Add (evt, action);
		}
          /// <summary>
          /// 一个状态机中可以触发的动作
          /// </summary>
          /// <param name="evt"></param>
          /// <param name="action"></param>
		public void addAction(string evt, EvtAction action){
               //组装成StateAction类型，放入到映射表中
			actionMap_.Add (evt, delegate(FSMEvent e) {
				action(e);
				return "";
			});
		}
	     /// <summary>
	     /// 这个状态机上执行的动作和事件
	     /// </summary>
	     /// <param name="evt"></param>
	     /// <returns>如果有返回值，那是要跳转到下一个状态机的名称</returns>
		public override string postEvent(FSMEvent evt){
			string ret = "";
			if(actionMap_.ContainsKey(evt.msg)){
				ret = actionMap_[evt.msg](evt);
			}
			return ret;			

		}
		public override void start ()
		{
			if(onStart != null)
				onStart ();
		}
		public override void over ()
		{
			if(onOver != null)
				onOver ();
		}
	}
}