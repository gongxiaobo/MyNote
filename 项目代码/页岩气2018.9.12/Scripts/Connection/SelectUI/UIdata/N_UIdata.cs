using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     [Serializable]
     [CreateAssetMenu(fileName = "UI_data", menuName = "UIDate/uidata", order = 1)]
     public class N_UIdata : ScriptableObject
     {
          [SerializeField]
          public List<UIdata1> m_datas = new List<UIdata1>();
     } 
}
