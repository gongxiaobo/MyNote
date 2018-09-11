using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     [Serializable]
     [CreateAssetMenu(fileName = "bd_", menuName = "KeyWord/bubble_detail", order = 1)]
     public class BubbleDetail : ScriptableObject
     {
          [Tooltip("类型：unit 为单位类型； name 为值的转换类型")]
          public string m_type = "unit";
          [SerializeField]
          [Tooltip("值<->名称")]
          public List<BubbleDetailKeyValue> m_KeyValues;

     }
     /// <summary>
     /// item的状态值对应的名称
     /// </summary>
     [Serializable]
     public class BubbleDetailKeyValue
     {
          /// <summary>
          /// 状态值
          /// </summary>
          public string m_stateValue;
          /// <summary>
          /// 显示单位
          /// </summary>
          public KeyWords m_ShowValue;
     } 
}
