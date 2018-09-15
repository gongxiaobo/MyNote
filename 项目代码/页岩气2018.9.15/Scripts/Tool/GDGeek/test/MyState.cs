using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDGeek;
public class MyState : MonoBehaviour {
     FSM myFSM = new FSM();
	// Use this for initialization
	void Start () {
          myFSM.addState("empty", fnp_empty());
          myFSM.addState("state1", fnp_state1());
          myFSM.addState("taskState", fnp_taskState());
          //子状态
          myFSM.addState("state1_clid1", fn_state1_clid1(), "state1");



          myFSM.init("state1_clid1");
	}
	
	// Update is called once per frame
	void Update () {
          if (Input.GetKeyDown(KeyCode.T))
          {
               myFSM.post("toState1");
          }
          if (Input.GetKeyDown(KeyCode.D))
          {
               myFSM.post("do");
          }
	}
     State fnp_empty()
     {
          StateWithEventMap t_st = new StateWithEventMap();
          t_st.onStart += () => {
               
               Debug.Log("<color=blue>进入空的状态机</color>");
          };

          t_st.onOver += () => {

               Debug.Log("<color=blue>退出空的状态机</color>");    
          };
          t_st.addEvent("toState1", "state1");
          return t_st;
     }

     State fnp_state1()
     {
          StateWithEventMap t_st = new StateWithEventMap();
          t_st.onStart += () => {
               Debug.Log("<color=blue>进入状态机1</color>");
          };
          return t_st;
     }

     //有任务的状态机
     State fnp_taskState()
     {
          StateWithEventMap t_state = TaskState.Create(() => {
               TaskWait tw = new TaskWait();
               tw.setAllTime(3f);
               return tw; }, myFSM, "state1");
          t_state.onStart += () => {

               Debug.Log("<color=blue>有任务的状态机开始工作</color>");
     
          };
          t_state.onOver += () => {
               Debug.Log("<color=blue>有任务的状态机结束工作</color>");
          };
          return t_state;
     }
     State fn_state1_clid1()
     {
          StateWithEventMap t_state = new StateWithEventMap();
          t_state.onStart += () =>
          {    
               Debug.Log("<color=blue>state1的子状态机 </color>");
          };
          t_state.onOver += () => { };

          t_state.addAction("do", (FSMEvent _evt) => {


               Debug.Log("<color=blue>动作=</color>" + _evt.msg);
     
          });
          return t_state;
     }
     State fn_state1_clid2()
     {
          StateWithEventMap t_state = new StateWithEventMap();
          t_state.onStart += () =>
          {
               Debug.Log("<color=blue>state1的子状态机 </color>");
          };
          t_state.onOver += () => { };

          t_state.addAction("do", (FSMEvent _evt) =>
          {
               Debug.Log("<color=blue>做完动作后跳转到 state1 的状态</color>" + _evt.msg);
               //有返回值的话，会跳转到这个状态下。
               return "state1";

          });
          return t_state;
     }
}
