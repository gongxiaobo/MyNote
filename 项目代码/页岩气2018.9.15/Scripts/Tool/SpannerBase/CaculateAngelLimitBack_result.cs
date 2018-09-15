using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 处理锁定和结束锁定的逻辑触发
     /// </summary>
     public class CaculateAngelLimitBack_result : CaculateAngelLimitBack
     {

          protected override void fnp_back()
          {
               base.fnp_back();
               //锁定
               fnp_Result("lock");
               //fnp_setLevel(0f);
               //Debug.Log("<color=red>球阀在 0位置</color>");
          }
          protected override void fnMoreThan()
          {
               fnp_Result("unlock");
               base.fnMoreThan();
               //结束锁定

               fnp_setLevel(1f);

               Debug.Log("<color=red>球阀在 1 位置</color>");

          }
          protected virtual void fnp_setLevel(float _level)
          {
               StateValue t_sv = m_handleEvent.fn_get("level");
               if (t_sv != null)
               {
                    StateValueString t_s = t_sv as StateValueString;
                    t_s.m_date = _level.ToString();
                    m_handleEvent.fn_set(t_s);
                    //fnp_Result("on");
               }
          }

     }

}