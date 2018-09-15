using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     /// <summary>
     /// 条件的数据存储
     /// </summary>
     [Serializable]
     [CreateAssetMenu(fileName = "ConditionDate_", menuName = "ConditionResult/condition", order = 1)]
     public class ConditionDate : ScriptableObject
     {
          [Tooltip("条件名称")]
          public string m_conditionName = "";
          [Tooltip("条件列表")]
          [SerializeField]
          public List<ItemState> m_condion1 = new List<ItemState>();
     } 
}
