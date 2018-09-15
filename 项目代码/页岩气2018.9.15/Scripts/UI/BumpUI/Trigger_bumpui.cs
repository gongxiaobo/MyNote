using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
namespace GasPowerGeneration
{
     [DisallowMultipleComponent]
     public class Trigger_bumpui : N_lightTargetWithLine, IPointerDownHandler, IPointerUpHandler
     {
          public event VoidPressDelegate onPress;
          //private Text text;
          private RectTransform rect;
          protected override void Start()
          {
               base.Start();
               //text = GetComponentInChildren<Text>();
               //if (text != null)
               //text.text = gameObject.name;
               rect = GetComponent<RectTransform>();
               m_scaleDefault = rect.localScale;
          }
          protected Vector3 m_scaleDefault;
          public float m_scale = 1.2f;
          public float m_scaleTime = 0.45f;
          public override void fn_handInOut(bool _inOut)
          {
               base.fn_handInOut(_inOut);
               if (rect == null) return;
               if (_inOut)
               {
                    //rect.DOScale(1.2f, 0.5f);
                    rect.DOScaleX(m_scaleDefault.x * m_scale, m_scaleTime);
                    rect.DOScaleY(m_scaleDefault.y * m_scale, m_scaleTime);
                    rect.DOScaleZ(m_scaleDefault.z * m_scale, m_scaleTime);

               }
               else
               {
                    //rect.DOScale(1, 0.5f);
                    rect.DOScaleX(m_scaleDefault.x , m_scaleTime*0.5f);
                    rect.DOScaleY(m_scaleDefault.y, m_scaleTime * 0.5f);
                    rect.DOScaleZ(m_scaleDefault.z, m_scaleTime * 0.5f);
               }

          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               base.fn_trigger(_button, _hand);
               if (_button == E_buttonIndex.e_padPressDown)
               {
                    if (onPress != null)
                    {
                         onPress(this.gameObject, true);
                    }
               }
               if (_button == E_buttonIndex.e_padPressUp)
               {
                    if (onPress != null)
                    {
                         onPress(this.gameObject, false);
                    }
               }
               if (_button == E_buttonIndex.e_padTouched)
               {
                    rect.DOScale(1.2f, 0.3f);
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    rect.DOScale(1, 0.3f);
               }
          }

          public void OnPointerUp(PointerEventData eventData)
          {
               if (onPress != null)
               {
                    onPress(this.gameObject, false);
               }
          }

          public void OnPointerDown(PointerEventData eventData)
          {
               if (onPress != null)
               {
                    onPress(this.gameObject, true);
               }
          }
     }
}