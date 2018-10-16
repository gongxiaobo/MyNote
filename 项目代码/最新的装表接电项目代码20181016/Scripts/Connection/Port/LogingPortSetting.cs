using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Connection.Port
{
     /// <summary>
     /// 注册柜体的相交平面的信息
     /// </summary>
     class LogingPortSetting:MonoBehaviour
     {
          public PortPathSetting m_PortPathSetting = null;
          void Awake()
          {
               if (m_PortPathSetting == null)
               {
                    Object t_date = Resources.Load("ConnectionPortPath/" + this.gameObject.name);
                    if (t_date != null)
                    {
                         if (t_date is PortPathSetting)
                         {
                              m_PortPathSetting = t_date as PortPathSetting; 
                         }
                    }
                    else
                    {
                         Debug.Log(this.gameObject.name + "<color=red> not find PortPathSetting !</color>");
                    }
               }
               if (m_PortPathSetting!=null)
               {
                    S_PortSettingInfo.Instance.fn_loging(m_PortPathSetting.m_CabinetName, m_PortPathSetting);
               }
          }
          //void Start()
          //{
               
          //}
     }
}
