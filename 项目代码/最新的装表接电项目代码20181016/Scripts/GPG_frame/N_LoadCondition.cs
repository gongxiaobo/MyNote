using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 动态从ConditionsAndResult中加载条件，最多10个条件
     /// </summary>
     [DisallowMultipleComponent]
     public class N_LoadCondition : N_Condition
     {
          protected override void Start()
          {
               base.Start();
               fnp_loadDate();
          }
          protected virtual void fnp_loadDate()
          {
               AB_Name t_name = GetComponent<AB_Name>();
               if (t_name == null)
               {
                    Destroy(this);
                    return;
               }
               string t_foldname = t_name.m_ID.ToString();
               for (int i = 1; i < 11; i++)
               {
                    Object t_date = Resources.Load("ConditionsAndResult/" + t_foldname + "/c" + i.ToString());
                    if (t_date != null)
                    {
                         m_condion.Add(t_date as ConditionDate);
                    }
                    else
                    {
                         break;
                    }
               }
          }
     }

}