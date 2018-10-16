using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     /// <summary>
     /// 单泵下一个参数变化，通知其他参数
     /// </summary>
     public class N_BumpSCMgr : AB_BumpSCMgr
     {
          List<AB_BumpStateChange> m_items;
          protected override void Start()
          {
               base.Start();
               m_items = transform.FindInChlid<AB_BumpStateChange>();
          }
          public override void fn_sendChange(int _itemID)
          {
               for (int i = 0; i < m_items.Count; i++)
               {
                    m_items[i].fn_itemChange(_itemID);
               }
          }
     } 
}
