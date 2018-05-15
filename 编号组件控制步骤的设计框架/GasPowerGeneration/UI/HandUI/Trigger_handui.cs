using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

     namespace GasPowerGeneration
     {
          public class Trigger_handui : A_TriggerObj, IPointerDownHandler, IPointerUpHandler
          {

               public event VoidPressDelegate onPress;
               private Text text;
               private RectTransform rect;
               protected override void Start()
               {
                    base.Start();
                    text = GetComponentInChildren<Text>();
                    if (text != null)
                         text.text = gameObject.name;
                    rect = GetComponent<RectTransform>();
               }
               public override void fn_handInOut(bool _inOut)
               {
                    base.fn_handInOut(_inOut);
                    if (rect == null) return;
                    if (_inOut)
                    {
                         rect.DOScale(1.2f, 0.5f);
                    }
                    else
                    {
                         rect.DOScale(1, 0.5f);
                    }

               }

               public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
               {
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
