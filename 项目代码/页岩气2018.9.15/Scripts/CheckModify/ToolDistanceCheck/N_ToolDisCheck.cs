using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GasPowerGeneration
{
     public class N_ToolDisCheck : AB_ToolDisCheck
     {
          protected Vector3 m_Original;
          protected Transform m_this = null;
          /// <summary>
          /// 重置工具的距离
          /// </summary>
          public float m_DistanceReset = 10f;
          protected AB_State m_toolState = null;
          protected AB_Name m_name = null;
          protected virtual void Start()
          {
               m_name = GetComponent<AB_Name>();
               m_toolState = GetComponent<AB_State>();
               StartCoroutine(fnp_find());
          }
          IEnumerator fnp_find()
          {
               yield return new WaitForSeconds(2f);
               //fnp_init();
               //Debug.Log("<color=blue>m_Original:</color>" + 
               //  );

               m_Original = S_PartOnGround.Instance.fn_getPos(m_name.m_ID);
               Debug.Log("<color=blue>m_Original:</color>" + m_Original);
               m_this = this.gameObject.transform;
               S_update.Instance.M_fixedupdate = fn_check;
          }
          private void fnp_init()
          {
               bool t_findResult = fnp_findOriginal();
               if (t_findResult)
               {
                    m_this = this.gameObject.transform;
                    S_update.Instance.M_fixedupdate = fn_check;

               }
               Debug.Log("<color=blue>m_Original:</color>" + m_Original);
          }
          public override void fn_check()
          {

               if (Vector3.Distance(m_Original, m_this.position) > m_DistanceReset)
               {
                    //fn_resetPos();
                    if (m_toolState != null)
                    {//如果在工具在手中，暂时不重置位置
                         if (m_toolState.fn_getMainValue() == "0")
                         {
                              fn_resetPos();
                         }
                         if (m_toolState.fn_getMainValue() == "1")
                         {//在手中
                              FixedJoint t_joint = GetComponent<FixedJoint>();
                              if (t_joint != null)
                              {
                                   Rigidbody t_hand = t_joint.connectedBody;
                                   if (t_hand != null)
                                   {
                                        this.gameObject.transform.position =
                                             t_hand.gameObject.transform.position;
                                   }
                              }
                         }
                    }
                    else
                    {
                         fn_resetPos();
                    }
               }
          }

          public override void fn_resetPos()
          {
               this.gameObject.transform.position = m_Original;
          }
          protected virtual bool fnp_findOriginal()
          {

               if (m_name != null)
               {
                    m_Original = S_PartOnGround.Instance.fn_getPos(m_name.m_ID);
               }
               else
               {
                    return false;
               }
               return true;
          }
     }
}
