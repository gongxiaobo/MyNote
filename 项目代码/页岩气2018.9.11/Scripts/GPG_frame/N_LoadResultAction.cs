using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 动态从ConditionsAndResult中加载反射触发，最多10个反射
     /// </summary>
     [DisallowMultipleComponent]
     public class N_LoadResultAction : N_ResultAction
     {
          protected override void Start()
          {
               base.Start();
               fnp_loadDate();
          }
          protected virtual void fnp_loadDate()
          {
               if (m_name == null)
               {
                    return;
               }

               string t_foldname = m_ID.ToString();
               for (int i = 1; i < 11; i++)
               {
                    Object t_date = Resources.Load("ConditionsAndResult/" + t_foldname + "/r" + i.ToString());
                    if (t_date != null)
                    {
                         m_ResultDate.Add(t_date as ResultDate);
                    }
                    else
                    {
                         break;
                    }
               }
          }
     }

}