using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace GDGeek{
	public class FSM {
          //状态机的所有状态
		private Dictionary<string, State> states_ = new Dictionary<string, State>();
          /// <summary>
          /// 从父到子的状态排列，root是根状态，一直在0的位置
          /// 这里存储的是现在使用的状态的父子深度信息
          /// 工作状态链
          /// </summary>
		private ArrayList currState_ = new ArrayList();
		
		public FSM(){
			State root = new State();
			root.name = "root";
			this.states_["root"]  = root;
			this.currState_.Add(root);
		}
		public void addState(string stateName, State state){
			this.addState (stateName, state, "");		
		}
		public void addState(string stateName, State state, string fatherName){	
			if(fatherName == ""){
				state.fatherName = "root";
			}
			else{
				state.fatherName = fatherName;
			}
			state.getCurrState = delegate (string name){	
				for(int i = 0; i< this.currState_.Count; ++i){
					State s = this.currState_[i] as State;
					if(s.name == name)
					{
						return s;
					}
					
				}	
				return null;
			};
			this.states_[stateName] = state;
		}

	     /// <summary>
	     /// 关闭已有的状态链
          /// 激活新的状态链
	     /// </summary>
	     /// <param name="name"></param>
		public void translation(string name)
		{
//			Debug.Log ("跳转到=》" + name);
			State target = this.states_[name] as State;//target state
			
			if (target == null)//if no target return!
			{
				return;
			}
			
			
			//if current, reset如果状态机跳转到自己，那就从新开始这个状态
			if(target == this.currState_[this.currState_.Count-1])
			{
				target.over();
				target.start();
				return;
			}
			
			
			//公共的状态，也就是 root根状态
			State publicState = null;
			//找到这个目标状态的方父状态链
			ArrayList stateList = new ArrayList();
			//要跳转到的状态
			State tempState = target;
               //父状态机名称
			string fatherName = tempState.fatherName;
			
			//do loop 找到父状态链
			while(tempState != null)
			{
				//reiterate current list
				for(var i = this.currState_.Count -1; i >= 0; i--){
					State state = this.currState_[i] as State;
					//if has public 
					if(state == tempState){
						publicState = state;	
						break;
					}
				}
				
				//end
				if(publicState != null){
					break;
				}
				
				//else push state_list
				stateList.Insert(0, tempState);
				//state_list.unshift(temp_state);
				
				if(fatherName != ""){
					tempState = this.states_[fatherName] as State;
					fatherName = tempState.fatherName;
				}else{
                         //end
					tempState = null;
				}
				
			}
			//if no public return
			if (publicState == null){
				return;
			}
			//新的状态链，
			ArrayList newCurrState = new ArrayList();
			bool under = true;
			//-- 析构状态，从子状态开始执行结束状态，到了root状态结束
			for(int i2 = this.currState_.Count -1; i2>=0; --i2)
			{
				State state2 = this.currState_[i2] as State;
				if(state2 == publicState)
				{
					under = false;
				}
				if(under){
					state2.over();
				}
				else{
					newCurrState.Insert(0, state2);
				}
				
			}
			
			
			//-- 构建状态,开启新的状态链，从父到子，创建新的状态链
			for(int i3 = 0; i3 < stateList.Count; ++i3){
				State state3 = stateList[i3] as State;
				state3.start();
				newCurrState.Add(state3);
			}
			this.currState_ = newCurrState;
		}


		/// <summary>
		/// 获取给定状态名称的状态是否在工作状态链中
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public State getCurrState(string name)
		{
			var self = this;
			for(var i =0; i< self.currState_.Count; ++i)
			{
				State state = self.currState_[i] as  State;
				if(state.name == name)
				{
					return state;
				}
			}
			
			return null;
			
		}
		
		public void init(string state_name){
			var self = this;
			self.translation(state_name);
		}
		
		/// <summary>
		/// 关闭状态机，停止所有的工作状态，工作状态链置为空
		/// </summary>
		public void shutdown(){
			for(int i = this.currState_.Count-1; i>=0; --i){
				State state =  this.currState_[i] as State;
				state.over();
			}
			this.currState_ = null;  
		}
          /// <summary>
          /// 把str组装成FSMEvent
          /// </summary>
          /// <param name="msg"></param>
		public void post(string msg){
			FSMEvent evt = new FSMEvent();
			evt.msg = msg;
			this.postEvent(evt);
		}
          /// <summary>
          /// 在现在的工作状态链中每个状态执行动作（如果有这个动作）
          /// </summary>
          /// <param name="evt"></param>
		public void postEvent(FSMEvent evt){
			
			for(int i =0; i< this.currState_.Count; ++i){				
				State state = this.currState_[i] as State;
                    //每个状态机中去相应这个命令
				string stateName = state.postEvent(evt) as string;
                    //如果有返回值，那么是状态机之间的跳转，所有调整到指定的状态机
				if(stateName != ""){
					this.translation(stateName);
					break;
				}
			}
		}
	}
}
