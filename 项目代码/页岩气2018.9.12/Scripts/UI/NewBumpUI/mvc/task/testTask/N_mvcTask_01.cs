using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 普通任务，开始切换到指定界面,然后隐藏所有界面
/// </summary>
public class N_mvcTask_01 : N_mvcTask
{

     public override void fn_handle(UIMsg _msg)
     {
          m_nowMsg = _msg;
          base.fn_handle(_msg);
         
     }
     UIMsg m_nowMsg;
     protected override void fnp_doTask()
     {
          base.fnp_doTask();
          UIMsg t_initPanel = new UIMsg();
          t_initPanel.fn_putMsg(E_MsgType.e_normal, 0, 0, "show",
               new string[1]{"showPanelName"},
               new string[1] { m_nowMsg.m_contents[0]});

     }
	
}
