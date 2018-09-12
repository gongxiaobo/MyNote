using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 从handevent中添加初始化后的事件，触发关闭
     /// 用于初始化的零件暂时不被操作，需要其他零件达成条件后触发后才能操作
     /// </summary>
     public class N_PartTriggerInit_1 : AB_PartTriggerInit
     {
          AB_HandleEvent t_handevent;
          protected override void Start()
          {
               base.Start();
                t_handevent = GetComponent<AB_HandleEvent>();
               if (t_handevent!=null)
               {
                    t_handevent.fn_addInitFinishEvent(fnp_init);
               }
               else
               {
                    Debug.Log("<color=red>not find AB_HandleEvent!</color>");
               }
          }

          protected override void fnp_init()
          {
               
               if (t_handevent == null)
               {
                    Debug.Log("<color=red>not find AB_HandleEvent!</color>");
                    return;
               }

               Invoke("fnp_SetToCanNotTouch", 0.25f);
               

          }
          /// <summary>
          /// 设置机器的状态
          /// </summary>
          /// <param name="_stateName"></param>
          /// <param name="_state"></param>
          protected void fnp_setLockState(string _stateName,string _state)
          {
               AB_SetState t_setState = new N_SetState();
               t_setState.fn_setState(_stateName, _state, t_handevent);
          }
          /// <summary>
          /// 设置关闭触发器，暂时不可以操作
          /// </summary>
          protected virtual void fnp_SetToCanNotTouch()
          {
               AB_ThePart t_part = GetComponentInChildren<AB_ThePart>();
               if (t_part!=null)
               {
                    t_part.gameObject.AddComponent<N_ColliderSound>();
               }
               fnp_DoInit();
               fnp_kill();
          }

          protected virtual void fnp_DoInit()
          {
               fnp_setLockState("lock", "lock");
               //从AB_PullOut类中实现的接口来隐藏零件的拉出触发器
               I_PullOutTrigger t_pullTrigger = GetComponent<I_PullOutTrigger>();
               if (t_pullTrigger != null)
               {
                    t_pullTrigger.fni_SetPartTrigger(false);
               }
               else
               {

                    Debug.Log("<color=red>not find I_PullOutTrigger!</color>");

               }
          }

          protected override void fnp_kill()
          {
               Destroy(this);
          }
     }

}