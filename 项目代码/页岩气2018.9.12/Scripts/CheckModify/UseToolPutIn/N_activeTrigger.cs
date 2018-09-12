using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 使用工具放入零件后，开启或者关闭零件的触发器
     /// </summary>
     public class N_activeTrigger : AB_activeTrigger
     {

          public int m_id = 0;
          public override void fn_setTriggerInfor(int _id)
          {
               m_id = _id;
          }
          bool m_show = true;
          bool m_active = false;
          public override void fn_setTrigger(bool _show = true)
          {
               if (m_active)
               {
                    return;
               }
               m_active = true;
               m_show=_show;
               Invoke("fnp_show", 1.5f);
          }

          private void fnp_show()
          {
               //使用工具的触发器的开启或者关闭
               S_ToolTrigger.Instance.fn_SetToolTrigger(m_id, m_show);
               Destroy(this);
          }
     } 
}
