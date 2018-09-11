using UnityEngine;
using System.Collections;
//using VRPT.Turntable;
using System;
namespace GasPowerGeneration
{
     ///<summary>
     ///@ version 1.0 /2017.0206/ :手柄射线发射，提供接口显示和隐藏射线
     ///@ author gong
     ///@ version 1.1 /2017.0215/ ://激活同一物体的优化
     ///@ author gong
     ///@ version 1.2 /2017./ :
     ///@ author gong
     ///@ version 1.3 /2017./ :
     ///@ author gong
     ///</summary>
     /// 
     public class NewLine : MonoBehaviour, I_ShowOrHideRay, I_GetTriggerObj
     {
          public GameObject holder;
          //可见的射线模型
          public GameObject pointer;
          public float thickness = 0.002f;
          //射线
          private RaycastHit hit;
          private bool bHit;
          private Ray raycast;

          MeshRenderer m_line;
          public Material m_rayMaterial;
          //射线是否显示
          private bool m_show = true;
          //
          //	public GameObject m_hand_tips;
          //	private A_HandTip m_tips;
          // Use this for initialization
          void Start()
          {

               holder = new GameObject("line");
               holder.transform.parent = this.transform;
               holder.transform.localPosition = Vector3.zero;
               //holder.transform.localRotation = Quaternion.identity;
               fnp_creatLine();


               raycast = new Ray(transform.position, transform.forward);
               fni_hidRay();
               S_update.Instance.M_update = MyUpdate;

          }
          /// <summary>
          /// 创建射线模型
          /// </summary>
          private void fnp_creatLine()
          {
               //		if (m_hand_tips!=null) {
               //			m_hand_tips.transform.parent= holder.transform;
               //			m_hand_tips.transform.localPosition = new Vector3(0f, 0.1f, 0.1f);
               //			m_hand_tips.SetActive (false);
               //		}

               pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
               pointer.name = "ray";
               pointer.transform.parent = holder.transform;
               pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
               pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
               holder.transform.localRotation = Quaternion.identity;
               pointer.GetComponent<BoxCollider>().enabled = false;
               m_line = pointer.GetComponent<MeshRenderer>();
               if (m_line != null)
               {
                    m_line.receiveShadows = false;
                    m_line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    if (m_rayMaterial != null)
                    {
                         m_line.material = m_rayMaterial;
                    }
               }
          }
          float m_dis = 0f;
          float m_disDufalut = 50f;
          /// <summary>
          /// 动态设置射线的长度
          /// </summary>
          private void fnpp_RayLength(Vector3 _worldPos)
          {
               m_dis = Vector3.Distance(transform.position, _worldPos);
               if (pointer != null)
               {
                    pointer.transform.localScale = new Vector3(thickness, thickness, m_dis);
                    pointer.transform.localPosition = new Vector3(0f, 0f, m_dis * 0.5f);
               }

          }

          /// <summary>
          /// 显示射线
          /// </summary>
          public void fni_showRay()
          {
               if (m_show == false)
               {
                    //			if (m_hand_tips!=null) {
                    //				m_hand_tips.SetActive (true);
                    //			}
                    //			if (m_tips == null) {
                    //				m_tips = GetComponent<A_HandTip> ();
                    //				if (m_tips != null) {
                    //					m_tips.fn_show ();
                    //				}
                    //			} else {
                    //				m_tips.fn_show ();
                    //			}
                    m_line = pointer.GetComponent<MeshRenderer>();
                    if (m_line != null)
                    {
                         m_line.enabled = true;
                         m_canRayCast = true;
                         fnp_raycast();
                         m_show = true;
                    }
               }

          }
          /// <summary>
          /// 隐藏射线
          /// </summary>
          public void fni_hidRay()
          {
               if (m_show)
               {
                    m_canRayCast = false;
                    //			if (m_hand_tips!=null) {
                    //				m_hand_tips.SetActive (false);
                    //			}
                    //			if (m_tips!=null) {
                    //				m_tips.fn_hide ();
                    //			}
                    m_line = pointer.GetComponent<MeshRenderer>();
                    if (m_line != null)
                    {
                         m_line.enabled = false;

                    }
                    if (m_triggerObj != null)
                    {
                         m_triggerObj.fn_trigger(E_buttonIndex.e_padTouchOver, null);
                         m_triggerObj = null;
                    }


                    m_hitObjName = "";
                    m_show = false;

               }

          }
          /// <summary>
          /// 获取当前射线选中的物体
          /// </summary>
          /// <returns>A_TriggerObj</returns>
          public A_TriggerObj fni_getControl()
          {
               return m_triggerObj;

          }
          // Update is called once per frame
          //	void Update () {
          //		if (m_canRayCast) {
          //			fnp_raycast ();
          //		}
          //	
          //	
          //	}
          void MyUpdate()
          {
               if (m_canRayCast)
               {
                    fnp_raycast();
               }
          }


          bool m_canRayCast = false;
          float m_rayDistance = 20f;
          private bool fnp_raycast()
          {

               raycast = new Ray(transform.position, transform.forward);
               //Debug.DrawRay(transform.position, transform.forward,new Color(1f,0f,0f));
               bHit = Physics.Raycast(raycast, out hit, m_rayDistance, 1 << S_triggerlayer.m_triggerhand);
               if (bHit)
               {
                    fnpp_RayLength(hit.point);
                    if (m_hitObjName != hit.collider.name && m_hitObjName != "")
                    {
                         //射线前后设想不同的物体时
                         fnp_cansle();

                    }
                    if (m_hitObjName == hit.collider.name)
                    {//激活同一物体的优化
                         return bHit;
                    }
                    if (m_triggerObj == null)
                    {
                         m_hitObjName = hit.collider.name;
                         m_triggerObj = hit.collider.gameObject.GetComponent<A_TriggerObj>();
                    }
                    if (m_triggerObj != null)
                    {
                         m_triggerObj.fn_trigger(E_buttonIndex.e_padTouched, null);
                         //Debug.Log("newline ray to name=" + hit.collider.name);
                    }

               }
               else
               {//指向空物体
                    fnp_cansle();
                    m_hitObjName = "";
                    if (pointer != null)
                    {
                         pointer.transform.localScale = new Vector3(thickness, thickness, m_disDufalut);
                         pointer.transform.localPosition = new Vector3(0f, 0f, m_disDufalut * 0.5f);
                    }

               }
               return bHit;

          }
          /// <summary>
          /// 取消射线激活的高亮物体
          /// </summary>
          private void fnp_cansle()
          {
               if (m_triggerObj != null)
               {
                    m_triggerObj.fn_trigger(E_buttonIndex.e_padTouchOver, null);
               }
               m_triggerObj = null;

          }

          /// <summary>
          /// 射线击中的物体
          /// </summary>
          private A_TriggerObj m_triggerObj;
          private string m_hitObjName = "";


     } 
}
