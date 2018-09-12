using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 条件的判断类型
     /// </summary>
     [Serializable]
     public class N_Condition : AB_Condition
     {
          protected I_CheckValue mi_checkvalue;
          protected override void Start()
          {
               base.Start();
               mi_checkvalue = S_SceneMagT1.Instance;
          }

          [SerializeField]
          protected List<ConditionDate> m_condion = new List<ConditionDate>();
          public override bool fn_check(string _what)
          {
               if (mi_checkvalue == null)
               {
                    return true;
               }
               if (m_condion.Count == 0)
               {
                    return true;
               }
               bool t_pass = true;
               for (int i = 0; i < m_condion.Count; i++)
               {
                    if (m_condion[i].m_conditionName == _what)
                    {
                         for (int j = 0; j < m_condion[i].m_condion1.Count; j++)
                         {
                              if (mi_checkvalue.fni_checkDate(
                                   m_condion[i].m_condion1[j].m_id,
                                   m_condion[i].m_condion1[j].m_type)
                                   == m_condion[i].m_condion1[j].m_state)
                              {
                                   continue;
                              }
                              else
                              {//条件不通过
                                   fnp_debug(i, j);
     
                                   t_pass = false;
                                   break;
                              }
                         }
                         if (t_pass == false)
                         {
                              break;
                         }

                    }
               }

               return t_pass;
          }

          private void fnp_debug(int i, int j)
          {

               Debug.Log("<color=red>条件不满足：</color>" + m_condion[i].m_condion1[j].m_id);
          }
     } 
}
