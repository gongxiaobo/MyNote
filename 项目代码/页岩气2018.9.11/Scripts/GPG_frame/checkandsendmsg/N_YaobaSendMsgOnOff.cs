using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理摇把在最大值和最小值的发送值情况
     /// </summary>
     public class N_YaobaSendMsgOnOff : N_YaobaSendMsg, I_setBool
     {
          protected bool m_sendMsgSmall = false;
          protected bool m_sendMsgBig = true;
          protected string m_stateName = "";
          protected override bool fnp_Check()
          {
               if (m_spanner != null)
               {
                    if (m_spanner.fni_valueToBig() && m_sendMsgBig)
                    {//最大值时
                         m_stateName = "big";
                         return true;
                    }
                    else if (m_spanner.fni_valueToSmall() && m_sendMsgSmall)
                    {//最小值时
                         m_stateName = "small";
                         return true;
                    }
                    else
                    {
                         m_stateName = "";
                         return false;
                    }

               }
               else
               {

                    return true;
               }
          }
          protected override void fnp_SendMsg()
          {
               //base.fnp_SendMsg();
               if (m_stateName == "big")
               {
                    fnp_sendOn(m_flipSendMsg ? "off" : "on");
               }
               else if (m_stateName == "small")
               {
                    fnp_sendOn(m_flipSendMsg ? "on" : "off");
               }


          }
          protected bool m_flipSendMsg = false;


          #region I_setBool
          public void fni_setbig(bool _isbl)
          {
               m_sendMsgBig = _isbl;
          }

          public void fni_setsmall(bool _isbl)
          {
               m_sendMsgSmall = _isbl;
          }


          public void fni_setflip(bool _isbl)
          {
               m_flipSendMsg = _isbl;
          }
          #endregion
     }

}