using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// CDP的设置项表格类型
     /// </summary>
     public class cdp_item
     {
          /// <summary>
          /// 编号
          /// </summary>
          public string m_index;
          /// <summary>
          /// 分组号
          /// </summary>
          public int m_groupname;
          /// <summary>
          /// 成员项目号
          /// </summary>
          public int m_member;
          /// <summary>
          /// 成员名称
          /// </summary>
          public string m_memberName;
          /// <summary>
          /// 成员的item id 编号
          /// </summary>
          public int m_itemID;
          /// <summary>
          /// 值的类型
          /// </summary>
          public string m_type;
          /// <summary>
          /// 值，包括范围值，多个值
          /// 还需要进一步拆分
          /// </summary>
          public string m_values;
          /// <summary>
          /// 单位
          /// </summary>
          public string m_unit;
          /// <summary>
          /// 普通选择速度
          /// </summary>
          public string m_select1;
          /// <summary>
          /// 快速选择速度
          /// </summary>
          public string m_select2;
     }

}