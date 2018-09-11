using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{

     /// <summary>
     /// CDP的控制接口单例
     /// 通过组名，成员名，获取相关数据
     /// </summary>
     public class S_CDPControl : GenericSingletonClass<S_CDPControl>
     {
          /// <summary>
          /// itemID 对应的I_CDPSet接口
          /// </summary>
          protected Dictionary<int, I_CDPSet> m_cdpControl = new Dictionary<int, I_CDPSet>();
          public void fn_logCDPSet(int _id, I_CDPSet _set)
          {
               if (!m_cdpControl.ContainsKey(_id))
               {
                    m_cdpControl.Add(_id, _set);
               }
          }
          /// <summary>
          /// 获取控制接口
          /// </summary>
          /// <param name="_ItemID"></param>
          /// <returns></returns>
          public I_CDPSet fn_getCDPSet(int _ItemID)
          {
               if (m_cdpControl.ContainsKey(_ItemID))
               {
                    return m_cdpControl[_ItemID];
               }
               return null;
          }

          /// <summary>
          /// 获取CDP的分组数量和成员数量
          /// </summary>
          /// <returns>Dictionary<组的ID, 成员的数量></returns>
          public Dictionary<int, int> fnp_getNumDate()
          {
               if (S_LoadTable.Instance.M_cdp_itemNum != null)
               {
                    return S_LoadTable.Instance.M_cdp_itemNum;
               }
               return null;
          }
          /// <summary>
          /// 获取组的名称
          /// </summary>
          /// <param name="_group"></param>
          /// <returns></returns>
          public string fn_getGroupName(int _group)
          {
               if (S_LoadTable.Instance.M_groupname.ContainsKey(_group.ToString()))
               {
                    return S_LoadTable.Instance.M_groupname[_group.ToString()].m_name;
               }
               return "";
          }
          /// <summary>
          /// 获取成员名称
          /// </summary>
          /// <param name="_member"></param>
          /// <returns></returns>
          public string fn_getMemberName(int _group, int _member)
          {
               cdp_item t_item = fnp_getCDPItem(_group, _member);
               if (t_item != null)
               {
                    return t_item.m_memberName;
               }
               return "";
          }
          /// <summary>
          /// 获取成员的值
          /// </summary>
          /// <param name="_group"></param>
          /// <param name="_member"></param>
          /// <returns></returns>
          public string fn_getMemberValue(int _group, int _member)
          {
               I_CDPSet ti_cdpset = fn_getCDPSet(_group, _member);
               if (ti_cdpset != null)
               {
                    return ti_cdpset.fni_getValue();
               }
               return "";
          }
          /// <summary>
          /// 获取成员的值+单位
          /// </summary>
          /// <param name="_group"></param>
          /// <param name="_member"></param>
          /// <returns></returns>
          public string fn_getMemberValueWithUnit(int _group, int _member)
          {
               return fn_getMemberValue(_group, _member) + " " + fn_getMemberUnit(_group, _member);
          }
          /// <summary>
          /// 获取成员的单位
          /// </summary>
          /// <param name="_group"></param>
          /// <param name="_member"></param>
          /// <returns></returns>
          public string fn_getMemberUnit(int _group, int _member)
          {
               cdp_item t_item = fnp_getCDPItem(_group, _member);
               if (t_item != null)
               {
                    return t_item.m_unit;
               }
               return "";
          }
          /// <summary>
          /// 根据组id 和 成员id 获取改变参数的接口
          /// </summary>
          /// <param name="_group"></param>
          /// <param name="_member"></param>
          /// <returns></returns>
          public I_CDPSet fn_getCDPSet(int _group, int _member)
          {
               cdp_item t_item = fnp_getCDPItem(_group, _member);
               if (t_item != null)
               {
                    int t_itemID = t_item.m_itemID;
                    if (m_cdpControl.ContainsKey(t_itemID))
                    {
                         return m_cdpControl[t_itemID];
                    }
               }

               return null;
          }
          protected cdp_item fnp_getCDPItem(int _group, int _member)
          {
               if (S_LoadTable.Instance.M_cdpItems.ContainsKey(_group))
               {
                    if (S_LoadTable.Instance.M_cdpItems[_group].ContainsKey(_member))
                    {
                         return S_LoadTable.Instance.M_cdpItems[_group][_member];

                    }
               }
               return null;
          }
          /// <summary>
          /// 获取cdp 的item ID
          /// </summary>
          /// <param name="_group"></param>
          /// <param name="_member"></param>
          /// <returns></returns>
          public int fn_getCDPItemID(int _group, int _member)
          {
               cdp_item t_item = fnp_getCDPItem(_group, _member);
               return (t_item != null) ? t_item.m_itemID : 0;
          }


     }

}