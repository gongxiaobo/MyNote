using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
namespace GasPowerGeneration
{

     public delegate void VoidDelegate(GameObject go);

     public delegate void VoidHoverDelegate(GameObject go, bool isHover);

     public delegate void VoidPressDelegate(GameObject go, bool press);
     /// <summary>
     /// 界面控件基类
     /// </summary>
     public class UISceneWidget : A_TriggerObj
     {


          public event VoidDelegate onClick;
          public event VoidHoverDelegate onHover;

          /// <summary>
          /// 获取ui元素
          /// </summary>
          /// <param name="go"></param>
          /// <returns></returns>
          static public UISceneWidget Get(GameObject go)
          {
               UISceneWidget listener = go.GetComponent<UISceneWidget>();
               if (listener == null) listener = go.AddComponent<UISceneWidget>();
               return listener;
          }
          public void OnClickThis()
          {
               if (onClick != null)
               {
                    onClick(this.gameObject);
               }
          }

          public void OnHoverThis(bool isHover)
          {
               if (isHover != null)
                    onHover(this.gameObject, isHover);
          }

          public override void fn_trigger(E_buttonIndex _button, I_HandButton _hand)
          {
               if (_button == E_buttonIndex.e_padPressUp)
               {
                    onClick(this.gameObject);
               }
               //if (_button == E_buttonIndex.e_padTouched)
               //    onHover(this.gameObject, true);
               //if (_button == E_buttonIndex.e_padTouchOver)
               //    onHover(this.gameObject, false);
               if (_button == E_buttonIndex.e_padTouched)
               {
                    GetComponent<RectTransform>().DOScale(1.2f, 0.3f);
               }
               if (_button == E_buttonIndex.e_padTouchOver)
               {
                    GetComponent<RectTransform>().DOScale(1, 0.3f);
               }

          }




     }

}