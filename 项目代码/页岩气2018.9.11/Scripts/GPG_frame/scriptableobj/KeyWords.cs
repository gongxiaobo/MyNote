using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     [CreateAssetMenu(fileName = "keyword_", menuName = "KeyWord/key", order = 1)]
     public class KeyWords : ScriptableObject
     {
          //[Tooltip("描述的名称")]
          //[SerializeField]
          //public string m_name;
          //[Tooltip("描述")]
          //[SerializeField]
          //public string m_word;
          [Tooltip("描述的选项")]
          [SerializeField]
          public List<KeyString> m_words;

     }
     [Serializable]
     public class KeyString
     {    //名称
          public string m_key;
          //显示值
          public string m_value;

     } 
}