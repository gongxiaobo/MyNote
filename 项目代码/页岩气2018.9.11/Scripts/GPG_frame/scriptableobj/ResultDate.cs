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
     [CreateAssetMenu(fileName = "ResultDateDate_", menuName = "ConditionResult/result", order = 1)]
     public class ResultDate : ScriptableObject
     {
          [Tooltip("条件名称")]
          public string m_ResultName = "";
          [Tooltip("条件列表")]
          [SerializeField]
          public List<ItemStateResult> m_result = new List<ItemStateResult>();
     }

}