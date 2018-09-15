using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 高亮显示
     /// </summary>
     public class test_ChangeMat : MonoBehaviour
     {
          public Material m_light = null;
          protected Material m_default = null;
          MeshRenderer m_mr = null;
          // Use this for initialization
          void Start()
          {
               m_mr = GetComponent<MeshRenderer>();
               m_default = m_mr.material;
          }
          #region 选中接口的高亮显示
          public bool m_isLight = false;
          public void fn_light()
          {
               m_mr.material = m_light;
               m_isLight = true;
          }
          public void fn_back()
          {
               m_mr.material = m_default;
               m_isLight = false;
          }
          #endregion
          /// <summary>
          /// 射线的击中和离开材质高亮显示
          /// </summary>
          /// <param name="_islight"></param>
          public void fn_TouchColorChange(bool _islight)
          {
               if (m_isLight)
               {
                    return;
               }
               if (_islight)
               {
                    m_mr.material = m_light;
               }
               else
               {
                    m_mr.material = m_default;
               }

          }
     } 
}
