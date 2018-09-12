using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace GasPowerGeneration
{
     [Serializable]
     [CreateAssetMenu(fileName = "mat_data_", menuName = "MatObj/materialObj", order = 1)]
     public class MaterialObj : ScriptableObject
     {
          [SerializeField]
          public List<MaterialObjData> m_materials = new List<MaterialObjData>();
          public Material fn_get(string _name)
          {
               for (int i = 0; i < m_materials.Count; i++)
               {
                    if (_name== m_materials[i].m_name)
                    {
                         return m_materials[i].m_material;
                    }
               }
               return null;
          }

     } 
}
