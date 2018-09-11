using UnityEngine;
using System.Collections;
//using VRPT.Turntable;
namespace GasPowerGeneration
{

     ///<summary>
     ///@ version 1.0 /2017.0714/ :手柄上的一个方形范围，检查这里面的所有可以互动的物体
     ///@ author gong
     ///@ version 1.1 /2017.0804/ :加入手柄进入物体的触发消息
     ///@ author gong
     ///@ version 1.2 /2018.0307/ :修改碰撞体的位置到手柄的前部圆球内
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     public class HandFindNearObj : MonoBehaviour, I_GetTriggerObj
     {
          private const int ColliderArraySize = 16;
          /// <summary>
          /// 手柄周围的物体
          /// </summary>
          private Collider[] m_overlappingColliders;
          private Transform m_theHand;

          //	// Use this for initialization
          void Start()
          {

               //		S_update.Instance.M_fixedupdate = MyFixed;
               m_overlappingColliders = new Collider[ColliderArraySize];
               if (m_theHand==null)
               {
                    m_theHand = this.transform; 
               }
               GlobalEventSystem<GE_refleshFindNearObj>.eventHappened += fnp_reflesh;

          }
          //用于代码刷新手柄最近的物体
          protected void fnp_reflesh(GE_refleshFindNearObj _pare)
          {
               m_neatObje = null;
               m_preNearObj = null;
               MyFixed();
          }
          //
          //	// Update is called once per frame
          //	void Update () {
          //
          //	}
          /// <summary>
          /// 最近的物体
          /// </summary>
          public A_TriggerObj m_neatObje;
          /// <summary>
          /// 上一次选中的物体
          /// </summary>
          protected A_TriggerObj m_preNearObj;

          /// <summary>
          /// 获取当前射线选中的物体
          /// </summary>
          /// <returns>A_TriggerObj</returns>
          public A_TriggerObj fni_getControl()
          {
               return m_preNearObj;

          }
          float m_closestDistance = float.MaxValue;
          void MyFixed()
          {
               if (S_SceneMessage.Instance.me_thisSceneName == E_sceneName.e_step)
               {
                    if (S_SceneMagT1.Instance.IsPause)
                    {
                         CancelInvoke("MyFixed");
                         return;
                    }
               }
               //			float t_closestDistance = float.MaxValue;
               if (m_theHand==null)
               {
                    m_theHand = this.transform; 
               }
               if (m_theHand==null)
               {

                    Debug.Log("<color=red>m_theHand==null</color>");
     
                    return;
               }
               for (int i = 0; i < m_overlappingColliders.Length; ++i)
               {
                    m_overlappingColliders[i] = null;
               }

               //Vector3 t_boxPos = new Vector3(
               //    m_theHand.position.x ,
               //    m_theHand.position.y - 0.03f,
               //    m_theHand.position.z);
               Physics.OverlapBoxNonAlloc(
                    m_theHand.position,
                    new Vector3(0.06f, 0.06f, 0.06f),
                    m_overlappingColliders,
                    Quaternion.identity,
                    1 << S_triggerlayer.m_triggerhand
               );


               //			Debug.Log ("<color=blue>碰到物体的数量=</color>"+m_overlappingColliders.Length);
               for (int i = 0; i < m_overlappingColliders.Length; i++)
               {
                    if (m_overlappingColliders[i] == null)
                         continue;
                    if (m_overlappingColliders[i].gameObject.tag == "putin")
                    {
                         continue;
                    }
                    //				Debug.Log ("<color=blue>collider name =</color>"+m_overlappingColliders[i].name);
                    A_TriggerObj t_triggerobj = m_overlappingColliders[i].GetComponentInParent<A_TriggerObj>();

                    // Yeah, it's null, skip
                    if (t_triggerobj == null)
                         continue;
                    ////用来区分双手碰到一个物体的情况,或者这个物体不能被操作的情况
                    //if (t_triggerobj.m_canuse==false)
                    //     continue;
                    // Best candidate so far...
                    float distance = Vector3.Distance(t_triggerobj.transform.position, m_theHand.position);
                    if (distance < m_closestDistance)
                    {
                         m_closestDistance = distance;

                         m_neatObje = t_triggerobj;

                    }
               }
               //			foreach (Collider collider in m_overlappingColliders) {
               //
               //				if (collider == null)
               //					continue;
               //				Debug.Log ("<color=blue>collider name =</color>"+collider.name);
               //				A_TriggerObj t_triggerobj = collider.GetComponentInParent<A_TriggerObj> ();
               //			
               //				// Yeah, it's null, skip
               //				if (t_triggerobj == null)
               //					continue;
               //			
               //				// Best candidate so far...
               //				float distance = Vector3.Distance (t_triggerobj.transform.position, m_theHand.position);
               //				if (distance < m_closestDistance) {
               //					m_closestDistance = distance;
               //	
               //					m_neatObje = t_triggerobj;
               //			
               //				}
               //			}
               if (m_neatObje != null)
               {
                    if (m_neatObje != m_preNearObj)
                    {//可以上一次触发的结果对比
                         //					Debug.Log ("<color=red>碰到不同物体</color>");
                         if (m_preNearObj != null)
                         {
                              if (m_preNearObj.M_inOut == true)
                              {
                                   m_preNearObj.fn_handInOut(false);
                              }
                         }
                         m_preNearObj = m_neatObje;
                         m_closestDistance = float.MaxValue;
                         m_neatObje = null;
                         if (m_preNearObj != null)
                         {
                              if (m_preNearObj.M_inOut == false)
                              {
                                   m_preNearObj.fn_handInOut(true);
                              }
                         }
                    }
                    else
                    {
                         m_closestDistance = float.MaxValue;
                         m_neatObje = null;
                    }
               }
               else
               {
                    //				Debug.Log ("<color=red>没有碰到物体</color>");
                    m_closestDistance = float.MaxValue;
                    //				m_neatObje = null;
                    if (m_preNearObj != null)
                    {
                         if (m_preNearObj.M_inOut == true)
                         {
                              m_preNearObj.fn_handInOut(false);
                         }
                         m_preNearObj = null;
                    }
               }
               //			m_overlappingColliders = null;


               //	if (m_neatObje!=null) {
               //
               //
               //		float distance = Vector3.Distance (m_neatObje.transform.position, m_theHand.position);
               //		if (distance <= m_closestDistance*1.1f) {
               ////				m_neatObje
               //			if (m_neatObje.M_inOut == false) {
               //				m_neatObje.fn_handInOut (true);
               //			}
               //		} else {
               //			if (m_neatObje.M_inOut == true) {
               //				m_neatObje.fn_handInOut (false);
               //			}
               //			m_closestDistance = float.MaxValue;
               //			m_neatObje = null;
               //		}
               //	}

               //			if (t_closestDistance>2f) {
               //				m_neatObje = null;
               //			}


          }

          void OnDrawGizmos()
          {
#if UNITY_EDITOR
               //m_theHand = m_theHand ?? this.transform;
               //Vector3 t_boxPos = new Vector3(
               //    m_theHand.position.x,
               //    m_theHand.position.y,
               //    m_theHand.position.z);
               //Gizmos.color = new Color(0.5f, 1.0f, 0.5f, 0.9f);
               ////Transform sphereTransform = m_theHand ? m_theHand : this.transform;
               //Gizmos.DrawWireSphere(t_boxPos, 0.05f); 
#endif
          }

          void OnEnable()
          {
               InvokeRepeating("MyFixed", 3f, 0.2f);
          }

          void OnDisable()
          {
               CancelInvoke("MyFixed");
          }

     }


}