using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 条件的观察类型配置
     /// </summary>
     [Serializable]
     public class ItemState
     {
          /// <summary>
          /// item id
          /// </summary>
          [Tooltip("item id")]
          [SerializeField]
          public int m_id;
          /// <summary>
          /// item 值类型
          /// </summary>
          [SerializeField]
          [Tooltip("item 值类型")]
          public E_StateValueType m_type;
          /// <summary>
          /// 观察的值
          /// </summary>
          [SerializeField]
          [Tooltip("观察的值")]
          public string m_state;
     }
     /// <summary>
     /// 值类型的条件
     /// </summary>
     [Serializable]
     public class ItemStateFloat
     {
          /// <summary>
          /// item id
          /// </summary>
          [SerializeField]
          public int m_id;
          /// <summary>
          /// item 值类型
          /// </summary>
          [SerializeField]
          public E_StateValueType m_type;
          /// <summary>
          /// 观察的值
          /// </summary>
          [SerializeField]
          public float m_stateMin;
          [SerializeField]
          public E_equal m_logic;

     }
     /// <summary>
     /// 产生结果的类型
     /// </summary>
     [Serializable]
     public class ItemStateResult
     {
          /// <summary>
          /// item id
          /// </summary>
          [Tooltip("effect item id")]
          [SerializeField]
          public int m_Toid;
          /// <summary>
          /// item 值类型
          /// </summary>
          [SerializeField]
          [Tooltip("item 值类型")]
          public E_StateValueType m_type;
          /// <summary>
          /// 观察的值
          /// </summary>
          [SerializeField]
          [Tooltip("观察的值")]
          public string m_state;

          /// <summary>
          /// 消息的类型
          /// </summary>
          [SerializeField]
          [Tooltip("消息的类型")]
          public E_MessageType m_msgType;
     }
     public enum E_equal
     {
          /// <summary>
          /// ==
          /// </summary>
          e_big = 1,
          /// <summary>
          /// >=
          /// </summary>
          e_bigequal = 2,
          /// <summary>
          /// <
          /// </summary>
          e_small = 3,
          /// <summary>
          /// <=
          /// </summary>
          e_smallequal = 4,
     } 
}