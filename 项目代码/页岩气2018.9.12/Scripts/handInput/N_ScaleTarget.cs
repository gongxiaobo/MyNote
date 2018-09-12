using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     //using DG.Tweening;
     /// <summary>
     /// 对于射线选中物体的缩放效果
     /// </summary>
     public class N_ScaleTarget : A_TriggerObj
     {
          protected Vector3 m_scale;
          protected Transform m_thisObj = null;
          public float m_scaleFactor = 1.2f;
          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (m_thisObj == null)
               {
                    m_thisObj = transform;
                    m_scale = m_thisObj.localScale;
               }
               if (_button == E_buttonIndex.e_padTouched)
               {
                    m_thisObj.localScale *= m_scaleFactor;
                    //m_thisObj.DOScale(m_thisObj.localScale.x * m_scaleFactor, 0.35f).SetEase(Ease.InBounce);
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    m_thisObj.localScale = m_scale;
                    //m_thisObj.DOScale(m_scale.x, 0.2f).SetEase(Ease.InBounce);
               }
          }

     } 
}
