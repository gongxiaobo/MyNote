using UnityEngine;
using System.Collections;
//using GCode;
namespace GasPowerGeneration
{
     public class S_HandButton : GenericSingletonClass<S_HandButton>
     {
          /// <summary>
          /// 手柄按键的控制
          /// </summary>
          public A_HandButton m_handeButton;
          /// <summary>
          /// 手柄上UI的显示控制
          /// </summary>
          public A_HandTip m_handTip;

          private I_HandButton m_getRigid;

          public I_HandButton GetRigid
          {
               get { return m_getRigid; }
               set
               {
                    if (m_getRigid == null)
                    {
                         m_getRigid = value;
                    }
               }
          }
          /// <summary>
          /// 右手的高亮按钮的控制类
          /// </summary>
          private AB_HandModel m_RightHandLightBtn;

          public AB_HandModel RightHandLightBtn
          {
               get { return m_RightHandLightBtn; }
               set
               {
                    if (m_RightHandLightBtn == null)
                    {
                         m_RightHandLightBtn = value;
                    }
               }
          }

          AB_ActionTip m_actionTip;

          public AB_ActionTip ActionTip
          {
               get { return m_actionTip; }
               set
               {
                    if (m_actionTip == null)
                    {
                         m_actionTip = value;
                    }
               }
          }

     } 
}
