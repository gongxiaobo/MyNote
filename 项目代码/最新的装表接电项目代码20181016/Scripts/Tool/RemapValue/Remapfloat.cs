using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 重新映射float值
     /// </summary>
     public class Remapfloat
     {

          float m_outMax = 100, m_outMin = 0, m_inMax = 100, m_inMin = 0;
          bool m_inputValueLegal = true;
          public Remapfloat(float _outMax, float _outMin, float _inMax, float _inMin)
          {
               if (_outMax <= _outMin || _inMax <= _inMin)
               {//不合法的值
                    m_inputValueLegal = false;

                    Debug.Log("<color=red>not legal value</color>");

               }
               else
               {
                    m_outMax = _outMax;
                    m_outMin = _outMin;
                    m_inMax = _inMax;
                    m_inMin = _inMin;
                    fnp_getFactor();
               }


          }
          public float fn_remap(float _invalue)
          {
               if (_invalue >= m_inMax)
               {
                    return m_outMax;
               }
               if (_invalue <= m_inMin)
               {
                    return m_outMin;
               }
               //计算输出


               return (_invalue - m_inMin) * m_factor + m_outMin;
               //return _invalue * m_factor ;
          }
          float m_factor = 1f;
          protected void fnp_getFactor()
          {
               m_factor = (m_outMax - m_outMin) / (m_inMax - m_inMin);
          }

     }

}