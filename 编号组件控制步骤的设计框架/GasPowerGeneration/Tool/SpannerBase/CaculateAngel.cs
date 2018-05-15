using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GasPowerGeneration
{
     /// <summary>
     /// 360度旋钮的实现
     /// </summary>
     public class CaculateAngel : AB_Spanner
     {
          //旋转平面的四个点，把平面划分为四个象限
          protected Transform m_start, m_90, m_180, m_270;
          //旋转的朝向点
          public Transform m_lookPoint;
          //朝向点的普通状态的父节点，这个要跟着动画走的
          public Transform m_lookPointParent;
          //四个象限的向量
          protected Vector3 m_A1, m_A2, m_A3, m_A4;
          //用来映射角度值到动画播放时间值
          protected Remapfloat m_remap;
          /// <summary>
          /// 采样动画
          /// </summary>
          protected AB_SpAni m_sample;
          //平面的法线
          protected Vector3 m_planeNormal;
          //操作点和圆心的一半距离
          protected float m_circleDis = 10f;
          //观察点的原始位置
          protected Vector3 m_m_lookPointLp;
          /// <summary>
          /// 动画的播放时间 长度 开始时间0f
          /// </summary>
          public Vector2 m_AnimationTime = new Vector2(1f, 0f);
          /// <summary>
          /// 旋转的角度 最大角度 开始角度0f
          /// </summary>
          protected Vector2 m_AngleLimit = new Vector2(360f, 0f);
          [Tooltip("开始旋钮的旋转角度")]
          public float m_startAngel = 10f;
          GetNormal m_getnormal = null;
          // Use this for initialization
          protected virtual void Start()
          {
               m_getnormal = GetComponent<GetNormal>();
               m_planeNormal = m_getnormal.fn_Normal();
               m_start = transform.Find("0");
               m_90 = transform.Find("90");
               m_180 = transform.Find("180");
               m_270 = transform.Find("270");
               if (m_start == null || m_90 == null || m_180 == null || m_270 == null)
               {
                    Destroy(this);
                    return;
               }
               m_lookPoint = transform.FindInChild("LookTargetMove");
               m_lookPointParent = transform.FindInChild("LookTarget");
               fnp_UpdateVector();

               m_remap = new Remapfloat(m_AnimationTime.x, m_AnimationTime.y,
                    m_AngleLimit.x, m_AngleLimit.y);


               m_circleDis = Vector3.Distance(m_lookPoint.position,
                    gameObject.transform.position) * 0.5f;

               m_m_lookPointLp = m_lookPoint.localPosition;
               //动画
               m_sample = GetComponentInChildren<AB_SpAni>();
               fn_setTo(m_startAngel);
          }
          /// <summary>
          /// 是否动态更新法线
          /// </summary>
          public bool m_updateNormalRealTime = false;
          /// <summary>
          /// 动态更新法线平面
          /// </summary>
          private void fnp_UpdateVector()
          {
               m_A1 = Vector3.Normalize(m_start.position - gameObject.transform.position);
               m_A2 = Vector3.Normalize(m_90.position - gameObject.transform.position);
               m_A3 = Vector3.Normalize(m_180.position - gameObject.transform.position);
               m_A4 = Vector3.Normalize(m_270.position - gameObject.transform.position);
               m_planeNormal = m_getnormal.fn_Normal();
          }

          //更新数据
          void MyUpdate()
          {
#if UNITY_EDITOR
               Debug.DrawLine(gameObject.transform.position, m_lookPoint.position, Color.blue);
               Debug.DrawLine(gameObject.transform.position, m_start.position, Color.red);
#endif
               fnp_calculate();
          }
          //上一次的向量夹角值
          protected float m_lastValue = 0f;
          //当前的向量夹角值
          protected float m_rotateAngel = 0f;
          /// <summary>
          /// 计算移动后当前夹角的值，然后采样动画
          /// </summary>
          protected void fnp_calculate()
          {
               if (m_updateNormalRealTime)
               {
                    fnp_UpdateVector();
               }
               //Vector3 t_nowArrow = Vector3.Normalize(m_lookPoint.position - gameObject.transform.position);
               Vector3 t_nowArrow = (m_lookPoint.position - gameObject.transform.position);
               t_nowArrow = Vector3.ProjectOnPlane(t_nowArrow, m_planeNormal);
               if (Vector3.Magnitude(t_nowArrow) < m_circleDis)
               {//判断是否目标点太靠近原点
                    fn_endControl();
               }
               if ((Vector3.Angle(m_A1, t_nowArrow) <= 90f) &&
                    (Vector3.Angle(m_A2, t_nowArrow) < 90f))
               {
                    m_rotateAngel = Vector3.Angle(m_A1, t_nowArrow);
               }
               else if (Vector3.Angle(m_A2, t_nowArrow) <= 90f &&
                  Vector3.Angle(m_A3, t_nowArrow) < 90f)
               {
                    m_rotateAngel = 90f + Vector3.Angle(m_A2, t_nowArrow);
               }
               else if (Vector3.Angle(m_A3, t_nowArrow) <= 90f &&
                  Vector3.Angle(m_A4, t_nowArrow) < 90f)
               {
                    m_rotateAngel = 180f + Vector3.Angle(m_A3, t_nowArrow);
               }
               else if (Vector3.Angle(m_A4, t_nowArrow) < 90f &&
                  Vector3.Angle(m_A1, t_nowArrow) < 90f)
               {
                    m_rotateAngel = 270f + Vector3.Angle(m_A4, t_nowArrow);
               }
               else if (Vector3.Angle(m_A1, t_nowArrow) == 90f &&
                  m_rotateAngel > 270f)
               {
                    m_rotateAngel = 360f;
               }
               fnp_handleRotate();

          }
          /// <summary>
          /// 动画根据旋转角度进行采样
          /// </summary>
          protected virtual void fnp_handleRotate()
          {
               if (m_sample != null && m_lastValue != m_rotateAngel)
               {
                    //m_allRotate = fnp_rotateCircle(m_lastValue, m_rotateAngel);
                    fnp_rotateCircle(m_lastValue, m_rotateAngel);
                    m_lastValue = m_rotateAngel;
                    //根据夹角采样动画值
                    m_sample.fn_setAniTime(m_remap.fn_remap(m_lastValue));
                    if (S_handShake.Instance.HandShake != null)
                    {
                         S_handShake.Instance.HandShake();
                    }
                    fnp_playSound();
               }
          }
          /// <summary>
          /// 在旋转的过程中播放声音
          /// </summary>
          protected virtual void fnp_playSound()
          {

          }
          /// <summary>
          /// 总共旋了 多少度，是相对起始点的位置
          /// </summary>
          [SerializeField]
          protected float m_allRotate = 0f;
          /// <summary>
          /// 总共旋了 多少度，是相对起始点的位置
          /// </summary>
          public float AllRotate
          {
               get { return m_allRotate; }
               //set { m_allRotate = value; }
          }
          /// <summary>
          /// 计算旋转了多少度
          /// </summary>
          /// <param name="_last"></param>
          /// <param name="_now"></param>
          protected void fnp_rotateCircle(float _last, float _now)
          {
               if (_last < _now)
               {//顺时针转动

                    if (_now >= 270f && _last < 90f)
                    {//1到4 逆时针
                         m_allRotate -= (360f - _now);

                         //Debug.Log("<color=red>red1:</color>" + _last + "|" + _now);

                         //return m_allRotate - (360f - _now);
                    }
                    else
                    {
                         //Debug.Log("<color=red>red:2</color>");
                         m_allRotate += (_now - _last);
                         //return m_allRotate + (_now - _last);
                    }


               }
               else if (_last > _now)
               {//逆时针
                    if (_now <= 90f && _last > 270f)
                    {//4到1
                         m_allRotate += (_now + (360f - _last));
                         //Debug.Log("<color=red>red3</color>");
                         //return m_allRotate + (_now + (360f - _last));
                    }
                    else
                    {
                         m_allRotate -= (_last - _now);
                         //Debug.Log("<color=red>red:4</color>");
                         //return m_allRotate - (_last - _now);
                    }

               }
               else
               {
                    //return m_allRotate;
               }
               

          }
          /// <summary>
          /// 快捷设置旋转到一定度数位置
          /// </summary>
          /// <param name="_angel"></param>
          public override void fn_setTo(float _angel)
          {
               if (m_isConnect)
               {
                    return;
               }

               //Debug.Log("<color=blue>xxxblue:</color>" + _angel);

               if (_angel != m_allRotate)
               {
                    float t_rotate = _angel % 360f;
                    m_allRotate = _angel;
                    if (m_sample != null)
                    {
                         //Debug.Log("<color=blue>xxxblue:</color>" + _angel);
                         m_lastValue = t_rotate < 0f ? (360f - Mathf.Abs(t_rotate)) : t_rotate;
                         m_rotateAngel = m_lastValue;
                         m_sample.fn_setAniTime(m_remap.fn_remap(
                              (t_rotate < 0f) ? (360f + t_rotate) : (t_rotate)));

                    }
               }
          }
          protected bool m_isConnect = false;
          /// <summary>
          /// 开始控制
          /// </summary>
          /// <param name="_hand"></param>
          public override void fn_startControl(Transform _hand)
          {
               if (m_isConnect)
               {
                    return;
               }
               m_isConnect = true;
               m_isDisConnect = false;
               m_lookPoint.parent = null;
               m_lookPoint.parent = _hand;
               S_update.Instance.M_update = MyUpdate;
          }
          protected bool m_isDisConnect = true;
          /// <summary>
          /// 结束控制
          /// </summary>
          public override void fn_endControl()
          {
               if (m_isDisConnect)
               {
                    return;
               }

               m_isDisConnect = true;

               S_update.Instance.fn_remove(MyUpdate);
               m_lookPoint.parent = null;
               m_lookPoint.parent = m_lookPointParent;
               m_lookPoint.localRotation = Quaternion.identity;
               m_lookPoint.localPosition = m_m_lookPointLp;
               m_isConnect = false;

          }


          public override void fn_setTo(string _com)
          {
               throw new System.NotImplementedException();
          }
     } 
}