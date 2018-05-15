using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 整体介绍的信息获取
     /// </summary>
     public class N_showIntroduceData : AB_GetData
     {

          public int m_macID = 0;
          public override void fn_showDate()
          {
               //throw new System.NotImplementedException();
               fn_getDate();
          }

          public override void fn_hideDtae()
          {
               //throw new System.NotImplementedException();
          }
          protected introduce m_info = null;
          protected override void fn_getDate()
          {
               m_info = m_info ?? S_LoadTable.Instance.fn_getIntroduceInfo(m_macID);

          }
     } 
}
