using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 有限定角度功能的旋钮
     /// </summary>
     public class CaculateAngelLimit : CaculateAngel
     {
          /// <summary>
          /// 旋钮度数的限制
          /// 但是这个角度范围是根据初始化角度来定的
          /// 是在初始化角度的前后距离角度
          /// 例如：初始化角度0，m_limit=Vector2(10f, 10f)
          /// 那么角度的旋转范围就是Vector2(-10f, 10f)
          /// </summary>
          public Vector2 m_limit = new Vector2(0f, 90f);
          protected Vector2 m_limitRang;
          protected override void Start()
          {
               base.Start();
               fnp_setRange(m_limit);

               //Debug.Log("<color=red>red:</color>" + m_limitRang);

          }
          /// <summary>
          /// 设置最大小值的范围
          /// </summary>
          protected virtual void fnp_setRange(Vector2 _limit)
          {
               m_limitRang = new Vector2(m_startAngel - Mathf.Abs(_limit.x),
                    m_startAngel + Mathf.Abs(_limit.y));
          }
          protected override void fnp_handleRotate()
          {
               base.fnp_handleRotate();
               if (m_sample != null)
               {
                    if (AllRotate >= (m_limitRang.y + 5f))
                    {//超出最大值
                         fn_endControl();

                         //Debug.Log("<color=red>end red1:</color>" + AllRotate);


                    }
                    if (AllRotate <= (m_limitRang.x - 5f))
                    {//超出最小值
                         fn_endControl();
                         //Debug.Log("<color=red>end red2:</color>" + AllRotate);
                    }

               }
          }

          public override void fn_endControl()
          {
               base.fn_endControl();
               if (AllRotate >= m_limitRang.y)
               {
                    fn_setTo(m_limitRang.y);
               }
               if (AllRotate <= m_limitRang.x)
               {
                    fn_setTo(m_limitRang.x);
               }

          }
          /// <summary>
          /// 播放声音
          /// </summary>
          /// <param name="_name"></param>
          protected virtual void fnp_onoffSound(string _name)
          {
               S_SoundComSingle.Instance.fnp_sound(_name);
          }
          public override bool fni_valueToEdge()
          {
               //return base.fni_valueToEdge();
               if (AllRotate >= m_limitRang.y)
               {
                    return true;
               }
               else if (AllRotate <= m_limitRang.x)
               {
                    return true;
               }
               return false;
          }
          public override bool fni_valueToBig()
          {
               if (AllRotate >= m_limitRang.y)
               {
                    return true;
               }
               return false;
          }
          public override bool fni_valueToSmall()
          {
               if (AllRotate <= m_limitRang.x)
               {
                    return true;
               }
               return false;
          }
          public override float fni_getRotateValue()
          {
               //return base.fni_getRotateValue();
               return AllRotate;
          }
          public override Vector2 fni_getLimit()
          {
               //return base.fni_getLimit();
               return m_limitRang;
          }

     }

}